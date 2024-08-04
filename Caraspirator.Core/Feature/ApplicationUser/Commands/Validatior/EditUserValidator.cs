using Caraspirator.Core.Feature.ApplicationUser.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Core.Feature.ApplicationUser.Commands.Validatior;

public class EditUserValidator : AbstractValidator<EditUserCommand>
{

    private readonly IStringLocalizer<SharedResources> _localizer;
    public EditUserValidator(IStringLocalizer<SharedResources> localizer)
    {

        ApllyValidationRules();
        ApllyCustomValidationRules();
        _localizer = localizer;
    }


    public void ApllyValidationRules()
    {
        RuleFor(x => x.FullName).NotEmpty().WithMessage("all feild required")
            .NotNull().WithMessage("all feild required")
            .MaximumLength(100).WithMessage("all feild required");

        RuleFor(x => x.UserName).NotEmpty().WithMessage("all feild required")
           .NotNull().WithMessage("all feild required");

        RuleFor(x => x.Email).NotEmpty().WithMessage("all feild required")
          .NotNull().WithMessage("all feild required");
        //.Matches("@").WithMessage("");

       
    }
    public void ApllyCustomValidationRules()
    {
        //RuleFor(x => x.PhoneNumber)
        //    .MustAsync(async (key, CancellationToken)=>!await _categoryServices.IsCategoryNameExistAsync(key))
        //    .WithMessage("Dear Name Already Exist");
    }
}
