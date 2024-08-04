
using System.Net.Http;
using System.Net;

namespace TestQueenApp.Client.Services;
public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
       
        _categoryRepository = categoryRepository;
    }

    public async Task<(IEnumerable<Category> data, bool succeeded, string message)> GetCategoriesAsync()
    {
        //return await _categoryRepository.GetCachedCategoriesAsync("http://10.0.2.2:5220/api/Categories/Api/V1/Category/Paginated");
        return await _categoryRepository.GetCachedCategoriesAsync("/api/Categories/Api/V1/Category/Paginated");
    }
}
