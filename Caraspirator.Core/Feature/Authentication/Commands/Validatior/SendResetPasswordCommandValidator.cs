using Caraspirator.Core.Feature.Authentication.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Core.Feature.Authentication.Commands.Validatior;

public class SendResetPasswordCommandValidator : AbstractValidator<SendResetPasswordCommand>
{
    #region Fields
    private readonly IStringLocalizer<SharedResources> _localizer;
    #endregion

    #region Constructors
    public SendResetPasswordCommandValidator(IStringLocalizer<SharedResources> localizer)
    {
        _localizer = localizer;
        ApplyValidationsRules();
        ApplyCustomValidationsRules();
    }
    #endregion

    #region Actions
    public void ApplyValidationsRules()
    {
        RuleFor(x => x.Email)
             .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
             .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);


    }

    public void ApplyCustomValidationsRules()
    {
    }

    #endregion
}
