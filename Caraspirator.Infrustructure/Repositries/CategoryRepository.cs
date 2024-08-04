

using Caraspirator.Infrustructure.Data;
using Caraspirator.Infrustructure.Infrustructure;

namespace Caraspirator.Infrustructure.Repositries;
public class CategoryRepository : GenericRepositoryAsync<Category>, ICategoryRepository
{ 
    private readonly DbSet<Category> _categories ;
    public CategoryRepository(AppDbContext dbContext):base(dbContext)
    {

        _categories = dbContext.Set<Category>();

    }
    public async Task<IEnumerable<Category>> GetCategoriesListAsync()
    {
        return await _categories.Include(x=>x.CategoryTrans).Include(p=>p.Parts).ToListAsync();
    }

    public async Task<Category> GetCategoryByNameAsync(string name) => await _categories.FindAsync(name);

    public async Task<IEnumerable<Category>> GetSubCategoriesListAsync(int id)
    {
        return await _categories.Where(y=>y.ParentID==id).Include(x => x.CategoryTrans).ToListAsync();
    }
}
