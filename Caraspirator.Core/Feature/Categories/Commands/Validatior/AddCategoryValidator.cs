

namespace Caraspirator.Core.Feature.Categories.Commands.Validatior;

public class AddUserValidator:AbstractValidator<AddCategoryCommand>
{
    private readonly ICategoryServices _categoryServices;
    private readonly IStringLocalizer<SharedResources> _localizer;
    public AddUserValidator(ICategoryServices categoryServices, IStringLocalizer<SharedResources> localizer)
    {
        _categoryServices = categoryServices;
        ApllyValidationRules();
        ApllyCustomValidationRules();
        _localizer = localizer;
    }


    public void ApllyValidationRules()
    {
        RuleFor(x => x.category_name).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
            .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
            .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis100]);

        RuleFor(x => x.categoryimage).NotEmpty().WithMessage("Image can not be epmty")
           .NotNull().WithMessage("Image can not be epmty");
    }
   public  void ApllyCustomValidationRules() 
    {
        RuleFor(x => x.category_name)
            .MustAsync(async (key, CancellationToken)=>!await _categoryServices.IsCategoryNameExistAsync(key))
            .WithMessage("Dear Name Already Exist");
    }
}
