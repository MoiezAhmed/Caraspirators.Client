

using Caraspirator.Data.Enums;

namespace Caraspirator.Core.Feature.Categories.Queries.Models;

public class GetCategoryPaginatedListQuery:IRequest<PaginatedResult<GetCategoryPaginatedListResponse>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public StudentOrderingEnum OrderBy { get; set; }
    public string? Search { get; set; }

}
