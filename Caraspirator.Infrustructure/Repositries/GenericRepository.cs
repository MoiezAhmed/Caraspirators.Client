

namespace Caraspirator.Infrustructure.Repositries;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly AppDbContext _appDbContext;

    public GenericRepository(AppDbContext appDbContext)
    {
        this._appDbContext = appDbContext;

    }

    public Task<bool> DeleteAll()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _appDbContext.Set<T>().ToListAsync();
    }

    public async Task<T> GetById(int id)
    {
        return await _appDbContext.Set<T>().FindAsync(id);
    }

    

   async Task<T> IGenericRepository<T>.Add(T entity)
    {
        var n = await _appDbContext.Set<T>().AddAsync(entity);
        await _appDbContext.SaveChangesAsync();
        return entity;
    }
}
