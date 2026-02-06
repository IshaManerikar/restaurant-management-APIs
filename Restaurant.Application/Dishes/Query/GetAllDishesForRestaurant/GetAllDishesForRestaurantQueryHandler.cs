
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Application.Dishes.Command.CreateDishCommand;
using Restaurant.Application.DTO;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Exceptions;
using Restaurant.Domain.IRepository;

namespace Restaurant.Application.Dishes.Query.GetAllDishesForRestaurant;

public class GetAllDishesForRestaurantQueryHandler(
     ILogger<CreateDishcommandHandler> _logger,
     IRestaurantRepository _repository,     
     IMapper _mapper

    ) : IRequestHandler<GetAllDishesForRestaurantQuery, IEnumerable<DishDTO>>
{
    public async Task<IEnumerable<DishDTO>> Handle(GetAllDishesForRestaurantQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Get Dishes for restaurant with ID  : {@request}", request.RestaurantId);
        var restaurant = await _repository.GetRestaurantByIDAsync(request.RestaurantId);
        if (restaurant == null)
            throw new NotFoundException(nameof(Hotel), request.RestaurantId.ToString());

        var dish = _mapper.Map<IEnumerable<DishDTO>>(restaurant.Dishes);  

                     
        return dish;

    }
}
