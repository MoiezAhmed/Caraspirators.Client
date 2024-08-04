using Caraspirator.Core.Feature.Authorization.Commands.Models;


namespace Caraspirator.Core.Feature.Authorization.Commands.Validatior
{
    public class AddRoleValidators:AbstractValidator<AddRoleCommand>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IAuthorizationService _authorizationService;
        public AddRoleValidators(IStringLocalizer<SharedResources> stringLocalizer,
                                 IAuthorizationService authorizationService)
        {
            _authorizationService=authorizationService;
            _stringLocalizer= stringLocalizer;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }

        public void ApplyValidationsRules()
        {
            RuleFor(x => x.RoleName)
                 .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required]);
        }

        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.RoleName)
                .MustAsync(async (Key, CancellationToken) => !await _authorizationService.IsRoleExistByName(Key))
                .WithMessage(_stringLocalizer[SharedResourcesKeys.IsExist]);
        }

    }
}
