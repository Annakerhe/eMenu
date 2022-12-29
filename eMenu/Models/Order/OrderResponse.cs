namespace eMenu.Models;
public class OrderResponse
{
    public Guid Id{get;set;}
    public Guid TableId {get; set;}
    public DateTime ReadyTime {get; set;}
    public DateTime TakenTime {get; set;}   
}