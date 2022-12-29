using AutoMapper;
using eMenu.Entities.Models;
using eMenu.Repository;
using eMenu.Services.Abstract;
using eMenu.Services.Models;

namespace eMenu.Services.Implementation;

public class UserService : IUserService
{
    private readonly IRepository<User> usersRepository;
    private readonly IMapper mapper;
    public UserService(IRepository<User> usersRepository, IMapper mapper)
    {
        this.usersRepository = usersRepository;
        this.mapper = mapper;
    }
 
    public void DeleteUser(Guid id)
    {
        var userToDelete = usersRepository.GetById(id);
        if (userToDelete == null)
        {
            throw new Exception("User not found");
        }

        usersRepository.Delete(userToDelete);
    }

    public UserModel GetUser(Guid id)
    {
        var user = usersRepository.GetById(id);
        return mapper.Map<UserModel>(user);
    }

   public PageModel<UserPreviewModel> GetUsers(int limit = 20, int offset = 0)
    {
        var users = usersRepository.GetAll(); //query created
        int totalCount = users.Count();
        var chunk = users.OrderBy(x => x.Login).Skip(offset).Take(limit); //query updated IQueruable<User>

        return new PageModel<UserPreviewModel>()
        {
            Items = chunk.Select(x => mapper.Map<UserPreviewModel>(x)),
            TotalCount = totalCount
        };
    }

    public UserModel UpdateUser(Guid id, UpdateUserModel user)
    {
        var existingUser = usersRepository.GetById(id);
        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

    existingUser.Login = user.Login;
    existingUser = usersRepository.Save(existingUser);
    return mapper.Map<UserModel>(existingUser);
}
 public UserModel CreateUser(UserModel userModel)
{
    usersRepository.Save(mapper.Map<Entities.Models.User>(userModel));
    return userModel;
}
}
