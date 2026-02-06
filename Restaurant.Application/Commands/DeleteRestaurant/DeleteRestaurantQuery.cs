
using MediatR;

namespace Restaurant.Application.Commands.DeleteRestaurant
{
    public class DeleteRestaurantQuery : IRequest
    {   
        public int Id { get; set; } 
        public DeleteRestaurantQuery(int id)
        {
            Id = id;
        }
    }
}
