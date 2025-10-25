using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BrokerDevWebsite.Models;
using BrokerDevWebsite.Services;

namespace BrokerDevWebsite.Pages;

public class ContactModel : PageModel
{
    private readonly IContactService _contactService;

    public ContactModel(IContactService contactService)
    {
        _contactService = contactService;
    }

    [BindProperty]
    public ContactFormModel ContactForm { get; set; } = new();

    public bool FormSubmitted { get; set; } = false;

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var success = await _contactService.SubmitContactFormAsync(ContactForm);

        if (success)
        {
            FormSubmitted = true;
        }

        return Page();
    }
}
