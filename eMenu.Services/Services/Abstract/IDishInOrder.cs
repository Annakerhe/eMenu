using eMenu.Services.Models;
namespace eMenu.Services.Abstract;

public interface IDishInOrderService
{
DishInOrderModel GetDishInOrder(Guid id);

DishInOrderModel UpdateDishInOrder(Guid id, UpdateDishInOrderModel dishModel);

void DeleteDishInOrder(Guid id);

PageModel<DishInOrderPreviewModel> GetDishesInOrders(int limit = 20, int offset = 0);
DishInOrderModel CreateDishInOrder(Guid OrderId, Guid DishId, DishInOrderModel orderModel);
}
