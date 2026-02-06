
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Restaurant.Application.DTO;
namespace Restaurant.Application.Reviews.Query
{
    public class GetReviewById: IRequest<ReviewDTO>
    {
        public int ReviewId { get; set; }
    }
}
