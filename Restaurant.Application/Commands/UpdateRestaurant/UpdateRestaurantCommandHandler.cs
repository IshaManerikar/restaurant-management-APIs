
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Exceptions;
using Restaurant.Domain.IRepository;

namespace Restaurant.Application.Commands.UpdateRestaurant
{
    public class UpdateRestaurantCommandHandler(ILogger<UpdateRestaurantCommandHandler> logger, IRestaurantRepository repository , IMapper mapper) : IRequestHandler<UpdateRestaurantCommand>
    {
        public async Task Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("updating restaurant ");
           
            var restaurant = await repository.GetRestaurantByIDAsync(request.Id);
            if (restaurant == null)
                throw new NotFoundException(nameof(Hotel) , request.Id.ToString());

            var arg = mapper.Map<Hotel>(request);
            await repository.SaveChanges();
           

        }
    }
}
