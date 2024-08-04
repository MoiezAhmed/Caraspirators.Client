namespace Caraspirator.Library.Repositoris.Interface;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(int id);
     Task<bool> DeleteAll();

    Task<T>  Add(T entity);
}
