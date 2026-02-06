using MediatR;
using Restaurant.Application.DTO;

namespace Restaurant.Application.Dishes.Query.GetAllDishesForRestaurant;

public class GetAllDishesForRestaurantQuery(int restId ) : IRequest<IEnumerable<DishDTO>>
{
    public int RestaurantId { get; } = restId; 
   
}
