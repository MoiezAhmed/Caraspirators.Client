
namespace Caraspirator.Core.Feature.Categories.Queries.Models;

public class GetSubCategoryPaginatedListQuery : IRequest<PaginatedResult<GetCategoryPaginatedListResponse>>
{
    public int Id { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string[]? OrderBy { get; set; }
    public string? Search { get; set; }
   
}
