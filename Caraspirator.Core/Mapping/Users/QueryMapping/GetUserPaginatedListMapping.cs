using Caraspirator.Core.Feature.ApplicationUser.Commands.Models;
using Caraspirator.Core.Feature.ApplicationUser.Queries.Result;
using Caraspirator.Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Core.Mapping.Users;

public partial class UserProfile
{
    public void GetUserPaginatedListMapping()
    {
        CreateMap<EspkUser,GetUserPaginationListReponse> ();
    }
}