
using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities;
using Restaurant.Domain.IRepository;
using Restaurant.Infrastructure.DB;

namespace Restaurant.Infrastructure.Repository
{
    internal class DishRepository(RestaurantDBContext _context) : IDishRepository
    {
        public async Task<int> CreateAsync(Dish entity)
        {
            _context.Dishes.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<Dish?> GetDishByIdForRestaurant(int restaurantId, int dishId)
        {
            return await _context.Dishes.FirstOrDefaultAsync(d =>
            d.Id == dishId
            &&
            d.RestaurantId == restaurantId);
        }
        public async Task UpdateAsync(Dish dish)
        {
            _context.Dishes.Update(dish);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Dish dish)
        {
            _context.Dishes.Remove(dish);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Dish>> GetDishesByCategory(string? category)
        {
            var query = _context.Dishes.AsQueryable();
            if (!string.IsNullOrEmpty(category))
                query = query.Where(d => d.Category == category);

            return await query.ToListAsync();
        }

    }
}
