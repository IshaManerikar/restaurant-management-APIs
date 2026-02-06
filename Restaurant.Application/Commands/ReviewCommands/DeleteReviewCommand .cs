using MediatR;

namespace Restaurant.Application.Commands.Review
{
    public class DeleteReviewCommand : IRequest<bool>
    {
        public int ReviewId { get; set; }
    }
}
