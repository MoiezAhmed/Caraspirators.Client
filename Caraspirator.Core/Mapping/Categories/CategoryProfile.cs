
namespace Caraspirator.Core.Mapping.Categories;

public partial class CategoryProfile:Profile
{
    public CategoryProfile()
    {
        GetCategoriesListMapping();
        GetCategoryByNameMapping();
        AddCategoryCommandMapping();
        EditCategoryCommandMapping();
    }
}
