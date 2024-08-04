using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Core.Feature.Authorization.Commands.Models
{
    public class DeleteRoleCommand:  IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteRoleCommand(int id)
        {
                Id = id;
        }
    }
}
