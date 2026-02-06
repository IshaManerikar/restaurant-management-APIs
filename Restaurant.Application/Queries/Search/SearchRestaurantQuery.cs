using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Restaurant.Application.DTO;
namespace Restaurant.Application.Queries.Search
{
    public class SearchRestaurantQuery: IRequest<IEnumerable<RestaurantDTO>>
    {
        public string? Name { get; set; }
        public string? DishName { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string? Category { get; set; }
        public string? City { get; set; }




    }
}
