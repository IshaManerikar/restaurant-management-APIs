using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.DTO
{
    internal class UpdateReviewDTO
    {
        public  int Id { get; set; }
        public  int Rating { get; set; }
        public  string Comment { get; set; } = default!;
    }
}
