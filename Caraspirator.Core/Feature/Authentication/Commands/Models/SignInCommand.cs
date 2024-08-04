using Caraspirator.Data.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Core.Feature.Authentication.Commands.Models;

public class SignInCommand : IRequest<Response<JwtAuthResult>>
{
    public string? UserName { get; set; }
    public string? Password { get; set; }
}