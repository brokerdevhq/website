using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BrokerDevWebsite.Models;

namespace BrokerDevWebsite.Pages;

public class ContactModel : PageModel
{
    private readonly ILogger<ContactModel> _logger;

    public ContactModel(ILogger<ContactModel> logger)
    {
        _logger = logger;
    }

    [BindProperty]
    public ContactFormModel ContactForm { get; set; } = new();

    public bool FormSubmitted { get; set; } = false;

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // Log the contact form submission
        _logger.LogInformation(
            "Contact form submitted: {Name} ({Email}) from {Company} using {System}",
            ContactForm.Name,
            ContactForm.Email,
            ContactForm.Company,
            ContactForm.CurrentSystem
        );

        // TODO: Add email sending logic here
        // For now, we'll just log it
        // In production, you'd want to:
        // 1. Send email via SendGrid, Azure Communication Services, or similar
        // 2. Store in database for tracking
        // 3. Integrate with CRM

        FormSubmitted = true;
        return Page();
    }
}
