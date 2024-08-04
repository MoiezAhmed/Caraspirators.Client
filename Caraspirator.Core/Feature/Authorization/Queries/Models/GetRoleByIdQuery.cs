using Caraspirator.Core.Feature.Authorization.Queries.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Core.Feature.Authorization.Queries.Models;

public class GetRoleByIdQuery : IRequest<Response<GetRoleByIdResult>>
{
    public int Id { get; set; }
}