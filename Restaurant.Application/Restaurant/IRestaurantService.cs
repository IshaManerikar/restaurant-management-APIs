using Restaurant.Application.DTO;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.Restaurant
{
    public interface IRestaurantService
    {
        Task<IEnumerable<RestaurantDTO>> GetAllRestaurant();
        Task<RestaurantDTO?> GetRestaurantById(int id);
        Task<int> Create(CreateRestaurantDTO createRestaurantDTO);
    }
}