using Caraspirator.Core.Feature.Cars.Queries.Result;
using Caraspirator.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Core.Feature.Cars.Queries.Models;

public class GetCarPartByCarIdQuery : IRequest<Response<GetSingleCarResponse>>
{
    public int id { get; set; }
    public int partPageNumber { get; set; }
    public int partPageSize { get; set; }
  
}
