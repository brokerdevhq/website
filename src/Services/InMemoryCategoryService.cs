using BrokerDevWebsite.Models;

namespace BrokerDevWebsite.Services;

public class InMemoryCategoryService : ICategoryService
{
    private static readonly List<ResourceCategory> _categories = new()
    {
        new ResourceCategory
        {
            Id = "news",
            Name = "News",
            Description = "Company news and announcements",
            DisplayOrder = 1
        },
        new ResourceCategory
        {
            Id = "guides",
            Name = "Guides",
            Description = "Step-by-step guides and tutorials",
            DisplayOrder = 2
        },
        new ResourceCategory
        {
            Id = "definitions",
            Name = "Definitions",
            Description = "Technical definitions and explanations",
            DisplayOrder = 3
        }
    };

    public Task<List<ResourceCategory>> GetAllCategoriesAsync()
    {
        return Task.FromResult(_categories.OrderBy(c => c.DisplayOrder).ToList());
    }

    public Task<ResourceCategory?> GetCategoryByIdAsync(string id)
    {
        var category = _categories.FirstOrDefault(c =>
            c.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult(category);
    }

    public bool IsValidCategory(string categoryId)
    {
        if (string.IsNullOrWhiteSpace(categoryId))
            return false;

        return _categories.Any(c =>
            c.Id.Equals(categoryId, StringComparison.OrdinalIgnoreCase));
    }
}
