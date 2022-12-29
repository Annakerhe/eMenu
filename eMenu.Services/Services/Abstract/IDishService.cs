using eMenu.Services.Models;
namespace eMenu.Services.Abstract;

public interface IDishService
{
DishModel GetDish(Guid id);

DishModel UpdateDish(Guid id, UpdateDishModel dishModel);

void DeleteDish(Guid id);

PageModel<DishPreviewModel> GetDishes(int limit = 20, int offset = 0);
DishModel CreateDish(DishModel dishModel);

}
