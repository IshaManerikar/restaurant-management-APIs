
using Restaurant.Domain.Entities;

namespace Restaurant.Domain.IRepository;

public interface IDishRepository
{
    Task<int> CreateAsync(Dish entity);
    Task<Dish?> GetDishByIdForRestaurant(int restaurantId, int dishId);
    Task UpdateAsync(Dish dish);

    Task DeleteAsync(Dish dish);

    Task<List<Dish>> GetDishesByCategory(string category);

}
