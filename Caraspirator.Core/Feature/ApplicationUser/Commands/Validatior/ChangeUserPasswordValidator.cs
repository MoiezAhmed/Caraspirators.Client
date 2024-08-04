using Caraspirator.Core.Feature.ApplicationUser.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Core.Feature.ApplicationUser.Commands.Validatior;

internal class ChangeUserPasswordValidator : AbstractValidator<ChangeUserPasswordCommand>
{

    private readonly IStringLocalizer<SharedResources> _localizer;
    public ChangeUserPasswordValidator(IStringLocalizer<SharedResources> localizer)
    {

        ApllyValidationRules();
        ApllyCustomValidationRules();
        _localizer = localizer;
    }


    public void ApllyValidationRules()
    {
        RuleFor(x => x.Id)
               .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
               .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);

        RuleFor(x => x.CurrentPassword)
             .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
             .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
        RuleFor(x => x.NewPassword)
             .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
             .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
        RuleFor(x => x.ConfirmPassword)
             .Equal(x => x.NewPassword).WithMessage(_localizer[SharedResourcesKeys.PasswordNotEqualConfirmPass]);
    }
    public void ApllyCustomValidationRules()
    {
        //RuleFor(x => x.PhoneNumber)
        //    .MustAsync(async (key, CancellationToken)=>!await _categoryServices.IsCategoryNameExistAsync(key))
        //    .WithMessage("Dear Name Already Exist");
    }
}