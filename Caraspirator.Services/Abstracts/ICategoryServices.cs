

using Caraspirator.Data.Enums;

namespace Caraspirator.Services.Abstracts
{
    public interface ICategoryServices
    {
         Task<IEnumerable<Category>> GetCategoriesListAsync();

        Task<Category> GetCategoryByIdAsync(int id);
        
        Task<string> EditCategoryAsync(Category category);

        Task<Category> GetCategoryByNameAsync(string name);

        Task<string> AddCategoryAsync(Category category);

        Task<bool> IsCategoryNameExistAsync(string name);

        Task<string> DeleteCategoryAsync(Category category);

        IQueryable<Category> GetCategoriesQueryable();

        IQueryable<Category> FilterCategoriesPaginatedQueryable(StudentOrderingEnum orderingenum, string search);
      
        IQueryable<Category> FilterSubCategoriesPaginatedQueryable(string search,int id);

        Task<IEnumerable<Category>> GetSubCategoriesListByIdAsync(int id);
    }
}
