
using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Common;
using Restaurant.Domain.Entities;
using Restaurant.Domain.IRepository;
using Restaurant.Infrastructure.DB;
using System.Linq.Expressions;
using System.Net;


namespace Restaurant.Infrastructure.Repository
{
    internal class RestaurantRepository(RestaurantDBContext _context) : IRestaurantRepository
    {

        public async Task<int> CreateAsync(Hotel hotel)
        {
            //await using (var context = _contextFactory.CreateDbContext())
            //{
            //    context.Restaurants.Add(hotel);
            //    // Perform your database operations here.
            //    await context.SaveChangesAsync();
            //    return hotel.Id;
            //}
            _context.Restaurants.Add(hotel);
            await _context.SaveChangesAsync();
            return hotel.Id;

        }

        public async Task<bool> DeleteAsync(int Id)
        {
            //await using (var context = _contextFactory.CreateDbContext())
            //{
            //    var restaurant = await context.Restaurants.FindAsync(Id);
            //    if (restaurant == null)
            //        return false;

            //    context.Restaurants.Remove(restaurant);
            //    await context.SaveChangesAsync();
            //    return true;
            //}

            var restaurant = await _context.Restaurants.FindAsync(Id);
            if (restaurant == null)
                return false;

            _context.Restaurants.Remove(restaurant);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<IEnumerable<Hotel>> GetAllAsync()
        {
            //await using (var context = _contextFactory.CreateDbContext())
            //{
            //    var restaurant = await context.Restaurants.ToListAsync();
            //    return restaurant;
            //}
            var restaurant = await _context.Restaurants.ToListAsync();
            return restaurant;
        }

        public async Task<MatchingRecords<Hotel>> GetAllMatchingAsync(string? searchPhrase, int pageNumber, int pageSize, string sortBy, SortOrder sortOrder)
        {
            var searchPhraseLower = searchPhrase?.ToLower();

            var baseQuery = _context.Restaurants.Where(x =>

            searchPhraseLower == null || x.Name.ToLower().Contains(searchPhraseLower) ||
            x.Description.ToLower().Contains(searchPhraseLower)
            );

            var sortDict = new Dictionary<string, Expression<Func<Hotel, object>>>
            {
                {"Name" , h => h.Name },
                {"Description" , h => h.Description },
                {"Category" , h => h.Category }
            };

            var selectedColumn = sortDict[sortBy];

            if (sortBy != null)
            {
                baseQuery = sortOrder == SortOrder.Ascending ? baseQuery.OrderBy(selectedColumn) :
                                        baseQuery.OrderByDescending(selectedColumn);
            }

            int TotalCount = await baseQuery.CountAsync();
            int Totalpages = (int)Math.Ceiling(TotalCount / (decimal)pageSize);
            int fromItem = pageSize * (pageNumber - 1) + 1;
            int toItem = fromItem + pageSize - 1;

            var restaurant = baseQuery.Skip(pageSize * (pageNumber - 1)).Take(pageSize);

            var result = new MatchingRecords<Hotel>();
            result.Items = restaurant;
            result.ItemCount = TotalCount;
            result.PageCount = Totalpages;
            result.FromIndex = fromItem;
            result.ToIndex = toItem;

            return result;
        }

        public async Task<Hotel?> GetRestaurantByIDAsync(int id)
        {
            //await using (var context = _contextFactory.CreateDbContext())
            //{
            //    var restaurant = await context.Restaurants.FindAsync(id);
            //    return restaurant;
            //}
            var restaurant = await _context.Restaurants
                .Include(x => x.Dishes)
               .FirstAsync(x => x.Id == id);
            return restaurant;

        }

        //public async Task<bool> PatchAsync(Hotel hotel)
        //{
        //    //await using (var context = _contextFactory.CreateDbContext())
        //    //{
        //    //    var restaurant = await context.Restaurants.FindAsync(hotel.Id);
        //    //    if (restaurant == null)
        //    //        return false;

        //    //    restaurant.Name = hotel.Name;
        //    //    restaurant.Description = hotel.Description;
        //    //    restaurant.HasDelivery = hotel.HasDelivery;


        //    //    await context.SaveChangesAsync();
        //    //    return true;
        //    //}

        //    var restaurant = await _context.Restaurants.FindAsync(hotel.Id);
        //    if (restaurant == null)
        //        return false;

        //    restaurant.Name = hotel.Name;
        //    restaurant.Description = hotel.Description;
        //    restaurant.HasDelivery = hotel.HasDelivery;


        //    await _context.SaveChangesAsync();
        //    return true;
        //}

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Hotel>> SearchAsync(
         string? name,
         string? dishName,
         decimal? minPrice,
         decimal? maxPrice,
         string? category,
         string? city)
        {
            var query = _context.Restaurants.AsQueryable();

            if (!string.IsNullOrEmpty(name))
                query = query.Where(r => r.Name.ToLower().Contains(name.ToLower()));

            if (!string.IsNullOrEmpty(category))
                query = query.Where(r => r.Category.ToLower().Contains(category.ToLower()));

            if (!string.IsNullOrEmpty(city))
                query = query.Where(r => r.Address.City.ToLower().Contains(city.ToLower()));

            if (!string.IsNullOrEmpty(dishName) || minPrice.HasValue || maxPrice.HasValue)
            {
                query = query.Where(r => r.Dishes.Any(d =>
                    (string.IsNullOrEmpty(dishName) || d.Name.ToLower().Contains(dishName.ToLower())) &&
                    (!minPrice.HasValue || d.Price >= minPrice.Value) &&
                    (!maxPrice.HasValue || d.Price <= maxPrice.Value)
                ));
            }

            return await query.Include(r => r.Dishes).ToListAsync();
        }

        public async Task<int> AddReviewAsync(Review review)
        {
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return review.Id;
        }

        public async Task<IEnumerable<Review>> GetReviewsByRestaurantIdAsync(int restaurantId)
        {
            return await _context.Reviews
                .Where(r => r.HotelId == restaurantId)
                .ToListAsync();
        }

        public async Task<double?> GetAverageRatingAsync(int hotelId)
        {
            return await _context.Reviews
                .Where(r => r.HotelId == hotelId)
                .AverageAsync(r => (double?)r.Rating);
        }

        public async Task<bool> DeleteReviewAsync(int reviewId)
        {
            var review = await _context.Reviews.FindAsync(reviewId);
            if (review == null) return false;

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
            return true;
        }



        public async Task<Review?> GetReviewByIdAsync(int reviewId)
        {
            return await _context.Reviews
                .FirstOrDefaultAsync(r => r.Id == reviewId);
        }





    }
}
