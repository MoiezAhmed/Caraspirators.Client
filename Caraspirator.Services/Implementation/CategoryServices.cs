
using Caraspirator.Data.Enums;
using Caraspirator.Infrustructure.Infrustructure;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Caraspirator.Services.Implementation;

public class CategoryServices :  ICategoryServices
{
    private readonly ICategoryRepository _categoryRepository;
    public CategoryServices(ICategoryRepository categoryRepository)
    {
        this._categoryRepository = categoryRepository; 
    }


    public Task<IEnumerable<Category>> GetCategoriesListAsync()
    {
        return _categoryRepository.GetCategoriesListAsync();
    }

    public async Task<Category> GetCategoryByNameAsync(string name)
    {
        var category=  _categoryRepository.GetTableNoTracking().Where(x => x.CategoryName.Equals(name)).FirstOrDefault();
        return category;
    }

    public async Task<bool> IsCategoryNameExistAsync(string name)
    {
        var category = _categoryRepository.GetTableNoTracking().Where(x => x.CategoryName.Equals(name)).FirstOrDefault();
        if (category != null) 
        {
            return true; 
        }
        else 
            return false;
        
    }

    public async Task<string> AddCategoryAsync(Category category)
    {
        var categoryResult = _categoryRepository.GetTableNoTracking().Where(x => x.CategoryName.Equals(category.CategoryName)).FirstOrDefault();
        if (categoryResult != null) {
           return "Exist";
        }
        //add category
        await _categoryRepository.AddAsync(category);

        return "Success";

    }


    public async Task<Category> GetCategoryByIdAsync(int id)
    {
      //  var ncategory = await _categoryRepository.GetByIdAsync(id);
        var category = _categoryRepository.GetTableNoTracking()
                                      .Include(x => x.CategoryTrans)
                                      .Where(x => x.CategoryID.Equals(id))
                                      .FirstOrDefault();
        return category;
    }

    public async Task<string> EditCategoryAsync(Category category)
    {
         await _categoryRepository.UpdateAsync(category);       
         return "Success";
    }

    public async Task<string> DeleteCategoryAsync(Category category)
    {
        var trans= _categoryRepository.BeginTransaction();
        try
        {
            await _categoryRepository.DeleteAsync(category);
            await trans.CommitAsync(); 
            return "Success";
        }
        catch (Exception ex) 
        {
            await trans.RollbackAsync();
            return "falied";
        }
      
    }

    public IQueryable<Category> GetCategoriesQueryable()
    {
        return _categoryRepository.GetTableNoTracking().AsQueryable();
    }

    public IQueryable<Category> FilterCategoriesPaginatedQueryable(StudentOrderingEnum orderingenum,string search)
    {
       var querable =  _categoryRepository.GetTableNoTracking().AsQueryable();
        if (search != null)
            querable = querable.Where(x => x.CategoryName.Contains(search));

        switch (orderingenum)
        {
            case StudentOrderingEnum.categoryid:
                querable = querable.OrderBy(x => x.CategoryID);
                break;
            case StudentOrderingEnum.CategoryName:
                querable = querable.OrderBy(x => x.CategoryName);
                break;
            case StudentOrderingEnum.parentid:
                querable = querable.OrderBy(x => x.ParentID);
                break;
            case StudentOrderingEnum.isactive:
                querable = querable.OrderBy(x => x.IsActive);
                break;
        }

        return querable;
    }

    public Task<IEnumerable<Category>> GetSubCategoriesListByIdAsync(int id)
    {
        return _categoryRepository.GetSubCategoriesListAsync(id);
    }

    public IQueryable<Category> FilterSubCategoriesPaginatedQueryable(string search,int id)
    {
        var queryable = _categoryRepository.GetTableNoTracking().Where(x=>x.ParentID==id).AsQueryable();
        if (search != null)
            queryable = queryable.Where(x => x.CategoryName.Contains(search));

        return queryable;
    }
}
