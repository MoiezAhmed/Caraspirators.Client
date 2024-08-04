


namespace Caraspirators.Client.Framework.Infrustructure.Repositries;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    private readonly IBarrel _barrel;

    public CategoryRepository(IHttpClientFactory httpClientFactory,  IBarrel barrel)
        : base(httpClientFactory)
    {
        _barrel = barrel;
    }

    public async Task<(IEnumerable<Category> data, bool succeeded, string message)> GetCachedCategoriesAsync(string endpoint)
    {
        //if (!_barrel.IsExpired("categories"))
        //{
        //    var cachedCategories = _barrel.Get<IEnumerable<Category>>("categories");
        //    if (cachedCategories != null)
        //    {
        //        return (cachedCategories, true, string.Empty);
        //    }
        //}

        var (data, succeeded, message) = await GetAllAsync<IEnumerable<Category>>(endpoint);
        if (succeeded)
        {
            _barrel.Add("categories", data, TimeSpan.FromMinutes(30));
        }

        return (data, succeeded, message);
    }

   
}