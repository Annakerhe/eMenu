namespace eMenu.Services.Models;
public class OrderPreviewModel : BaseModel
{    
    public Guid Id{get;set;}
    public DateTime ReadyTime {get; set;}
    public DateTime TakenTime {get; set;}   
}