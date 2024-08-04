using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Services.Abstracts
{
    public interface ICarServices
    {
        Task<Part> GetPartByIdAsync(int id);

        Task<Car> GetCarPartListAsync(int id);
    }
}
