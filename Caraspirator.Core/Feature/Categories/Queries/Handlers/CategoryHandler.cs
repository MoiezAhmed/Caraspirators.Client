
using Caraspirator.Core.Feature.ApplicationUser.Queries.Models;
using Caraspirator.Core.Feature.ApplicationUser.Queries.Result;
using Microsoft.AspNetCore.Identity;

namespace Caraspirator.Core.Feature.User.Queries.Handlers;

public class CategoryHandler :ResponseHandler,
      IRequestHandler<GetCategoryPaginatedListQuery, PaginatedResult<GetCategoryPaginatedListResponse>>
{
    private readonly ICategoryServices _categoryService;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    public CategoryHandler(ICategoryServices categoryService, IMapper mapper, IStringLocalizer<SharedResources> stringLocalizer):base(stringLocalizer)
    {
        this._categoryService = categoryService;
        this._mapper = mapper;
        this._stringLocalizer = stringLocalizer;
    }

    public async Task<PaginatedResult<GetCategoryPaginatedListResponse>> Handle(GetCategoryPaginatedListQuery request, CancellationToken cancellationToken)
    {
        //Expression<Func<Student, GetStudentPaginatedListResponse>> expression = e => new GetStudentPaginatedListResponse(e.StudID, e.Localize(e.NameAr, e.NameEn), e.Address, e.Department.Localize(e.Department.DNameAr, e.Department.DNameEn));
        var FilterQuery = _categoryService.FilterCategoriesPaginatedQueryable(request.OrderBy, request.Search);
        var PaginatedList = await _mapper.ProjectTo<GetCategoryPaginatedListResponse>(FilterQuery).ToPaginatedListAsync(request.PageNumber, request.PageSize);
        PaginatedList.Meta = new { Count = PaginatedList.Data.Count() };
        return PaginatedList;
    }
}
