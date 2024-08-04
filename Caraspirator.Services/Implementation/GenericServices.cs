
using Caraspirator.Infrustructure.Abstracts;


namespace Caraspirator.Services.Implementation;

public class GenericServices<T> : IGenericServices<T> where T : class
{
    private readonly IGenericRepository<T> _genericRepository ;
    public GenericServices(IGenericRepository<T> genericRepository)
    {
            this._genericRepository = genericRepository ;
    }
  

    public Task<IEnumerable<T>> GetAll()
    {
        return _genericRepository.GetAll();
    }

   
}
