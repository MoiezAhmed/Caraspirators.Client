

namespace Caraspirator.Core.Feature.Categories.Queries.Models;

public class GetSubCategoryListQuery : IRequest<Response<List<GetCategoryListResponse>>>
{
    public int id { get; set; }
    public GetSubCategoryListQuery(int _id)
    {
        this.id = _id;
    }
}
