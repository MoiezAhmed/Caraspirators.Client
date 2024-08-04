

namespace Caraspirator.Core.Mapping.Categories;

public partial class CategoryProfile : Profile
{
    public void AddCategoryCommandMapping()
    {
      

        CreateMap<AddCategoryCommand, Category>().ForMember(item => item.CategoryImage, opt => opt.MapFrom(
      item => (item.categoryimage))).ReverseMap();
    }
}
