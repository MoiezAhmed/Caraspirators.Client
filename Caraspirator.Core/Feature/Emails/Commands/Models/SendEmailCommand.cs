using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Core.Feature.Emails.Commands.Models;

public class SendEmailCommand : IRequest<Response<string>>
{
    public string Email { get; set; }
    public string Message { get; set; }
}