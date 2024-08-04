


using Caraspirator.Core.Feature.Authentication.Commands.Models;

namespace Caraspirator.Core.Feature.Authentication.Commands.Validatior;

public class SignInValidators:AbstractValidator<SignInCommand>
{
   
    private readonly IStringLocalizer<SharedResources> _localizer;
    public SignInValidators( IStringLocalizer<SharedResources> localizer)
    {
     
        ApllyValidationRules();
        //ApllyCustomValidationRules();
        _localizer = localizer;
    }


    public void ApllyValidationRules()
    {
        RuleFor(x => x.UserName)
                 .NotEmpty().WithMessage("fg")
                 .NotNull().WithMessage("fg");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("fg")
            .NotNull().WithMessage("fg");


    }
   public  void ApllyCustomValidationRules() 
    {
        //RuleFor(x => x.PhoneNumber)
        //    .MustAsync(async (key, CancellationToken)=>!await _categoryServices.IsCategoryNameExistAsync(key))
        //    .WithMessage("Dear Name Already Exist");
    }
}
