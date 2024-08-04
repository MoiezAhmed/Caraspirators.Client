using Caraspirator.Core.Feature.Authentication.Queries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Core.Feature.Authentication.Queries.Validators;

public class ConfirmEmailValidator : AbstractValidator<ConfirmEmailQuery>
{
    #region Fields
    private readonly IStringLocalizer<SharedResources> _localizer;
    #endregion

    #region Constructors
    public ConfirmEmailValidator(IStringLocalizer<SharedResources> localizer)
    {
        _localizer = localizer;
        ApplyValidationsRules();
        ApplyCustomValidationsRules();
    }
    #endregion

    #region Actions
    public void ApplyValidationsRules()
    {
        RuleFor(x => x.UserId)
             .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
             .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);

        RuleFor(x => x.Code)
            .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
            .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
    }

    public void ApplyCustomValidationsRules()
    {
    }

    #endregion
}
