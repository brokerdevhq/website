using BrokerDevWebsite.Models;

namespace BrokerDevWebsite.Services;

public interface IContactService
{
    Task<bool> SubmitContactFormAsync(ContactFormModel form);
}
