
namespace CarSpirators.API.Services;

public interface ICategoryService<T> where T : class
{
    Task<IEnumerable<T>> GetCategoriesAsync();
}
