using Caraspirator.Data.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Core.Feature.Authorization.Queries.Models;

public class ManageUserClaimsQuery : IRequest<Response<ManageUserClaimsResult>>
{
    public int UserId { get; set; }
}
