using AutoMapper;
using eMenu.Entities.Models;
using eMenu.Services.Models;

namespace eMenu.Services.MapperProfile;

public class ServicesProfile : Profile
{
    public ServicesProfile()
    {
        
#region Users


CreateMap<User, UserModel>().ReverseMap();
CreateMap<User, UserPreviewModel>()
.ForMember(x => x.Login, y => y.MapFrom(u => u.Login));


#endregion

#region Table


CreateMap<Table, TableModel>().ReverseMap();
CreateMap<Table, TablePreviewModel>();


#endregion

#region Order

CreateMap<Order, OrderModel>().ReverseMap();
CreateMap<Order, OrderPreviewModel>();

#endregion
#region DishInOrder

CreateMap<DishInOrder, DishInOrderModel>().ReverseMap();
CreateMap<DishInOrder, DishInOrderPreviewModel>();

#endregion

#region Dish

CreateMap<Dish, DishModel>().ReverseMap();
CreateMap<Dish, DishPreviewModel>();

#endregion
}
}
