

namespace Caraspirator.Core.Mapping.Categories;

public partial class CategoryProfile : Profile
{
    public void EditCategoryCommandMapping()
    {


        CreateMap<EditCategoryCommand, Category>().ForMember(item => item.CategoryImage, opt => opt.MapFrom(
         item => (item.categoryimage))).ReverseMap();
        CreateMap<EditCategoryCommand, Category>().ForMember(item => item.CategoryID, opt => opt.MapFrom(
       item => (item.id))).ReverseMap();

    }
}
