
namespace Caraspirator.Core.Feature.Categories.Queries.Result;

public class GetCategoryListResponse
{
    [Key]
    public int CategoryID { get; set; }
    public string? CategoryName { get; set; }
    public string? CategoryImage { get; set; }
    public int ParentID { get; set; }

    public bool? IsActive { get; set; }

    public string? Slug { get; set; }

    public DateTime createdate { get; set; }

    public DateTime updatedat { get; set; }

}
