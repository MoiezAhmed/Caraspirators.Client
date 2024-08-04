using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Core.Feature.Categories.Queries.Models
{
    public class GetCategoryByIdQuery:  IRequest<Response<GetSingleCategoryResponse>>
    {
        public int id { get; set; }

        public GetCategoryByIdQuery(int _id)
        {
            this.id = _id;
        }

      
    }
}
