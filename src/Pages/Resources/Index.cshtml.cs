using Microsoft.AspNetCore.Mvc.RazorPages;
using BrokerDevWebsite.Constants;
using BrokerDevWebsite.Models;
using BrokerDevWebsite.Services;

namespace BrokerDevWebsite.Pages.Resources;

public class ResourcesIndexModel : PageModel
{
    private readonly IResourceService _resourceService;
    private readonly ICategoryService _categoryService;

    public List<ResourceArticle> Articles { get; set; } = new();
    public List<ResourceCategory> Categories { get; set; } = new();
    public string? SelectedCategory { get; set; }

    public ResourcesIndexModel(IResourceService resourceService, ICategoryService categoryService)
    {
        _resourceService = resourceService;
        _categoryService = categoryService;
    }

    public async Task OnGetAsync(string? category)
    {
        SelectedCategory = category ?? ResourceConstants.AllCategoriesFilter;

        // Load all categories for filter buttons
        Categories = await _categoryService.GetAllCategoriesAsync();

        var allArticles = await _resourceService.GetAllArticlesAsync();

        // Filter by category if specified
        if (SelectedCategory != ResourceConstants.AllCategoriesFilter)
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
