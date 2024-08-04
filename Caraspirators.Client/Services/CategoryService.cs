

namespace Caraspirators.Client.Services;
public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<(IEnumerable<Category> data, bool succeeded, string message)> GetCategoriesAsync()
    {
        //  return await _categoryRepository.GetCachedCategoriesAsync();
        return null;
    }
}
