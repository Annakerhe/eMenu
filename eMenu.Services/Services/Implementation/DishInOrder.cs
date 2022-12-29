using AutoMapper;
using eMenu.Entities.Models;
using eMenu.Repository;
using eMenu.Services.Abstract;
using eMenu.Services.Models;

namespace eMenu.Services.Implementation;

public class DishInOrderService : IDishInOrderService
{
private readonly IRepository<DishInOrder> DishInOrderRepository;
private readonly IMapper mapper;
public DishInOrderService(IRepository<DishInOrder> DishInOrderRepository, IMapper mapper)
{
this.DishInOrderRepository=DishInOrderRepository;
this.mapper = mapper;
}

public void DeleteDishInOrder(Guid id)
{
var DishInOrderToDelete =DishInOrderRepository.GetById(id);
if (DishInOrderToDelete == null)
{
throw new Exception("DishInOrder not found");
}
DishInOrderRepository.Delete(DishInOrderToDelete);
}

public DishInOrderModel GetDishInOrder(Guid id)
{
var DishInOrder = DishInOrderRepository.GetById(id);
return mapper.Map<DishInOrderModel>(DishInOrder);
}

public PageModel<DishInOrderPreviewModel> GetDishesInOrders(int limit = 20, int offset = 0)
{
var DishesInOrder =DishInOrderRepository.GetAll();
int totalCount =DishesInOrder.Count();
var chunk=DishesInOrder.OrderBy(x=>x.Amount).Skip(offset).Take(limit);

return new PageModel<DishInOrderPreviewModel>()
{
Items = mapper.Map<IEnumerable<DishInOrderPreviewModel>>(chunk),
TotalCount = totalCount
};
}

public DishInOrderModel UpdateDishInOrder (Guid id, UpdateDishInOrderModel DishInOrder)
{
var existingDishInOrder = DishInOrderRepository.GetById(id);
if (existingDishInOrder == null)
{
throw new Exception("DishInOrder not found");
}
existingDishInOrder.Amount=DishInOrder.Amount;

existingDishInOrder = DishInOrderRepository.Save(existingDishInOrder);
return mapper.Map<DishInOrderModel>(existingDishInOrder);
}
public DishInOrderModel CreateDishInOrder(Guid OrderId, Guid DishId, DishInOrderModel orderModel)
{
     if(DishInOrderRepository.GetAll(x=>x.Id==orderModel.Id).FirstOrDefault()!=null)
      {
        throw new Exception ("Attempt to create a non-unique object!");
      }
      
        DishInOrderModel createDishInOrder = new DishInOrderModel();
        createDishInOrder.Amount=createDishInOrder.Amount;
        createDishInOrder.DishId=createDishInOrder.DishId;
        createDishInOrder.OrderId=createDishInOrder.OrderId;
        DishInOrderRepository.Save(mapper.Map<DishInOrder>(createDishInOrder));
        return createDishInOrder;

}
}

