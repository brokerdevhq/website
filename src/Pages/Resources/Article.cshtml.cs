using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BrokerDevWebsite.Models;
using BrokerDevWebsite.Services;

namespace BrokerDevWebsite.Pages.Resources;

public class ArticleModel : PageModel
{
    private readonly IResourceService _resourceService;

    public ResourceArticleDetail? Article { get; set; }

    public ArticleModel(IResourceService resourceService)
    {
        _resourceService = resourceService;
    }

    public async Task<IActionResult> OnGetAsync(string slug)
    {
        Article = await _resourceService.GetArticleBySlugAsync(slug);

        if (Article == null)
        {
            return NotFound();
        }

        return Page();
    }
}
