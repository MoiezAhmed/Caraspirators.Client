

namespace Caraspirator.Library.Helper
{
    public class AutoMapperHandler : Profile
    {
        public AutoMapperHandler()
        {
            CreateMap<User, UserDTO>().ForMember(item => item.status, opt => opt.MapFrom(
                item => (item.IsActive) ? "Active" : "In active")).ReverseMap();
            CreateMap<Category, CategoryDTO>().ForMember(item => item.status, opt => opt.MapFrom(
             item => (item.is_active) ? "Active" : "In active")).ReverseMap();
        }
    }
}