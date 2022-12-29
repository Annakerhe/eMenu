using AutoMapper;
using eMenu.Entities.Models;
using eMenu.Repository;
using eMenu.Services.Abstract;
using eMenu.Services.Models;

namespace eMenu.Services.Implementation;

public class DishService : IDishService
{
private readonly IRepository<Dish> DishRepository;
private readonly IMapper mapper;
public DishService(IRepository<Dish> DishRepository, IMapper mapper)
{
this.DishRepository=DishRepository;
this.mapper = mapper;
}

public void DeleteDish(Guid id)
{
var DishToDelete =DishRepository.GetById(id);
if (DishToDelete == null)
{
throw new Exception("Dish not found");
}
DishRepository.Delete(DishToDelete);
}

public DishModel GetDish(Guid id)
{
var Dish = DishRepository.GetById(id);
return mapper.Map<DishModel>(Dish);
}

public PageModel<DishPreviewModel> GetDishes(int limit = 20, int offset = 0)
{
var Dishes =DishRepository.GetAll();
int totalCount =Dishes.Count();
var chunk=Dishes.OrderBy(x=>x.Name).Skip(offset).Take(limit);

return new PageModel<DishPreviewModel>()
{
Items = mapper.Map<IEnumerable<DishPreviewModel>>(chunk),
TotalCount = totalCount
};
}

public DishModel UpdateDish (Guid id, UpdateDishModel Dish)
{
var existingDish = DishRepository.GetById(id);
if (existingDish == null)
{
throw new Exception("Dish not found");
}
existingDish.Name=Dish.Name;
existingDish.Description=Dish.Description;
existingDish.Price=Dish.Price;
existingDish.WaitTime=Dish.WaitTime;

existingDish = DishRepository.Save(existingDish);
return mapper.Map<DishModel>(existingDish);
}
public DishModel CreateDish(DishModel dishModel){
    DishRepository.Save(mapper.Map<Entities.Models.Dish>(dishModel));
return dishModel;
}
}