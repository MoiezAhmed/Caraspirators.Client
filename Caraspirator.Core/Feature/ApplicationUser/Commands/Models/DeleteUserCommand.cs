using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Core.Feature.ApplicationUser.Commands.Models;
public class DeleteUserCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
    public DeleteUserCommand(int id)
    {
        Id = id;
    }
}
