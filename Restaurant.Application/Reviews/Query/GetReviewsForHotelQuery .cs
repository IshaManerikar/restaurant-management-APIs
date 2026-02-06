using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Restaurant.Application.DTO;
namespace Restaurant.Application.Reviews.Query
{
    public class GetReviewsForHotelQuery: IRequest<IEnumerable<ReviewDTO>>
    {
        public int HotelId { get; set; }
   
    }
}
