using AutoMapper;
//using AutoMapper;
using MediatR;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Exceptions;
using Restaurant.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Dishes.Command.UpdateDishCommand
{
    public class UpdateDishCommandHandler(IDishRepository dishRepository, IMapper mapper) : IRequestHandler<UpdateDishCommand>
    {
        public async Task Handle(UpdateDishCommand request, CancellationToken cancellationToken)
        {
            var dish = await dishRepository.GetDishByIdForRestaurant(request.RestaurantId, request.DishId);
            if (dish == null)
            {
                throw new NotFoundException(nameof(Dish), request.DishId.ToString());
            }
            mapper.Map(request, dish);
            await dishRepository.UpdateAsync(dish);

        }
    }
 
}
