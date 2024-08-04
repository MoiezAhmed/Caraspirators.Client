using Caraspirator.Core.Feature.Authorization.Commands.Models;
using Caraspirator.Core.Feature.Emails.Commands.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarSpirators.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmailsController : AppControllerBase
{

    [HttpPost(Router.EmailsRoute.SendEmail)]
    public async Task<IActionResult> SendEmail([FromForm] SendEmailCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
}