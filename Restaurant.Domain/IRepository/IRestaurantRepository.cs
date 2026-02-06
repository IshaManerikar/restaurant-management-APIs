
using Restaurant.Domain.Common;
using Restaurant.Domain.Entities;

namespace Restaurant.Domain.IRepository
{
    public interface IRestaurantRepository
    {
       Task<IEnumerable<Hotel>> GetAllAsync();
       Task<MatchingRecords<Hotel>> GetAllMatchingAsync(string? searchPhrase , int pageNumber, int pageSize, string sortBy , SortOrder sortOrder);
        Task<Hotel?> GetRestaurantByIDAsync(int Id);
        Task<int> CreateAsync(Hotel hotel);
        Task<bool> DeleteAsync(int Id);
        Task SaveChanges();
        Task<IEnumerable<Hotel>>SearchAsync(String? name, String? dishName, decimal? minPrice, decimal? maxPrice, string? category, string? city);
        Task<int>AddReviewAsync(Review review);
        Task<IEnumerable<Review>>GetReviewsByRestaurantIdAsync(int restaurantId);
        Task<double?> GetAverageRatingAsync(int HotelId);
        Task<bool> DeleteReviewAsync(int reviewId);

        Task<Review?> GetReviewByIdAsync(int reviewId);

    }
}
