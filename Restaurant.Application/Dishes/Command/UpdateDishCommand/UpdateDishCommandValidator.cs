using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;


namespace Restaurant.Application.Dishes.Command.UpdateDishCommand
{
    public class UpdateDishCommandValidator : AbstractValidator<UpdateDishCommand>
    {
        public UpdateDishCommandValidator()
        {
            RuleFor(dish => dish.Name).NotEmpty()
                .WithMessage("Name cannot be empty");
            RuleFor(dish => dish.Price).GreaterThan(5).WithMessage("Price must be non-negative");
            RuleFor(dish => dish.KiloCalories).GreaterThan(0).WithMessage("calories must be non-negative");
        }
    }
}
