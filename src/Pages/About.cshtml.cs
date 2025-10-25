using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BrokerDevWebsite.Pages;

public class AboutModel : PageModel
{
    public Task OnGetAsync()
    {
        return Task.CompletedTask;
    }
}
