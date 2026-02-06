using MediatR;

namespace Restaurant.Application.Commands.ReviewCommands
{
    public class AddReviewCommand : IRequest<int>
    {
        public int HotelId { get; set; }
        public string ReviewerName { get; set; } = default!;
        public string Comments { get; set; } = default!;
        public int Rating { get; set; }
    }
}

