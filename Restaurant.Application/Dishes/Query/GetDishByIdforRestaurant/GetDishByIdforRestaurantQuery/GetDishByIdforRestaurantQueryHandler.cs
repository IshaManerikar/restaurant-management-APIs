

using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Application.Dishes.Command.CreateDishCommand;
using Restaurant.Application.DTO;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Exceptions;
using Restaurant.Domain.IRepository;

namespace Restaurant.Application.Dishes.Query.GetDishByIdforRestaurant.GetDishByIdforRestaurantQuery;

public class GetDishByIdforRestaurantQueryHandler(
    ILogger<CreateDishcommandHandler> _logger,
     IRestaurantRepository _repository,
     IMapper _mapper


    ) : IRequestHandler<GetDishByIdforRestaurantQuery, DishDTO>
{
    public async Task<DishDTO> Handle(GetDishByIdforRestaurantQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Get Dish with ID  : {@request}", request.DishId);
        var restaurant = await _repository.GetRestaurantByIDAsync(request.RestaurantId);
        if (restaurant == null)
            throw new NotFoundException(nameof(Hotel), request.RestaurantId.ToString());

        var dish = restaurant.Dishes.FirstOrDefault(dish => dish.Id == request.DishId);
        var result= _mapper.Map<DishDTO>(dish);

        return result;

    }
}
