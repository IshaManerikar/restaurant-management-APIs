
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Application.DTO;
using Restaurant.Domain.Exceptions;
using Restaurant.Domain.IRepository;

namespace Restaurant.Application.Queries.GetRestaurantByID
{
    public class GetRestaurantByIDHandler(ILogger<GetRestaurantByIDHandler> logger, IMapper mapper, IRestaurantRepository repository) : IRequestHandler<GetRestaurantbyIDQuery, RestaurantDTO>
    {
        public async Task<RestaurantDTO> Handle(GetRestaurantbyIDQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("getting single restaurant");
            var restaurant = await repository.GetRestaurantByIDAsync(request.Id);
            if (restaurant is null)
                throw new NotFoundException(nameof(request), request.Id.ToString());
                var result = mapper.Map<RestaurantDTO>(restaurant);
                   // result.DishDTO =  mapper.Map<IEnumerable<DishDTO>>(restaurant.Dishes).ToList();
           
            return result;
        }
    }
}
