using eMenu.Services.Models;
namespace eMenu.Services.Abstract;

public interface IOrderService
{
OrderModel GetOrder(Guid id);

OrderModel UpdateOrder(Guid id, UpdateOrderModel orderModel);

void DeleteOrder(Guid id);

PageModel<OrderPreviewModel> GetOrders(int limit = 20, int offset = 0);
OrderModel CreateOrder(Guid TableId, OrderModel orderModel);

}
