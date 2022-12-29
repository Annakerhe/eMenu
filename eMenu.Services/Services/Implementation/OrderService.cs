using AutoMapper;
using eMenu.Entities.Models;
using eMenu.Repository;
using eMenu.Services.Abstract;
using eMenu.Services.Models;

namespace eMenu.Services.Implementation;
public class OrderService : IOrderService
{
private readonly IRepository<Order> OrderRepository;
private readonly IMapper mapper;
public OrderService (IRepository<Order> OrderRepository, IMapper mapper)
{
this.OrderRepository=OrderRepository;
this.mapper = mapper;
}
public OrderModel GetOrder(Guid id){
var Order = OrderRepository.GetById(id);
return mapper.Map<OrderModel>(Order);
}

public OrderModel UpdateOrder(Guid id, UpdateOrderModel orderModel){

var existingOrder = OrderRepository.GetById(id);
if (existingOrder == null)
{
throw new Exception("Order not found");
}
existingOrder.ReadyTime=orderModel.ReadyTime;

existingOrder = OrderRepository.Save(existingOrder);
return mapper.Map<OrderModel>(existingOrder);
}


public void DeleteOrder(Guid id){
var OrderToDelete = OrderRepository.GetById(id);
if (OrderToDelete == null)
{
throw new Exception("Order not found");
}
OrderRepository.Delete(OrderToDelete);
}
public PageModel<OrderPreviewModel> GetOrders(int limit = 20, int offset = 0)
{
var Orders =OrderRepository.GetAll();
int totalCount =Orders.Count();
var chunk=Orders.OrderBy(x=>x.TakenTime).Skip(offset).Take(limit);

return new PageModel<OrderPreviewModel>()
{
Items = mapper.Map<IEnumerable<OrderPreviewModel>>(chunk),
TotalCount = totalCount
};
}
public OrderModel CreateOrder(Guid TableId, OrderModel orderModel)    {
      if(OrderRepository.GetAll(x=>x.Id==orderModel.Id).FirstOrDefault()!=null)
      {
        throw new Exception ("Attempt to create a non-unique object!");
      }
      
        OrderModel createOrder = new OrderModel();
        createOrder.TableId=orderModel.TableId;
        createOrder.ReadyTime=orderModel.ReadyTime;
        createOrder.TakenTime=orderModel.TakenTime;

        OrderRepository.Save(mapper.Map<Order>(createOrder));
        return createOrder;

    }
}