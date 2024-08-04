﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Core.Feature.ApplicationUser.Commands.Models;

public class AddUserCommand : IRequest<Response<string>>
{
    public string? FullName { get; set; }
    public string? Address { get; set; }
    public string? Country { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string ConfirmPassword { get; set; }
    public string? PhoneNumber { get; set; }

}