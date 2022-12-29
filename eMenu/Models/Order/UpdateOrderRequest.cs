using FluentValidation;
using FluentValidation.Results;

namespace eMenu.Models;

public class UpdateOrderRequest
{
#region Model

public DateTime ReadyTime { get; set; }
public DateTime TakenTime { get; set; }

#endregion

#region Validator
public class Validator: AbstractValidator<UpdateOrderRequest>
{
public Validator()
{
    RuleFor(x=>x.ReadyTime)
        .InclusiveBetween(DateTime.MaxValue,DateTime.Today).WithMessage("Date must be before tomorrow");
    RuleFor(x=>x.TakenTime)
        .InclusiveBetween(DateTime.MaxValue,DateTime.Today).WithMessage("Date must be before tomorrow");
}

}
#endregion
}
public static class UpdateOrderRequestExtension
{
public static ValidationResult Validate(this UpdateOrderRequest model)
{
return new UpdateOrderRequest.Validator().Validate(model);
}
}