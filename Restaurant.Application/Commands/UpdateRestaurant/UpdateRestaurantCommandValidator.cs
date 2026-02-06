
using FluentValidation;

namespace Restaurant.Application.Commands.UpdateRestaurant
{
    public class UpdateRestaurantCommandValidator : AbstractValidator<UpdateRestaurantCommand>
    {
        public UpdateRestaurantCommandValidator()
        {
            RuleFor(x => x.Name).Length(5, 50).WithMessage("Please enter valid name");
            RuleFor(x => x.Description).Length(10, 200).WithMessage("Description must be between 10 and 200 length");
        }
    }
}
