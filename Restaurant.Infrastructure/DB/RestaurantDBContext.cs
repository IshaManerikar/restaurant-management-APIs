
using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities;

namespace Restaurant.Infrastructure.DB
{
    public class RestaurantDBContext(DbContextOptions<RestaurantDBContext> option) : DbContext(option)
    {
        internal DbSet<Hotel> Restaurants { get; set; }

        internal DbSet<Dish> Dishes { get; set; }

        internal DbSet<Review> Reviews { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Hotel>()
                .OwnsOne<Address>(r => r.Address, a =>
                {
                    a.Property(a => a.Street).HasColumnType("varchar(25)");
                    a.Property(a => a.City).HasColumnType("varchar(25)");
                    a.Property(a => a.PostalCode).HasColumnType("varchar(10)");

                });


            modelBuilder.Entity<Hotel>()
                .HasMany<Dish>(r => r.Dishes)
                .WithOne()
                .HasForeignKey(d => d.RestaurantId);

            modelBuilder.Entity<Dish>(eb =>
            {
                eb.Property(d => d.Price).HasPrecision(18, 2);
                eb.Property(d => d.Name).HasColumnType("varchar(50)");
                eb.Property(d => d.Description).HasColumnType("varchar(200)");
            });
            modelBuilder.Entity<Hotel>(eb =>
            {
                eb.Property(d => d.Name).HasColumnType("varchar(50)");
                eb.Property(d => d.Category).HasColumnType("varchar(100)");
                eb.Property(d => d.Description).HasColumnType("varchar(200)");
                eb.Property(d => d.ContactEmail).HasColumnType("varchar(100)");
                eb.Property(d => d.ContactNumber).HasColumnType("varchar(15)");
            });

            modelBuilder.Entity<Review>()
            .Property(r => r.Comments)
            .IsRequired(false);

            modelBuilder.Entity<Review>()
                        .Property(r => r.ReviewerName)
                        .IsRequired(false);

            modelBuilder.Entity<Review>()
           .HasOne(r => r.Hotel)
           .WithMany(h => h.Reviews)
           .HasForeignKey(r => r.HotelId)
           .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }


}
