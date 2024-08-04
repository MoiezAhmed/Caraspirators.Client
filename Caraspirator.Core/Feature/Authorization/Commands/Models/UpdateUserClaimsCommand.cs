using Caraspirator.Data.Entities.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Core.Feature.Authorization.Commands.Models
{
    public class UpdateUserClaimsCommand  : UpdateUserClaimsRequest, IRequest<Response<string>>
    {
    }
}
