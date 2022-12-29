using FluentValidation;
using FluentValidation.Results;

namespace eMenu.Models;

public class UpdateUserRequest
{
#region Model
public string Login {get;set;}

#endregion

#region Validator
public class Validator: AbstractValidator<UpdateUserRequest>
{
public Validator()
{
RuleFor(x=>x.Login)
.MaximumLength(255).WithMessage("Length must be less than 256")
.MinimumLength(4).WithMessage("Length must be less than 3");
}

}
#endregion
}
public static class UpdateUserRequestExtension
{
public static ValidationResult Validate(this UpdateUserRequest model)
{
return new UpdateUserRequest.Validator().Validate(model);
}
}