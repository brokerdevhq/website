using BrokerDevWebsite.Models;

namespace BrokerDevWebsite.Services;

public interface ICategoryService
{
    Task<List<ResourceCategory>> GetAllCategoriesAsync();
    Task<ResourceCategory?> GetCategoryByIdAsync(string id);
    bool IsValidCategory(string categoryId);
}
