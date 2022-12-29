using FluentValidation;
using FluentValidation.Results;

namespace eMenu.Models;

public class UpdateTableRequest
{
    #region Model

   public string Location { get; set; }

    #endregion

    #region Validator

    public class Validator : AbstractValidator<UpdateTableRequest>
    {
        public Validator()
        {
           RuleFor(x => x.Location)
                .MaximumLength(255).WithMessage("Length must be less than 256");               
        }
    }

    #endregion
}

public static class UpdateTableRequestExtension
{
    public static ValidationResult Validate(this UpdateTableRequest model)
    {
        return new UpdateTableRequest.Validator().Validate(model);
    }
}