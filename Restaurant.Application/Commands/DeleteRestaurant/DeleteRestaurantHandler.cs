

using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Domain.IRepository;
using Restaurant.Domain.Exceptions;

namespace Restaurant.Application.Commands.DeleteRestaurant
{
    public class DeleteRestaurantHandler(ILogger<DeleteRestaurantHandler> logger , IRestaurantRepository repository ) : IRequestHandler<DeleteRestaurantQuery>
    {
        public async Task Handle(DeleteRestaurantQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("deleting single restaurant with id : {id}", request.Id);
            var restaurant = await repository.DeleteAsync(request.Id);
               if (!restaurant)
                throw new NotFoundException(nameof(request), request.Id.ToString());
           
        }

       
    }
}
