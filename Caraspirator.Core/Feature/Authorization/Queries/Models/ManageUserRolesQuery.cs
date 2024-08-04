using Caraspirator.Data.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Core.Feature.Authorization.Queries.Models
{
    public class ManageUserRolesQuery:IRequest<Response<ManageUserRolesResult>>
    {
        public int UserId { get; set; }
    }
}
