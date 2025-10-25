using BrokerDevWebsite.Models;

namespace BrokerDevWebsite.Services;

public class InMemoryCategoryService : ICategoryService
{
    private readonly ILogger<InMemoryCategoryService> _logger;

    public InMemoryCategoryService(ILogger<InMemoryCategoryService> logger)
    {
        _logger = logger;
    }

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
        _logger.LogDebug("Retrieving all categories (count: {Count})", _categories.Count);
        return Task.FromResult(_categories.OrderBy(c => c.DisplayOrder).ToList());
    }

    public Task<ResourceCategory?> GetCategoryByIdAsync(string id)
    {
        _logger.LogDebug("Retrieving category by ID: {CategoryId}", id);

        var category = _categories.FirstOrDefault(c =>
            c.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

        if (category == null)
        {
            _logger.LogWarning("Category not found for ID: {CategoryId}", id);
        }

        return Task.FromResult(category);
    }

    public bool IsValidCategory(string categoryId)
    {
        if (string.IsNullOrWhiteSpace(categoryId))
            return false;

        var isValid = _categories.Any(c =>
            c.Id.Equals(categoryId, StringComparison.OrdinalIgnoreCase));

        if (!isValid)
        {
            _logger.LogDebug("Invalid category ID: {CategoryId}", categoryId);
        }

        return isValid;
    }
}
