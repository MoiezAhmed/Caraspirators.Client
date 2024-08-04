using Caraspirator.Core.Feature.ApplicationUser.Queries.Result;
namespace Caraspirator.Core.Feature.ApplicationUser.Queries.Models;
public class GetUserPaginationQuery: IRequest<PaginatedResult<GetUserPaginationListReponse>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
