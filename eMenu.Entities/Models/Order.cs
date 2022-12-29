namespace eMenu.Entities.Models;
public class Order : BaseEntity
{    
    public virtual Guid TableId {get; set;}
    public virtual Table Table {get; set;}
    public DateTime ReadyTime {get; set;}
    public DateTime TakenTime {get; set;}   
    public virtual ICollection<DishInOrder> DishesInOrders {get; set; }
}