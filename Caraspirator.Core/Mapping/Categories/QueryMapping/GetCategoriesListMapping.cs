

namespace Caraspirator.Core.Mapping.Categories;

public partial class CategoryProfile
{
  public void GetCategoriesListMapping()
    {

        CreateMap<Category, GetCategoryPaginatedListResponse>()
             .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.CategoryName))
             .ForMember(dest => dest.CategoryImage, opt => opt.MapFrom(src => src.CategoryImage))
             .ForMember(dest => dest.ParentID, opt => opt.MapFrom(src => src.ParentID))
             .ForMember(dest => dest.createdate, opt => opt.MapFrom(src => src.CreatedAt))
             .ForMember(dest => dest.updatedat, opt => opt.MapFrom(src => src.UpdatedAt))
             .ReverseMap();
        //             .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Localize(src.CategoryTrans.LastOrDefault().CategorytransName, src.CategoryTrans.FirstOrDefault().CategorytransName)))

        //.ForMember(item => item.status, opt => opt.MapFrom(item => (item.IsActive) ? "Active" : "In active"))
    }


}
