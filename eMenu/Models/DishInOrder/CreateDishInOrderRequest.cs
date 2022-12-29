namespace eMenu.Models;
public class DishInOrderRequest: UpdateDishInOrderRequest
{
    public Guid TableId { get; set; }
    public Guid DishId { get; set; }
    
}