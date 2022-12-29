namespace eMenu.Services.Models;
public class OrderModel : BaseModel
{    
    public Guid Id{get;set;}
    public Guid TableId {get; set;}
    public DateTime ReadyTime {get; set;}
    public DateTime TakenTime {get; set;}   
}