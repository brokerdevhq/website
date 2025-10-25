namespace BrokerDevWebsite.Models;

public record ResourceArticle
{
    public string Slug { get; init; } = string.Empty;
    public string Title { get; init; } = string.Empty;
    public string Summary { get; init; } = string.Empty;
    public IEnumerable<string> Categories { get; init; } = new List<string>();
    public string Author { get; init; } = "BrokerDev";
    public DateTime? PublishDate { get; init; }
    public int ReadingTimeMinutes { get; init; }

    public bool IsPublished() => PublishDate.HasValue && PublishDate.Value.Date <= DateTime.Today;
}

public record ResourceArticleDetail : ResourceArticle
{
    public string Content { get; init; } = string.Empty;
}
