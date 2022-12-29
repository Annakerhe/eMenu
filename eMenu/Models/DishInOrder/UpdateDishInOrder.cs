using FluentValidation;
using FluentValidation.Results;

namespace eMenu.Models;

public class UpdateDishInOrderRequest
{
#region Model

public int Amount { get; set; }


#endregion

#region Validator
public class Validator: AbstractValidator<UpdateDishInOrderRequest>
{
public Validator()
{
    RuleFor(x=>x.Amount)
        .NotEmpty().WithMessage("Length must be > 0");

}
}
#endregion
}
public static class UpdateDishInOrderequestExtension
{
public static ValidationResult Validate(this UpdateDishInOrderRequest model)
{
return new UpdateDishInOrderRequest.Validator().Validate(model);
}
}