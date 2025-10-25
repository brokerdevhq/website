using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BrokerDevWebsite.Models;
using BrokerDevWebsite.Services;

namespace BrokerDevWebsite.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IResourceService _resourceService;

    public List<ResourceArticle> LatestResources { get; set; } = new();

    public IndexModel(ILogger<IndexModel> logger, IResourceService resourceService)
    {
        _logger = logger;
        _resourceService = resourceService;
    }

    public async Task OnGetAsync()
    {
        try
        {
            // Get latest 3 resources (service already returns sorted by publish date descending)
            var allResources = await _resourceService.GetAllArticlesAsync();
            LatestResources = allResources.Take(3).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading latest resources for homepage");
            // Continue with empty list - homepage can still render
            LatestResources = new List<ResourceArticle>();
        }
    }
}
