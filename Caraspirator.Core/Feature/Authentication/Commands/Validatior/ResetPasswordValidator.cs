using Caraspirator.Core.Feature.Authentication.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Core.Feature.Authentication.Commands.Validatior;

public class ResetPasswordValidator : AbstractValidator<ResetPasswordCommand>
{
    #region Fields
    private readonly IStringLocalizer<SharedResources> _localizer;
    #endregion

    #region Constructors
    public ResetPasswordValidator(IStringLocalizer<SharedResources> localizer)
    {
        _localizer = localizer;
        ApplyValidationsRules();
        ApplyCustomValidationsRules();
    }
    #endregion

    #region Handle Functions
    public void ApplyValidationsRules()
    {
        RuleFor(x => x.Email)
             .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
             .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
        RuleFor(x => x.Password)
             .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
             .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
        RuleFor(x => x.ConfirmPassword)
             .Equal(x => x.Password).WithMessage(_localizer[SharedResourcesKeys.PasswordNotEqualConfirmPass]);

    }

    public void ApplyCustomValidationsRules()
    {

    }

    #endregion
}
