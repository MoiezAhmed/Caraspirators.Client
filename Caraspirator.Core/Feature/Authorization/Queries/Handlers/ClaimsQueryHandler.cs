using Caraspirator.Core.Feature.Authorization.Queries.Models;
using Caraspirator.Data.Entities.Identity;
using Caraspirator.Data.Results;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Core.Feature.Authorization.Queries.Handlers;

public class ClaimsQueryHandler : ResponseHandler,
    IRequestHandler<ManageUserClaimsQuery, Response<ManageUserClaimsResult>>
{
    private readonly IAuthorizationService _authorizationService;
    private readonly UserManager<EspkUser> _userManager;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;

    public ClaimsQueryHandler(IStringLocalizer<SharedResources> stringLocalizer,
                                     IAuthorizationService authorizationService,
                                     UserManager<EspkUser> userManager) : base(stringLocalizer)
    {
        _authorizationService = authorizationService;
        _userManager = userManager;
        _stringLocalizer = stringLocalizer;
    }
    public async Task<Response<ManageUserClaimsResult>> Handle(ManageUserClaimsQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.UserId.ToString());
        if (user == null) return NotFound<ManageUserClaimsResult>(_stringLocalizer[SharedResourcesKeys.UserIsNotFound]);
        var result = await _authorizationService.ManageUserClaimData(user);
        return Success(result);
    }
}

