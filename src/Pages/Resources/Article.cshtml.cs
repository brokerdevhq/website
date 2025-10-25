using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BrokerDevWebsite.Models;
using BrokerDevWebsite.Services;

namespace BrokerDevWebsite.Pages.Resources;

public class ArticleModel : PageModel
{
    private readonly IResourceService _resourceService;
    private readonly ILogger<ArticleModel> _logger;

    public ResourceArticleDetail? Article { get; set; }

    public ArticleModel(IResourceService resourceService, ILogger<ArticleModel> logger)
    {
        _resourceService = resourceService;
        _logger = logger;
    }

    public async Task<IActionResult> OnGetAsync(string slug)
    {
        try
        {
            Article = await _resourceService.GetArticleBySlugAsync(slug);

            if (Article == null)
            {
                return NotFound();
            }

            return Page();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading article with slug {Slug}", slug);
            return NotFound();
        }
    }
}
