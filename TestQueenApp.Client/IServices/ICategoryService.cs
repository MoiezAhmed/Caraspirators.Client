using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestQueenApp.Client.IServices;

public interface ICategoryService
{
    Task<(IEnumerable<Category> data, bool succeeded, string message)> GetCategoriesAsync();
}
