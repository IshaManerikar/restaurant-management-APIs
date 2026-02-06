
using MediatR;

namespace Restaurant.Application.Dishes.Command.CreateDishCommand;

public class CreateDishCommand : IRequest<int>
{
    public int RestaurantId { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; }
    public string? Category { get; set; }
    public int? KiloCalories { get; set; }
}
