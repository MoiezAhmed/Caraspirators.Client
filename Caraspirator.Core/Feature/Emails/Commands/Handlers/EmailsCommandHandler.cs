using Caraspirator.Core.Feature.Emails.Commands.Models;
using MailKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Core.Feature.Emails.Commands.Handlers;

public class EmailsCommandHandler : ResponseHandler,
    IRequestHandler<SendEmailCommand, Response<string>>
{
    #region Fields
    private readonly IEmailsService _emailsService;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    #endregion
    #region Constructors
    public EmailsCommandHandler(IStringLocalizer<SharedResources> stringLocalizer,
                                IEmailsService emailsService) : base(stringLocalizer)
    {
        _emailsService = emailsService;
        _stringLocalizer = stringLocalizer;
    }

    public async Task<Response<string>> Handle(SendEmailCommand request, CancellationToken cancellationToken)
    {
        var response = await _emailsService.SendEmail(request.Email, request.Message, null);
        if (response == "Success")
            return Success<string>("");
        return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.SendEmailFailed]);
    }
    #endregion
}
