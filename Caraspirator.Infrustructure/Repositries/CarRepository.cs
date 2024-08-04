using Caraspirator.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Caraspirator.Infrustructure.Repositries;

public class CarRepository : GenericRepositoryAsync<Car>, ICarRepository
{
    private readonly DbSet<Car> _car;
    public CarRepository(AppDbContext dbContext) : base(dbContext)
    {
        _car = dbContext.Set<Car>();
    }
    public async Task<Car> GetCarByNameAsync(string name)
    {
        var car = await _car.Where(c => c.CarModel.Equals(name, StringComparison.OrdinalIgnoreCase))
                                     .FirstOrDefaultAsync();
        return car;
    }

    public async Task<Car> GetCarPartListAsync(int carid)
    {
        var car = await _car.Where(c => c.CarID == carid)
       .Include(c => c.CarPart) // Eagerly load the CarParts collection
        .ThenInclude(cp => cp.Part)   // Include the related Part entities       
        .FirstOrDefaultAsync();
       
        // Access the car's parts through the CarParts collection
        //var parts = car.CarPart.Select(cp => cp.Part);
        return car;
    }

    public async Task<IEnumerable<Car>> GetCarsListAsync()
    {
     return await _car.ToListAsync();
    }
}
