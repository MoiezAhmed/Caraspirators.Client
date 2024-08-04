using Caraspirator.Core.Feature.Authorization.Commands.Models;
using Caraspirator.Core.Feature.Authorization.Queries.Models;
using Caraspirator.Core.Features.Authentication.Queries.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;


namespace CarSpirators.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles ="Admin")]
public class AuthorizationController : AppControllerBase
{
    [HttpPost(Router.AuthorizationRouting.Create)]
    public async Task<IActionResult> Create([FromForm] AddRoleCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }

    [HttpPost(Router.AuthorizationRouting.Edit)]
    public async Task<IActionResult> Edit([FromForm] EditRoleCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }

    [HttpPost(Router.AuthorizationRouting.Delete)]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var response = await _mediator.Send(new DeleteRoleCommand(id));
        return NewResult(response);
    }

 

    [HttpGet(Router.AuthorizationRouting.RoleList)]
    public async Task<IActionResult> GetRoleList()
    {
        var response = await _mediator.Send(new GetRolesListQuery());
        return NewResult(response);
    }


    [HttpGet(Router.AuthorizationRouting.GetRoleById)]
    public async Task<IActionResult> GetRoleById([FromRoute] int id)
    {
        var response = await _mediator.Send(new GetRoleByIdQuery() { Id = id });
        return NewResult(response);
    }

   
    [HttpGet(Router.AuthorizationRouting.ManageUserRoles)]
    public async Task<IActionResult> ManageUserRoles([FromRoute] int userId)
    {
        var response = await _mediator.Send(new ManageUserRolesQuery() { UserId = userId });
        return NewResult(response);
    }

    //[SwaggerOperation(Summary = " تعديل صلاحيات المستخدمين", OperationId = "UpdateUserRoles")]
    [HttpPut(Router.AuthorizationRouting.UpdateUserRoles)]
    [Authorize(Policy = "CreateStudent")]
    public async Task<IActionResult> UpdateUserRoles([FromBody] UpdateUserRolesCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }

   
    [HttpGet(Router.AuthorizationRouting.ManageUserClaims)]
    public async Task<IActionResult> ManageUserClaims([FromRoute] int userId)
    {
        var response = await _mediator.Send(new ManageUserClaimsQuery() { UserId = userId });
        return NewResult(response);
    }

   
    [HttpPut(Router.AuthorizationRouting.UpdateUserClaims)]
    [Authorize(Policy = "UpdateUserClaims")]
    public async Task<IActionResult> UpdateUserClaims([FromBody] UpdateUserClaimsCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
}
