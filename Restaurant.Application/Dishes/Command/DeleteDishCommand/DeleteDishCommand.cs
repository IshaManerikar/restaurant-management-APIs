using MediatR;

namespace Restaurant.Application.Dishes.Command.DeleteDishCommand
{
public record DeleteDishCommand(int RestaurantId, int DishId) : IRequest;

}

