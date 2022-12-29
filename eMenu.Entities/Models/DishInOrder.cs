namespace eMenu.Entities.Models;
public class DishInOrder : BaseEntity
{
    public int Amount {get; set;}
    public virtual Guid DishId {get; set;}
    public virtual Dish Dish {get; set;}

     public virtual Guid OrderId {get; set;}
     public virtual Order Order {get; set;} 
}