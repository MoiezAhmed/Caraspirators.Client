

using Caraspirator.Core.Feature.ApplicationUser.Commands.Models;
using Caraspirator.Core.Feature.ApplicationUser.Queries.Models;
using Caraspirator.Core.Feature.ApplicationUser.Queries.Result;
using Caraspirator.Core.Feature.Cars.Queries.Models;
using Caraspirator.Core.Feature.Cars.Queries.Result;
using Caraspirator.Data.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Caraspirator.Core.Feature.ApplicationUser.Queries.Handlers;

public class UserQueryHandler : ResponseHandler,
      IRequestHandler<GetUserPaginationQuery, PaginatedResult<GetUserPaginationListReponse>>,
      IRequestHandler<GetUserByIdQuery, Response<GetSingleUserResponse>>
{
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    private readonly UserManager<EspkUser> _userManager;
    public UserQueryHandler(IStringLocalizer<SharedResources> stringLocalizer, IMapper mapper, UserManager<EspkUser> userManager) : base(stringLocalizer)
    {
        _userManager = userManager;
        _mapper = mapper;
        _stringLocalizer = stringLocalizer;
    }

    public async Task<PaginatedResult<GetUserPaginationListReponse>> Handle(GetUserPaginationQuery request, CancellationToken cancellationToken)
    {
        var user= _userManager.Users.AsQueryable();
        var PaginatedList =await _mapper.ProjectTo<GetUserPaginationListReponse>(user).ToPaginatedListAsync(request.PageNumber, request.PageSize); ;
       return PaginatedList;
    }

    public async Task<Response<GetSingleUserResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
         //var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id==request.Id);
        var user = await _userManager.FindByIdAsync(request.Id.ToString());
        if (user == null) return NotFound<GetSingleUserResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);
        var result = _mapper.Map<GetSingleUserResponse>(user);
        return Success(result);
    }
}
