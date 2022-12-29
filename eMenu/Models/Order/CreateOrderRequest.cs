namespace eMenu.Models;
public class CreateOrderRequest: UpdateOrderRequest
{
    public DateTime TakenTime { get; set; }
     public DateTime ReadyTime { get; set; }
    public Guid TableId { get; set; }
    
}