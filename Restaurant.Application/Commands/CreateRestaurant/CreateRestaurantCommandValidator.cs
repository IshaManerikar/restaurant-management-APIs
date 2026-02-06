
using FluentValidation;
using Restaurant.Application.DTO;

namespace Restaurant.Application.Commands.CreateRestaurant
{
    public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
    {
        public CreateRestaurantCommandValidator()
        {
            RuleFor(x => x.Name).Length(5, 50).WithMessage("Please enter valid name");
        }
    }
}
