﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Core.Feature.Authentication.Commands.Models;

public class SendResetPasswordCommand : IRequest<Response<string>>
{
    public string Email { get; set; }
}
