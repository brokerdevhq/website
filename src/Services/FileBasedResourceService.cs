using BrokerDevWebsite.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Text.RegularExpressions;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace BrokerDevWebsite.Services;

public class FileBasedResourceService : IResourceService
{
    private readonly ILogger<FileBasedResourceService> _logger;
    private readonly IMemoryCache _cache;
    private readonly IWebHostEnvironment _environment;
    private const string AllArticlesCacheKey = "AllArticles";
    private static readonly TimeSpan CacheDuration = TimeSpan.FromMinutes(30);

    private static readonly IDeserializer _yamlDeserializer = new DeserializerBuilder()
        .WithNamingConvention(CamelCaseNamingConvention.Instance)
        .Build();

    public FileBasedResourceService(
        ILogger<FileBasedResourceService> logger,
        IMemoryCache cache,
        IWebHostEnvironment environment)
    {
        _logger = logger;
        _cache = cache;
        _environment = environment;
    }

    private string GetContentPath() =>
        Path.Combine(_environment.ContentRootPath, "Content", "resources");

    private static int CalculateReadingTime(string content)
    {
        // Strip Markdown formatting (headings, lists, links, etc.)
        var textOnly = Regex.Replace(content, @"^#+\s*", "", RegexOptions.Multiline); // Remove headings
        textOnly = Regex.Replace(textOnly, @"\[([^\]]+)\]\([^\)]+\)", "$1"); // Convert links to text
        textOnly = Regex.Replace(textOnly, @"^[-*+]\s+", "", RegexOptions.Multiline); // Remove list markers
        textOnly = Regex.Replace(textOnly, @"^\d+\.\s+", "", RegexOptions.Multiline); // Remove numbered list markers

        // Count words (split by whitespace and filter empty strings)
        var wordCount = textOnly.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;

        // Calculate reading time (average 200 words per minute)
        var minutes = (int)Math.Ceiling(wordCount / 200.0);

        return Math.Max(1, minutes); // Minimum 1 minute
    }

    private ResourceArticleDetail? ParseMarkdownFile(string filePath)
    {
        try
        {
            var fileContent = File.ReadAllText(filePath);

            // Split frontmatter and content
            var frontmatterMatch = Regex.Match(fileContent, @"^---\s*\n(.*?)\n---\s*\n(.*)$", RegexOptions.Singleline);
            if (!frontmatterMatch.Success)
            {
                _logger.LogWarning("File {FilePath} does not have valid frontmatter", filePath);
                return null;
            }

            var frontmatterYaml = frontmatterMatch.Groups[1].Value;
            var markdownContent = frontmatterMatch.Groups[2].Value.Trim();

            // Parse YAML frontmatter
            var frontmatter = _yamlDeserializer.Deserialize<Dictionary<string, object>>(frontmatterYaml);

            // Calculate reading time
            var readingTime = CalculateReadingTime(markdownContent);

            // Build the article
            return new ResourceArticleDetail
            {
                Slug = frontmatter.GetValueOrDefault("slug")?.ToString() ?? "",
                Title = frontmatter.GetValueOrDefault("title")?.ToString() ?? "",
                Summary = frontmatter.GetValueOrDefault("summary")?.ToString() ?? "",
                Categories = frontmatter.GetValueOrDefault("categories") is List<object> categories
                    ? categories.Select(c => c.ToString() ?? "").ToList()
                    : new List<string>(),
                Author = frontmatter.GetValueOrDefault("author")?.ToString() ?? "BrokerDev",
                PublishDate = frontmatter.GetValueOrDefault("publishDate") is DateTime date
                    ? date
                    : DateTime.TryParse(frontmatter.GetValueOrDefault("publishDate")?.ToString(), out var parsedDate)
                        ? parsedDate
                        : DateTime.Now,
                ReadingTimeMinutes = readingTime,
                Content = markdownContent
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error parsing markdown file {FilePath}", filePath);
            return null;
        }
    }

    private List<ResourceArticleDetail> LoadAllArticles()
    {
        var contentPath = GetContentPath();

        if (!Directory.Exists(contentPath))
        {
            _logger.LogWarning("Content directory does not exist: {ContentPath}", contentPath);
            return new List<ResourceArticleDetail>();
        }

        var markdownFiles = Directory.GetFiles(contentPath, "*.md");
        _logger.LogInformation("Loading {Count} markdown files from {ContentPath}", markdownFiles.Length, contentPath);

        var articles = new List<ResourceArticleDetail>();
        foreach (var file in markdownFiles)
        {
            var article = ParseMarkdownFile(file);
            if (article != null)
            {
                articles.Add(article);
            }
        }

        // Sort by publish date descending
        return articles.OrderByDescending(a => a.PublishDate).ToList();
    }

    public Task<List<ResourceArticle>> GetAllArticlesAsync()
    {
        return Task.FromResult(_cache.GetOrCreate(AllArticlesCacheKey, entry =>
        {
            _logger.LogDebug("Cache miss - loading articles from disk");

            entry.AbsoluteExpirationRelativeToNow = CacheDuration;

            var allArticles = LoadAllArticles();

            return allArticles
                .Select(a => new ResourceArticle
                {
                    Slug = a.Slug,
                    Title = a.Title,
                    Summary = a.Summary,
                    Categories = a.Categories,
                    Author = a.Author,
                    PublishDate = a.PublishDate,
                    ReadingTimeMinutes = a.ReadingTimeMinutes
                })
                .ToList();
        }) ?? new List<ResourceArticle>());
    }

    public Task<ResourceArticleDetail?> GetArticleBySlugAsync(string slug)
    {
        _logger.LogDebug("Retrieving article by slug: {Slug}", slug);

        // Get all articles from cache
        var allArticles = _cache.GetOrCreate(AllArticlesCacheKey, entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = CacheDuration;
            return LoadAllArticles();
        }) ?? new List<ResourceArticleDetail>();

        var article = allArticles.FirstOrDefault(a => a.Slug.Equals(slug, StringComparison.OrdinalIgnoreCase));

        if (article == null)
        {
            _logger.LogWarning("Article not found for slug: {Slug}", slug);
        }

        return Task.FromResult(article);
    }
}
