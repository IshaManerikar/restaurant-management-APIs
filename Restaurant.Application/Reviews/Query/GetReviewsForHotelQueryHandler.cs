using AutoMapper;
using MediatR;
using Restaurant.Application.DTO;
using Restaurant.Application.Reviews.Query;
using Restaurant.Domain.IRepository;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Application.Reviews.Queries
{
    public class GetReviewsForHotelQueryHandler : IRequestHandler<GetReviewsForHotelQuery, IEnumerable<ReviewDTO>>
    {
        private readonly IRestaurantRepository _repository;
        private readonly IMapper _mapper;

        public GetReviewsForHotelQueryHandler(IRestaurantRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReviewDTO>> Handle(GetReviewsForHotelQuery request, CancellationToken cancellationToken)
        {
            var reviews = await _repository.GetReviewsByRestaurantIdAsync(request.HotelId);

       
            if (reviews == null)
                return new List<ReviewDTO>();

            return _mapper.Map<IEnumerable<ReviewDTO>>(reviews);
        }
    }
}
