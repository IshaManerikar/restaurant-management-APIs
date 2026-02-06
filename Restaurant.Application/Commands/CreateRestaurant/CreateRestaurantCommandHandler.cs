
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Domain.Entities;
using Restaurant.Domain.IRepository;

namespace Restaurant.Application.Commands.CreateRestaurant
{
    public class CreateRestaurantCommandHandler(ILogger<CreateRestaurantCommandHandler> logger, IMapper mapper,
        IRestaurantRepository repository) : IRequestHandler<CreateRestaurantCommand, int>
    {
        public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("creating restaurant : {@Restaurant}" , request);
            var arg = mapper.Map<Hotel>(request);
            return await repository.CreateAsync(arg);
        }
    }
}
