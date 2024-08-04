using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Core.Mapping.Users;

public partial class UserProfile : Profile
{
    public UserProfile()
    {
        AddUserMapping();
        GetUserPaginatedListMapping();
        GetUserByIdMapping();
        UpdateUserMapping();
    }
}
