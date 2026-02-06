
using FluentValidation;

namespace Restaurant.Application.Dishes.Command.CreateDishCommand;

public class CreateDishCommandValidator : AbstractValidator<CreateDishCommand>
{
    public CreateDishCommandValidator()
    {
        RuleFor(dish => dish.Name).NotEmpty()
            .WithMessage("Name cannot be empty");
        RuleFor(dish => dish.Price).GreaterThan(5).WithMessage("Price must be non-negative");
        RuleFor(dish => dish.KiloCalories).GreaterThan(0).WithMessage("calories must be non-negative");
    }
}
