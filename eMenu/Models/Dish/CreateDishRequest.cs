namespace eMenu.Models;
public class CreateDishModel
{
  public string Name {get;set;}
    public TimeSpan WaitTime {get; set;}
    public int Weight{get; set;}
    public decimal Price {get; set;}
    public int? Kkal {get; set;}
    public int? Protein {get; set;}
    public int? Fats {get; set;}
    public int? Carbohydrates {get; set;}
    public string? Description {get; set;}
}