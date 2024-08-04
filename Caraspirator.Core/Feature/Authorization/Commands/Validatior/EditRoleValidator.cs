using Caraspirator.Core.Feature.Authorization.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Core.Feature.Authorization.Commands.Validatior;

internal class EditRoleValidator : AbstractValidator<EditRoleCommand>
{
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    private readonly IAuthorizationService _authorizationService;
    public EditRoleValidator(IStringLocalizer<SharedResources> stringLocalizer,
                             IAuthorizationService authorizationService)
    {
        _authorizationService = authorizationService;
        _stringLocalizer = stringLocalizer;
        ApplyValidationsRules();
        ApplyCustomValidationsRules();
    }

    public void ApplyValidationsRules()
    {
        RuleFor(x => x.Id)
                    .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                    .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required]);

        RuleFor(x => x.Name)
             .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
             .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required]);
    }

    public void ApplyCustomValidationsRules()
    {
      
    }

}

