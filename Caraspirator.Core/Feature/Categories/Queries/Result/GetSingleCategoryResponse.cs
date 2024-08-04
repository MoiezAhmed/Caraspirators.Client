
namespace Caraspirator.Core.Feature.Categories.Queries.Result;

public class GetSingleCategoryResponse
{
    public int category_id { get; set; }
    public string? categoryname { get; set; }
    public string? categoryimage { get; set; }
    public int parentid { get; set; }
    public string? slug { get; set; }
    public DateTime createdate { get; set; }
    public DateTime updatedat { get; set; }
    public string? status { get; set; }

}
