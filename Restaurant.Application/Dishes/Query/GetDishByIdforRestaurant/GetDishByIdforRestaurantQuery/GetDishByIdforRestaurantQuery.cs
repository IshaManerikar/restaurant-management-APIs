
using MediatR;
using Restaurant.Application.DTO;

namespace Restaurant.Application.Dishes.Query.GetDishByIdforRestaurant.GetDishByIdforRestaurantQuery;

public class GetDishByIdforRestaurantQuery(int RestId, int DishId):IRequest<DishDTO>
{
    public int RestaurantId { get; } = RestId;
    public int DishId { get; } = DishId;    
}
