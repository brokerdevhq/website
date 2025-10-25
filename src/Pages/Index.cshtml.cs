using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        // Get latest 3 resources
        var allResources = await _resourceService.GetAllArticlesAsync();
        LatestResources = allResources.OrderByDescending(a => a.PublishDate).Take(3).ToList();
    }
}
