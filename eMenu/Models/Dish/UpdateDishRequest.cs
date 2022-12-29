
using FluentValidation;
using FluentValidation.Results;

namespace eMenu.Models;

public class UpdateDishRequest
{
#region Model
    public string Name {get;set;}
    public TimeSpan WaitTime {get; set;}
    public int Weight{get; set;}
    public decimal Price {get; set;}
    public int? Kkal {get; set;}
    public int? Protein {get; set;}
    public int? Fats {get; set;}
    public int? Carbohydrates {get; set;}
    public string? Description {get; set;}   

#endregion

#region Validator
public class Validator: AbstractValidator<UpdateDishRequest>
{
public Validator()
{
    RuleFor(x=>x.Name)
        .MaximumLength(255).WithMessage("Length must be less than 256");
    RuleFor(x=>x.Price)
        .NotNull().WithMessage("Length > 0");
    RuleFor(x=>x.Weight)
        .NotNull().WithMessage("Length > 0");
     RuleFor(x=>x.WaitTime)
        .NotNull().WithMessage("Length > 0");
     RuleFor(x=>x.Description)
        .MaximumLength(255).WithMessage("Length <=255");
}

}
#endregion
}
public static class UpdateDishRequestExtension
{
public static ValidationResult Validate(this UpdateDishRequest model)
{
return new UpdateDishRequest.Validator().Validate(model);
}
}

