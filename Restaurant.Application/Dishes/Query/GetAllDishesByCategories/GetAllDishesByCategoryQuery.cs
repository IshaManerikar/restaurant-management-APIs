using MediatR;
using Restaurant.Application.DTO;

namespace Restaurant.Application.Dishes.Query.GetAllDishesByCategories
{
    public class GetAllDishesByCategoryQuery : IRequest<List<DishDTO>>
    {
        public string Category { get; set; }
    }
}
