

namespace Caraspirator.Core.Mapping.Categories;

public partial class CategoryProfile
{
    public void GetCategoryByNameMapping()
    {

        CreateMap<Category, GetSingleCategoryResponse>()
           .ForMember(dest => dest.categoryname, opt => opt.MapFrom(src => src.CategoryName))
           .ForMember(dest => dest.categoryimage, opt => opt.MapFrom(src => src.CategoryImage))
           .ForMember(dest => dest.parentid, opt => opt.MapFrom(src => src.ParentID))
           .ForMember(dest => dest.createdate, opt => opt.MapFrom(src => src.CreatedAt))
           .ForMember(dest => dest.updatedat, opt => opt.MapFrom(src => src.UpdatedAt))
           .ForMember(item => item.status, opt => opt.MapFrom(
              item => (item.IsActive) ? "Active" : "In active")).ReverseMap();
    }


}
