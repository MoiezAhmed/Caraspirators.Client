using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Infrustructure.Abstracts;

public interface ICarRepository : IGenericRepositoryAsync<Car>
{
    Task<IEnumerable<Car>> GetCarsListAsync();
    Task<Car> GetCarByNameAsync(string id);

    Task<Car> GetCarPartListAsync(int id);
}
