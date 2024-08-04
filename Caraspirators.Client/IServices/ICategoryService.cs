

namespace Caraspirators.Client.IServices;

public interface ICategoryService
{
    Task<(IEnumerable<Category> data, bool succeeded, string message)> GetCategoriesAsync();
}
