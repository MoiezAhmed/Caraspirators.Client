using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Core.Feature.Categories.Queries.Models;

public class GetCategoryByNameQuery : IRequest<Response<GetSingleCategoryResponse>>
{

    public string Name { get; set; }
    public GetCategoryByNameQuery(string _Name)
    {
            Name= _Name;
    }
}
