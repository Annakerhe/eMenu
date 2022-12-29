using AutoMapper;
using eMenu.Models;
using eMenu.Services.Models;

namespace eMenu.MapperProfile;

public class PresentationProfile : Profile
{
    public PresentationProfile()
    {
        #region Pages

        CreateMap(typeof(PageModel<>),typeof(PageResponse<>));

        #endregion

        #region Users

        CreateMap<UserModel, UserResponse>().ReverseMap();
        CreateMap<UpdateUserRequest, UpdateUserModel>().ReverseMap();
        CreateMap<UserPreviewModel, UserPreviewResponse>().ReverseMap();
        CreateMap<UserResponse, UserPreviewModel>().ReverseMap();
        
        #endregion

        #region Table

        CreateMap<TableModel, TableResponse>().ReverseMap();
        CreateMap<UpdateTableRequest, UpdateTableModel>().ReverseMap();
        CreateMap<TableResponse, TablePreviewModel>().ReverseMap();
        
        #endregion

        #region Order

        CreateMap<OrderModel, OrderResponse>().ReverseMap();
        CreateMap<UpdateOrderRequest, UpdateOrderModel>().ReverseMap();
        CreateMap<OrderPreviewModel, OrderPreviewResponse>().ReverseMap();
        CreateMap<OrderResponse, OrderPreviewModel>().ReverseMap();
        
        #endregion

        #region DishInOrder

        CreateMap<DishInOrderModel, DishInOrderResponse>().ReverseMap();
        CreateMap<UpdateDishInOrderRequest, UpdateDishInOrderModel>().ReverseMap();
        CreateMap<DishInOrderPreviewModel, DishInOrderPreviewResponse>().ReverseMap();
        CreateMap<DishInOrderResponse, DishInOrderPreviewModel>().ReverseMap();
        
        #endregion
        #region Dish

        CreateMap<DishModel, DishResponse>().ReverseMap();
        CreateMap<UpdateDishRequest, UpdateDishModel>().ReverseMap();
        CreateMap<DishPreviewModel, DishPreviewResponse>().ReverseMap();
        CreateMap<DishResponse, DishPreviewModel>().ReverseMap();
        
        #endregion


    }
}