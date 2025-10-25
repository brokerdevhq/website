using BrokerDevWebsite.Models;

namespace BrokerDevWebsite.Services;

public class InMemoryContactService : IContactService
{
    private readonly ILogger<InMemoryContactService> _logger;

    public InMemoryContactService(ILogger<InMemoryContactService> logger)
    {
        _logger = logger;
    }

    public Task<bool> SubmitContactFormAsync(ContactFormModel form)
    {
        // Log the contact form submission
        _logger.LogInformation(
            "Contact form submitted: {Name} ({Email}) from {Company} using {System}. Message: {Message}",
            form.Name,
            form.Email,
            form.Company,
            form.CurrentSystem,
            form.Message
        );

        // TODO: In production, replace this with actual implementation:
        // 1. Send email via SendGrid, Azure Communication Services, or similar
        // 2. Store in database for tracking
        // 3. Integrate with CRM (e.g., HubSpot, Salesforce)
        // 4. Send notification to sales team

        // For now, we simulate successful submission
        return Task.FromResult(true);
    }
}
