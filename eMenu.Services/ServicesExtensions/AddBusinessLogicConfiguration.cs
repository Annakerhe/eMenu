using eMenu.Services.Abstract;
using eMenu.Services.Implementation;
using eMenu.Services.MapperProfile;
using Microsoft.Extensions.DependencyInjection;

namespace eMenu.Services;

public static partial class ServicesExtensions
{
    public static void AddBusinessLogicConfiguration(this IServiceCollection services)
    {
  services.AddAutoMapper(typeof(ServicesProfile));
//services
services.AddScoped<IUserService, UserService>();
services.AddScoped<IOrderService, OrderService>();
services.AddScoped<IDishService, DishService>();
services.AddScoped<IDishInOrderService, DishInOrderService>();
services.AddScoped<ITableService, TableService>();

}
}