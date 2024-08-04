using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Caraspirator.Services.Implementation;

public class CarServices : ICarServices
{

    private readonly ICarRepository _carRepository ;
    public CarServices(ICarRepository carRepository)
    {
        this._carRepository = carRepository;
    }


    public Task<Car> GetCarListAsync()
    {
    //    var car = _carRepository.GetCarPartListAsync(id);
        return null;
    }

    public async Task<Car> GetCarPartListAsync(int id)
    {
        var car = await _carRepository.GetTableNoTracking().Where(c => c.CarID .Equals(id))                                        
                                                      .FirstOrDefaultAsync();
        return car;
  
    }

  
    public Task<Part> GetPartByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}
