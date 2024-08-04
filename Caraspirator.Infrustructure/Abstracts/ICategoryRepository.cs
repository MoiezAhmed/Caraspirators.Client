using Caraspirator.Infrustructure.Infrustructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Infrustructure.Abstracts;

public interface ICategoryRepository:IGenericRepositoryAsync<Category>
{
    Task<IEnumerable<Category>> GetCategoriesListAsync();
    Task<Category> GetCategoryByNameAsync(string id);
    Task<IEnumerable<Category>> GetSubCategoriesListAsync(int id);
}
