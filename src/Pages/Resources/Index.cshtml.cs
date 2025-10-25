using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BrokerDevWebsite.Pages.Resources;

public class ResourcesIndexModel : PageModel
{
    public List<ResourceArticle> Articles { get; set; } = new();

    public void OnGet()
    {
        // TODO: Load from markdown files or database
        // For now, using sample data
        Articles = new List<ResourceArticle>
        {
            new ResourceArticle
            {
                Slug = "what-is-mcp",
                Title = "What is Model Context Protocol (MCP)?",
                Summary = "Learn how MCP enables AI assistants to securely access your business data.",
                Category = "definitions",
                PublishDate = new DateTime(2025, 10, 20)
            },
            new ResourceArticle
            {
                Slug = "bms-integration-guide",
                Title = "Getting Started with BMS Integration",
                Summary = "A step-by-step guide to connecting your legacy BMS to modern AI tools.",
                Category = "guides",
                PublishDate = new DateTime(2025, 10, 15)
            },
            new ResourceArticle
            {
                Slug = "announcing-brokerdev",
                Title = "Announcing BrokerDev",
                Summary = "We're building the bridge between legacy insurance systems and modern AI.",
                Category = "news",
                PublishDate = new DateTime(2025, 10, 1)
            }
        };

        // Sort by date, newest first
        Articles = Articles.OrderByDescending(a => a.PublishDate).ToList();
    }
}

public class ResourceArticle
{
    public string Slug { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public DateTime PublishDate { get; set; }
    public int ReadingTimeMinutes { get; set; }
}
