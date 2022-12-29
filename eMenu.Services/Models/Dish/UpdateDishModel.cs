namespace eMenu.Services.Models;
public class UpdateDishModel:BaseModel
{
   public string Name {get;set;}
    public TimeSpan WaitTime {get; set;}  
    public decimal Price {get; set;}
    public string? Description {get; set;}
}
   