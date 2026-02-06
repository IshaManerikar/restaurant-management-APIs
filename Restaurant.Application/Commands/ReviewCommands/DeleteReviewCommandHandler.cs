using MediatR;
using Restaurant.Application.Commands.Review;
using Restaurant.Domain.IRepository;

namespace Restaurant.Application.Commands.ReviewCommands
{
    public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand, bool>
    {
        private readonly IRestaurantRepository _repository;

        public DeleteReviewCommandHandler(IRestaurantRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            var deleted = await _repository.DeleteReviewAsync(request.ReviewId);
            return deleted;
        }
    }
}
