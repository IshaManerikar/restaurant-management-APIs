using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurant.Application.DTO;
using Restaurant.Domain.Entities;
using Restaurant.Domain.IRepository;
using System.Collections.Generic;

namespace Restaurant.Application.Restaurant
{
    internal class RestaurantService(IRestaurantRepository repository , ILogger<RestaurantService> logger , IMapper mapper) : IRestaurantService
    {
        public async Task<int> Create(CreateRestaurantDTO createRestaurantDTO)
        {
            logger.LogInformation("creating restaurant");
            var arg = mapper.Map<Hotel>(createRestaurantDTO);
            return await repository.CreateAsync(arg);
        }

        public async Task<IEnumerable<RestaurantDTO>> GetAllRestaurant()
        {
            logger.LogInformation("getting all restaurants");
            var restaurants = await repository.GetAllAsync();           
            var result = mapper.Map<IEnumerable<RestaurantDTO>>(restaurants);
            return result;
        }

        public async Task<RestaurantDTO?> GetRestaurantById(int id)
        {
            logger.LogInformation("getting single restaurant");
            var restaurant = await repository.GetRestaurantByIDAsync(id);
            var result = mapper.Map<RestaurantDTO>(restaurant);
            return result;
        }
    }
}
