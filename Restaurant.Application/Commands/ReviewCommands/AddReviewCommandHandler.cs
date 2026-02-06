using MediatR;
using Restaurant.Domain.IRepository;

namespace Restaurant.Application.Commands.ReviewCommands
{
    public class AddReviewCommandHandler : IRequestHandler<AddReviewCommand, int>
    {
        private readonly IRestaurantRepository _repository;

        public AddReviewCommandHandler(IRestaurantRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(AddReviewCommand request, CancellationToken cancellationToken)
        {
            var review = new global::Restaurant.Domain.Entities.Review
            {
                HotelId = request.HotelId,
                ReviewerName = request.ReviewerName,
                Comments = request.Comments,
                Rating = request.Rating,
                CreatedAt = DateTime.UtcNow
            };


            return await _repository.AddReviewAsync(review);
        }
    }
}
