namespace BrokerDevWebsite.Services;

public interface IResourceService
{
    Task<List<ResourceArticle>> GetAllArticlesAsync();
    Task<ResourceArticleDetail?> GetArticleBySlugAsync(string slug);
}

public record ResourceArticle
{
    public string Slug { get; init; } = string.Empty;
    public string Title { get; init; } = string.Empty;
    public string Summary { get; init; } = string.Empty;
    public IEnumerable<string> Categories { get; init; } = new List<string>();
    public string Author { get; init; } = "BrokerDev";
    public DateTime PublishDate { get; init; }
    public int ReadingTimeMinutes { get; init; }
}

public record ResourceArticleDetail : ResourceArticle
{
    public string Content { get; init; } = string.Empty;
}
