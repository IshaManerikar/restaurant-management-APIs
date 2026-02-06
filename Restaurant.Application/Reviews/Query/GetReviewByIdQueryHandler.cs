using AutoMapper;
using MediatR;
using Restaurant.Application.DTO;
using Restaurant.Application.Reviews.Query;
using Restaurant.Domain.IRepository;

namespace Restaurant.Application.Reviews.Queries
{
    public class GetReviewByIdQueryHandler : IRequestHandler<GetReviewById, ReviewDTO>
    {
        private readonly IRestaurantRepository _repository;
        private readonly IMapper _mapper;

        public GetReviewByIdQueryHandler(IRestaurantRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ReviewDTO> Handle(GetReviewById request, CancellationToken cancellationToken)
        {
            var review = await _repository.GetReviewByIdAsync(request.ReviewId);
            if (review == null)
                return null;

            return _mapper.Map<ReviewDTO>(review);
        }

    }
}
