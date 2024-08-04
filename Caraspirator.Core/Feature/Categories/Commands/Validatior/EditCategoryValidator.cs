using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Core.Feature.Categories.Commands.Validatior;

public class EditUserValidator:AbstractValidator<EditCategoryCommand>
{ 
   public EditUserValidator()
{
    ApllyValidationRules();
}


public void ApllyValidationRules()
{
 
        RuleFor(x => x.id).NotEmpty().WithMessage("Id can not be epmty")
         .NotNull().WithMessage("Image can not be epmty");

        RuleFor(x => x.categoryimage).NotEmpty().WithMessage("Image can not be epmty")
       .NotNull().WithMessage("Image can not be epmty");
}
public void ApllyCustomValidationRules()
{

}


}
