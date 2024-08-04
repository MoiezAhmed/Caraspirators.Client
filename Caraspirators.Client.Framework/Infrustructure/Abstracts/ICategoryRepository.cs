
using System.Net;

namespace Caraspirators.Client.Framework.Infrustructure.Abstracts;
public interface  ICategoryRepository: IGenericRepository<Category>
{
    Task<(IEnumerable<Category> data, bool succeeded, string message)> GetCachedCategoriesAsync(string endpoint);
}
