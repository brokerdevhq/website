using Microsoft.AspNetCore.Mvc.RazorPages;
using BrokerDevWebsite.Services;

namespace BrokerDevWebsite.Pages.Resources;

public class ResourcesIndexModel : PageModel
{
    private readonly IResourceService _resourceService;

    public List<ResourceArticle> Articles { get; set; } = new();
    public string? SelectedCategory { get; set; }

    public ResourcesIndexModel(IResourceService resourceService)
    {
        _resourceService = resourceService;
    }

    public async Task OnGetAsync(string? category)
    {
        SelectedCategory = category ?? "all";

        var allArticles = await _resourceService.GetAllArticlesAsync();

        // Filter by category if specified
        if (SelectedCategory != "all")
        {
            Articles = allArticles
                .Where(a => a.Categories.Any(c => c.Equals(SelectedCategory, StringComparison.OrdinalIgnoreCase)))
                .OrderByDescending(a => a.PublishDate)
                .ToList();
        }
        else
        {
            Articles = allArticles.OrderByDescending(a => a.PublishDate).ToList();
        }
    }
}
