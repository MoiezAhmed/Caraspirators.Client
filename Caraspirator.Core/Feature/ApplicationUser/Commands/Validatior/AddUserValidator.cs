
using Caraspirator.Core.Feature.ApplicationUser.Commands.Models;

namespace Caraspirator.Core.Feature.ApplicationUser.Commands.Validatior;

public class AddUserValidator:AbstractValidator<AddUserCommand>
{
   
    private readonly IStringLocalizer<SharedResources> _localizer;
    public AddUserValidator( IStringLocalizer<SharedResources> localizer)
    {
     
        ApllyValidationRules();
        ApllyCustomValidationRules();
        _localizer = localizer;
    }


    public void ApllyValidationRules()
    {


        RuleFor(x => x.UserName).NotEmpty().WithMessage("all feild required")
           .NotNull().WithMessage("all feild required");

        RuleFor(x => x.Email).NotEmpty().WithMessage("all feild required")
          .NotNull().WithMessage("all feild required");
        //.Matches("@").WithMessage("");

        RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("all feild required")
        .Equal(x=>x.Password).WithMessage("password and confirmed not matched");
    }
   public  void ApllyCustomValidationRules() 
    {
        //RuleFor(x => x.PhoneNumber)
        //    .MustAsync(async (key, CancellationToken)=>!await _categoryServices.IsCategoryNameExistAsync(key))
        //    .WithMessage("Dear Name Already Exist");
    }
}
