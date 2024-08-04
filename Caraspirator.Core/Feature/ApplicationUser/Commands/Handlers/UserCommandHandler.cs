
using Microsoft.AspNetCore.Identity;
using Caraspirator.Data.Entities.Identity;
using Caraspirator.Core.Feature.ApplicationUser.Commands.Models;
using Caraspirator.Core.Feature.ApplicationUser.Queries.Result;

namespace Caraspirator.Core.Feature.ApplicationUser.Commands.Handlers;

internal class UserCommandHandler : ResponseHandler, 
        IRequestHandler<AddUserCommand, Response<string>>,
        IRequestHandler<EditUserCommand, Response<string>>,
     IRequestHandler<DeleteUserCommand, Response<string>>,
      IRequestHandler<ChangeUserPasswordCommand, Response<string>>
{

    private readonly IMapper _mapper;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    private readonly UserManager<EspkUser> _userManager;
    private readonly IApplicationUserService _applicationUserService;
    public UserCommandHandler(IStringLocalizer<SharedResources> stringLocalizer,
                              UserManager<EspkUser> userManager,
                              IMapper mapper,
                              IApplicationUserService applicationUserService) : base(stringLocalizer)
    {
        _userManager = userManager;
        _mapper=mapper;
        _stringLocalizer = stringLocalizer;
        _applicationUserService=applicationUserService;
    }

    public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        var identityUser = _mapper.Map<EspkUser>(request);
        //Create
        var createResult = await _applicationUserService.AddUserAsync(identityUser, request.Password);
        switch (createResult)
        {
            case "EmailIsExist": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.EmailIsExist]);
            case "UserNameIsExist": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.UserNameIsExist]);
            case "ErrorInCreateUser": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FaildToAddUser]);
            case "Failed": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.TryToRegisterAgain]);
            case "Success": return Success<string>("");
            default: return BadRequest<string>(createResult);
        }
    }

    public async Task<Response<string>> Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
        var oldUser = await _userManager.FindByIdAsync(request.Id.ToString());
        if (oldUser == null) { return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.NotFound]); }
        var newUser = _mapper.Map(request, oldUser);
        //if username is Exist
        var userByUserName = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == newUser.UserName && x.Id != newUser.Id);
        //username is Exist
        if (userByUserName != null) return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.UserNameIsExist]);
        var Result = await _userManager.UpdateAsync(newUser);
        if (!Result.Succeeded) { return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.UpdateFailed]); }
        return Success((string)_stringLocalizer[SharedResourcesKeys.Updated]);
       
    }

    public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.Id.ToString());
        if (user == null) { return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.NotFound]); }
        var Result = await _userManager.DeleteAsync(user);
        if (!Result.Succeeded) { return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.DeletedFailed]); }
        return Success((string)_stringLocalizer[SharedResourcesKeys.Deleted]);
    }

    public async Task<Response<string>> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
    {
        //get user
        //check if user is exist
        var user = await _userManager.FindByIdAsync(request.Id.ToString());
        //if Not Exist notfound
        if (user == null) return NotFound<string>();

        //Change User Password
        var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
        //var user1=await _userManager.HasPasswordAsync(user);
        //await _userManager.RemovePasswordAsync(user);
        //await _userManager.AddPasswordAsync(user, request.NewPassword);

        //result
        if (!result.Succeeded) return BadRequest<string>(result.Errors.FirstOrDefault().Description);
        return Success((string)_stringLocalizer[SharedResourcesKeys.Success]);
    }


}
