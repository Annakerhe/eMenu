namespace eMenu.Models;
public class DishPreviewResponse
{
  public string Name {get;set;}
    public TimeSpan WaitTime {get; set;}
    public int Weight{get; set;}
    public decimal Price {get; set;}
}