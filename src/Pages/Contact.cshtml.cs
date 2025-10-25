using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BrokerDevWebsite.Models;
using BrokerDevWebsite.Services;

namespace BrokerDevWebsite.Pages;

public class ContactModel : PageModel
{
    private readonly IContactService _contactService;
    private readonly ILogger<ContactModel> _logger;

    public ContactModel(IContactService contactService, ILogger<ContactModel> logger)
    {
        _contactService = contactService;
        _logger = logger;
    }

    [BindProperty]
    public ContactFormModel ContactForm { get; set; } = new();

    public bool FormSubmitted { get; set; } = false;
    public bool FormError { get; set; } = false;

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        try
        {
            var success = await _contactService.SubmitContactFormAsync(ContactForm);

            if (success)
            {
                FormSubmitted = true;
            }
            else
            {
                FormError = true;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error submitting contact form for {Email}", ContactForm.Email);
            FormError = true;
        }

        return Page();
    }
}
