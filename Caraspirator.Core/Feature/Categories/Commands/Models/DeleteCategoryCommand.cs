using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Core.Feature.Categories.Commands.Models
{
    public class DeleteCategoryCommand:IRequest<Response<string>>
    {
        public int id { get; set; }
        public DeleteCategoryCommand(int _id)
        {
            id = _id;
        }
    }
}
