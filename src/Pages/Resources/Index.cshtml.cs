using Microsoft.AspNetCore.Mvc.RazorPages;
using BrokerDevWebsite.Constants;
using BrokerDevWebsite.Models;
using BrokerDevWebsite.Services;

namespace BrokerDevWebsite.Pages.Resources;

public class ResourcesIndexModel : PageModel
{
    private readonly IResourceService _resourceService;
    private readonly ICategoryService _categoryService;
    private readonly ILogger<ResourcesIndexModel> _logger;

    public List<ResourceArticle> Articles { get; set; } = new();
    public List<ResourceCategory> Categories { get; set; } = new();
    public string? SelectedCategory { get; set; }

    public ResourcesIndexModel(IResourceService resourceService, ICategoryService categoryService, ILogger<ResourcesIndexModel> logger)
    {
        _resourceService = resourceService;
        _categoryService = categoryService;
        _logger = logger;
    }

    public async Task OnGetAsync(string? category)
    {
        try
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
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading resources for category {Category}", category);
            // Continue with empty lists - page can still render with error state
            Articles = new List<ResourceArticle>();
            Categories = new List<ResourceCategory>();
        }
    }
}
