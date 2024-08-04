

using Caraspirator.Core.Feature.ApplicationUser.Commands.Models;
using Caraspirator.Data.Entities.Identity;

namespace Caraspirator.Core.Mapping.Users;

public partial class UserProfile
{
    public void UpdateUserMapping()
    {
        CreateMap<EditUserCommand, EspkUser>();
    }
}
