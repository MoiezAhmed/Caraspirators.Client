using Caraspirator.Core.Feature.ApplicationUser.Queries.Models;
using Caraspirator.Core.Feature.ApplicationUser.Queries.Result;
using Caraspirator.Core.Feature.Authorization.Queries.Models;
using Caraspirator.Core.Feature.Authorization.Queries.Result;
using Caraspirator.Data.Entities.Identity;
using Caraspirator.Data.Results;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Core.Feature.Authorization.Queries.Handlers;

public class RoleQueryHandler : ResponseHandler,
     IRequestHandler<GetRolesListQuery, Response<List<GetRolesListResult>>>,
       IRequestHandler<GetRoleByIdQuery, Response<GetRoleByIdResult>>,
       IRequestHandler<ManageUserRolesQuery, Response<ManageUserRolesResult>>
{

    #region Fields
    private readonly IAuthorizationService _authorizationService;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    private readonly UserManager<EspkUser> _userManager;
    #endregion
    #region Constructors
    public RoleQueryHandler(IStringLocalizer<SharedResources> stringLocalizer,
                            IAuthorizationService authorizationService,
                            IMapper mapper,
                            UserManager<EspkUser> userManager) : base(stringLocalizer)
    {
        _authorizationService = authorizationService;
        _mapper = mapper;
        _stringLocalizer = stringLocalizer;
        _userManager = userManager;
    }
    #endregion

    public async Task<Response<List<GetRolesListResult>>> Handle(GetRolesListQuery request, CancellationToken cancellationToken)
    {
        var roles = await _authorizationService.GetRolesList();
        var result = _mapper.Map<List<GetRolesListResult>>(roles);
        return Success(result);
    }

    public async Task<Response<GetRoleByIdResult>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        var role = await _authorizationService.GetRoleById(request.Id);
        if (role == null) return NotFound<GetRoleByIdResult>(_stringLocalizer[SharedResourcesKeys.RoleNotExist]);
        var result = _mapper.Map<GetRoleByIdResult>(role);
        return Success(result);
    }

    public async Task<Response<ManageUserRolesResult>> Handle(ManageUserRolesQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.UserId.ToString());
        if (user == null) return NotFound<ManageUserRolesResult>(_stringLocalizer[SharedResourcesKeys.UserIsNotFound]);
        var result = await _authorizationService.ManageUserRolesData(user);
        return Success(result);
    }
}
