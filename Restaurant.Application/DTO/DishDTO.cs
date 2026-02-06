
namespace Restaurant.Application.DTO
{
    public class DishDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public string? Category { get; set; }
        public int? KiloCalories { get; set; }

      
    }
}
