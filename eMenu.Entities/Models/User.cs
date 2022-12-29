namespace eMenu.Entities.Models;
public class User : BaseEntity
{
    public string PasswordHash { get; set; }
    public string Login { get; set; }   
}


