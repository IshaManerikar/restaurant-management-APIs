using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.DTO
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public int restaurantId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; } = default!;
        public string? UserName { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
    }
}
