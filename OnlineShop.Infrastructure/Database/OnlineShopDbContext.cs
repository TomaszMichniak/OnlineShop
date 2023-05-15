using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Infrastructure.Database
{
    public class OnlineShopDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Image> Images { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductRating> ProductRatings { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartPosition> CartPositions { get; set; }

        public OnlineShopDbContext(DbContextOptions<OnlineShopDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CartPosition>()
                .HasKey(k => new { k.ProductId, k.CartId });

            modelBuilder.Entity<Product>()
               .Property(e => e.Price)
			   .HasColumnType("decimal(18,4)");

			//modelBuilder.Entity<Product>()
			//    .HasMany(x => x.ProductRatings)
			//    .WithOne(x => x.Product)
			//    .HasForeignKey(x => x.ProductId);
			//modelBuilder.Entity<Image>()
			//    .HasOne(x => x.Product)
			//    .WithMany(x => x.Images)
			//    .HasForeignKey(x => x.ProductId);
			//modelBuilder.Entity<ProductRating>()
			//    .HasOne(x => x.AppUser)
			//    .WithMany(x => x.ProductRatings)
			//    .HasForeignKey(x => x.AppUserId);

		}
    }
}
