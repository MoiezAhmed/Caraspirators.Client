using Caraspirator.Core.Feature.ApplicationUser.Commands.Models;
using Caraspirator.Core.Feature.ApplicationUser.Queries.Models;
using Caraspirator.Core.Feature.Categories.Queries.Models;
using Caraspirator.Data.AppMetaData;
using CarSpirators.API.Base;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarSpirators.API.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class UserController : AppControllerBase
{

    private readonly IGenericRepository<newUser> _userService;

    private readonly IMapper _mapper;
    public UserController(IGenericRepository<newUser> userService, IMapper mapper)
    {
        this._userService = userService;
        this._mapper = mapper;
    }

    [HttpGet("getcategories")]
    public async Task<IActionResult> GetCategoriesAsync()
    {
        var data = await _userService.GetAll();
        var response = _mapper.Map<IEnumerable<newUser>, List<CategoryDTO>>(data);
        return Ok(response);
    }



    [HttpPost]
    public async Task<IActionResult> Register([FromBody] newUser user)
    {
        var data = await _userService.Add(user);

       // var response = _mapper.Map<IEnumerable<User>, List<CategoryDTO>>(data);
        return Ok(data);
    }

    [HttpPost(Router.UsersRouter.Create)]
    public async Task<IActionResult> AddRegister([FromBody] AddUserCommand command)
    {
        return NewResult(await _mediator.Send(command));

        // var response = _mapper.Map<IEnumerable<User>, List<CategoryDTO>>(data);
      
    }

    [HttpGet(Router.UsersRouter.Paginated)]
    public async Task<IActionResult> Paginated([FromQuery] GetUserPaginationQuery query)
    {
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpGet(Router.UsersRouter.GetByID)]
    public async Task<IActionResult> GetUserByID([FromRoute] int id)
    {
        return NewResult(await _mediator.Send(new GetUserByIdQuery(id)));
    }

    [HttpGet(Router.UsersRouter.Edit)]
    public async Task<IActionResult> Edit([FromBody] EditUserCommand command)
    {
        return NewResult(await _mediator.Send(command));
    }
   
    [HttpDelete(Router.UsersRouter.Delete)]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        return NewResult(await _mediator.Send(new DeleteUserCommand(id)));
    }
    [HttpPut(Router.UsersRouter.ChangePassword)]
    public async Task<IActionResult> ChangePassword([FromBody] ChangeUserPasswordCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
}
