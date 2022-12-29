namespace eMenu.Entities.Models;
public class Table : BaseEntity
{
    public string? Location {get;set;}
    public virtual ICollection<Order> Orders {get; set; }
}