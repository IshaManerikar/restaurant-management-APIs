
using MediatR;
using Restaurant.Application.DTO;

namespace Restaurant.Application.Queries.GetRestaurantByID
{
    public class GetRestaurantbyIDQuery : IRequest<RestaurantDTO>
    {
        public GetRestaurantbyIDQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
