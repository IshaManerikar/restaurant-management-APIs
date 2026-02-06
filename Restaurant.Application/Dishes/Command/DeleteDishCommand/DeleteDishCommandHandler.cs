using Restaurant.Domain.IRepository;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Exceptions;


namespace Restaurant.Application.Dishes.Command.DeleteDishCommand
{
    public class DeleteDishCommandHandler(
        IDishRepository dishRepository
    ) : IRequestHandler<DeleteDishCommand>
    {
        public async Task Handle(DeleteDishCommand request, CancellationToken cancellationToken)
        {
            var dish = await dishRepository
                .GetDishByIdForRestaurant(request.RestaurantId, request.DishId);

            if (dish == null)
            {
                throw new NotFoundException(nameof(Dish), request.DishId.ToString());
            }

            await dishRepository.DeleteAsync(dish);
        }
    }

}
