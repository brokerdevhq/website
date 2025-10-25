using BrokerDevWebsite.Models;

namespace BrokerDevWebsite.Services;

public interface IResourceService
{
    Task<List<ResourceArticle>> GetAllArticlesAsync();
    Task<ResourceArticleDetail?> GetArticleBySlugAsync(string slug);
}
