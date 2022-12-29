namespace eMenu.Services.Models;
public class DishInOrderModel : BaseModel
{   
    public Guid Id{get;set;}
    public int Amount {get; set;}
    public  Guid DishId {get; set;} 
     public  Guid OrderId {get; set;}
     
}