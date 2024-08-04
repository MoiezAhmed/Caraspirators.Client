namespace Caraspirator.Services.Abstracts;

public interface IGenericServices <T> where T : class
{
    Task<IEnumerable<T>> GetAll();
  
}
