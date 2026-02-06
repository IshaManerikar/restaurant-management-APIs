using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Commands.Review;
using Restaurant.Application.Commands.ReviewCommands;
using Restaurant.Application.Reviews.Queries;
using Restaurant.Application.Reviews.Query;

namespace Restaurant.Controllers
{
    [ApiController]
    [Route("api/hotels/{hotelId}/reviews")]
    public class ReviewController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReviewController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Add Review
        [HttpPost]
        public async Task<IActionResult> AddReview(int hotelId, AddReviewCommand command)
        {
            try
            {
                command.HotelId = hotelId;
                var reviewId = await _mediator.Send(command);
                return CreatedAtAction(nameof(GetReviewById), new { hotelId, reviewId }, null);
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Get All Reviews for a Hotel
        [HttpGet]
        public async Task<IActionResult> GetReviewsForHotel(int hotelId)
        {
            var query = new GetReviewsForHotelQuery { HotelId = hotelId };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // Get Single Review by ID
        [HttpGet("{reviewId}")]
        public async Task<IActionResult> GetReviewById(int hotelId, int reviewId)
        {
            var query = new GetReviewById { ReviewId = reviewId };
            var review = await _mediator.Send(query);

            if (review == null)
                return NotFound("Review not found.");

            return Ok(review);
        }

        // Delete Review
        // DELETE: api/hotels/{hotelId}/reviews/{reviewId}
        [HttpDelete("{reviewId}")]
        public async Task<IActionResult> DeleteReview(int hotelId, int reviewId)
        {
            var command = new DeleteReviewCommand { ReviewId = reviewId };
            var result = await _mediator.Send(command);

            if (!result)
                return NotFound("Review not found.");

            return NoContent();
        }



    }
}
