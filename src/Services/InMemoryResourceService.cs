using BrokerDevWebsite.Models;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Caching.Memory;

namespace BrokerDevWebsite.Services;

public class InMemoryResourceService : IResourceService
{
    private readonly ILogger<InMemoryResourceService> _logger;
    private readonly IMemoryCache _cache;
    private const string AllArticlesCacheKey = "AllArticles";
    private static readonly TimeSpan CacheDuration = TimeSpan.FromMinutes(30);

    public InMemoryResourceService(ILogger<InMemoryResourceService> logger, IMemoryCache cache)
    {
        _logger = logger;
        _cache = cache;
    }

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

    private static readonly List<ResourceArticleDetail> _articles = new()
    {
        new ResourceArticleDetail
        {
            Slug = "what-is-mcp",
            Title = "What is Model Context Protocol (MCP)?",
            Summary = "Learn how MCP enables AI assistants to securely access your business data.",
            Categories = new List<string> { "definitions", "guides" },
            PublishDate = new DateTime(2025, 10, 20),
            ReadingTimeMinutes = 0, // Will be calculated below
            Content = @"
## Understanding Model Context Protocol

Model Context Protocol (MCP) is an open standard developed by Anthropic that enables AI assistants to securely connect to your business data and systems.

### Why MCP Matters for Insurance Brokerages

Traditional insurance management systems like PowerBroker and BMSS contain decades of valuable data, but this data is trapped in legacy formats that modern AI tools can't easily access.

MCP solves this by providing a standardized way for AI assistants like Claude, ChatGPT, and Copilot to:

- Query your data in natural language
- Access information securely without exposing credentials
- Work with your existing systems without requiring migration
- Maintain audit logs of all data access

### How It Works

MCP acts as a bridge between AI assistants and your data sources. When you ask an AI a question about your business data, MCP:

1. Receives the request from the AI assistant
2. Translates it into the appropriate query for your BMS
3. Retrieves the data securely
4. Returns it to the AI in a format it can understand

This all happens on your infrastructure, ensuring your data never leaves your network.
            "
        },
        new ResourceArticleDetail
        {
            Slug = "bms-integration-guide",
            Title = "Getting Started with BMS Integration",
            Summary = "A step-by-step guide to connecting your legacy BMS to modern AI tools.",
            Categories = new List<string> { "guides" },
            PublishDate = new DateTime(2025, 10, 15),
            Content = @"
## Integration Overview

This guide walks you through the process of connecting your legacy BMS to modern AI tools using BrokerDev's MCP API.

### Prerequisites

- Windows Server running your BMS (PowerBroker, BMSS, etc.)
- Network access to your BMS database
- .NET 9.0 runtime installed
- Basic understanding of your BMS database structure

### Step 1: Install the API Server

Download and install the BrokerDev API server on your Windows server. The installation is straightforward and takes about 5 minutes.

### Step 2: Configure Database Connection

Update the configuration file with your BMS database connection details. We support OleDB connections to FoxPro databases, as well as SQL Server connections.

### Step 3: Test the Connection

Use the built-in diagnostic tools to verify that the API can successfully connect to your BMS database and retrieve sample data.

### Step 4: Connect Your AI Tools

Configure your AI assistants (Copilot, ChatGPT, Gemini) to use the MCP server. We provide simple configuration templates for each platform.

### Step 5: Start Querying

You're ready! Start asking questions in natural language and watch as your AI assistant pulls data directly from your BMS.
            "
        },
        new ResourceArticleDetail
        {
            Slug = "announcing-brokerdev",
            Title = "Announcing BrokerDev",
            Summary = "We're building the bridge between legacy insurance systems and modern AI.",
            Categories = new List<string> { "news" },
            PublishDate = new DateTime(2025, 10, 1),
            Content = @"
## The Problem We're Solving

Insurance brokerages face a unique challenge: their most valuable asset—decades of customer data—is locked away in legacy systems that modern AI tools can't access.

Replacing these systems isn't realistic. Migration projects cost millions, take years, and carry enormous risk. But waiting for vendors to modernize means falling behind competitors who are already leveraging AI.

### Our Solution

BrokerDev bridges your legacy BMS with modern AI tools through the Model Context Protocol (MCP). No migration required. No data leaves your network. Your current system keeps working exactly as it does today.

### What This Means for Brokerages

With BrokerDev, you can:

- Ask AI assistants questions about your book of business in plain English
- Connect Power BI and Tableau directly to your data for real reporting
- Build custom tools like mobile apps and client portals
- Automate renewal analysis and identify cross-sell opportunities

### Early Access

We're working with a small group of brokerages to refine the platform. If you're interested in early access, [get in touch](/contact).

We're excited to help brokerages unlock their data and compete in the age of AI.
            "
        }
    };

    static InMemoryResourceService()
    {
        // Calculate reading time for each article based on content
        foreach (var article in _articles)
        {
            var readingTime = CalculateReadingTime(article.Content);
            // Use reflection to update the init-only property
            var prop = typeof(ResourceArticleDetail).GetProperty(nameof(ResourceArticleDetail.ReadingTimeMinutes));
            if (prop != null)
            {
                prop.SetValue(article, readingTime);
            }
        }
    }

    public Task<List<ResourceArticle>> GetAllArticlesAsync()
    {
        return Task.FromResult(_cache.GetOrCreate(AllArticlesCacheKey, entry =>
        {
            _logger.LogDebug("Cache miss - retrieving all articles (count: {Count})", _articles.Count);

            entry.AbsoluteExpirationRelativeToNow = CacheDuration;

            var articles = _articles
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

            return articles;
        }) ?? new List<ResourceArticle>());
    }

    public Task<ResourceArticleDetail?> GetArticleBySlugAsync(string slug)
    {
        _logger.LogDebug("Retrieving article by slug: {Slug}", slug);

        var article = _articles.FirstOrDefault(a => a.Slug.Equals(slug, StringComparison.OrdinalIgnoreCase));

        if (article == null)
        {
            _logger.LogWarning("Article not found for slug: {Slug}", slug);
        }

        return Task.FromResult(article);
    }
}
