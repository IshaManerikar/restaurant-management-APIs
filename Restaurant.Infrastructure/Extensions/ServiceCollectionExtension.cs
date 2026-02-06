using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Domain.IRepository;
using Restaurant.Infrastructure.DB;
using Restaurant.Infrastructure.Repository;


namespace Restaurant.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("RestaurantDBConnection");
            //services.AddDbContextFactory<RestaurantDBContext>
            services.AddDbContext<RestaurantDBContext>
            (option => option.UseMySql(connectionString ,ServerVersion.AutoDetect(connectionString)));

           // services.AddIdentityApiEndpoints<User>().AddEntityFrameworkStores<RestaurantDBContext>();
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            services.AddScoped<IDishRepository, DishRepository>();
        }
    }
}
