
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Exceptions;
using Restaurant.Domain.IRepository;

namespace Restaurant.Application.Dishes.Command.CreateDishCommand;

public class CreateDishcommandHandler(
     ILogger<CreateDishcommandHandler> _logger, 
     IRestaurantRepository _repository,
     IDishRepository _dishRepository,
     IMapper _mapper
                                    ) : IRequestHandler<CreateDishCommand, int>
{
    public async Task<int> Handle(CreateDishCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("create dish : {@request}", request);
        var restaurant = await _repository.GetRestaurantByIDAsync(request.RestaurantId);
        if (restaurant == null)
            throw new NotFoundException(nameof(Hotel), request.RestaurantId.ToString());

        var dish = _mapper.Map<Dish>(request);
       return await  _dishRepository.CreateAsync(dish);
    }
}
