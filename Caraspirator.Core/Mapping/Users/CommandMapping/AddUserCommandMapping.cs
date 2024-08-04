
using Caraspirator.Core.Feature.ApplicationUser.Commands.Models;
using Caraspirator.Data.Entities.Identity;

namespace Caraspirator.Core.Mapping.Users;
public partial class UserProfile
{
    public void AddUserMapping()
    {
        CreateMap<AddUserCommand, EspkUser>();
             //.ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
             //.ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
             //.ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
             //.ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
             //.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
             //.ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));
      
    }
}
