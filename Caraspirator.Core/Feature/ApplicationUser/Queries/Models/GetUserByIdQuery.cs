using Caraspirator.Core.Feature.ApplicationUser.Queries.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Core.Feature.ApplicationUser.Queries.Models;

public class GetUserByIdQuery : IRequest<Response<GetSingleUserResponse>>
{
    public int Id { get; set; }
    public GetUserByIdQuery(int _id)
    {
        this.Id = _id;
    }
}
