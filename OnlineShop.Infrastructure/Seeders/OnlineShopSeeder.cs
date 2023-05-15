using Microsoft.AspNetCore.Identity;
using OnlineShop.Domain.Entities;
using OnlineShop.Infrastructure.Database;

namespace OnlineShop.Infrastructure.Seeders
{
    public class OnlineShopSeeder
    {
        private readonly OnlineShopDbContext _dbContext;


        public OnlineShopSeeder(OnlineShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (!_dbContext.Roles.Any())
            {
                var admin = new IdentityRole() { Name = "Admin", NormalizedName = "ADMIN" };
                var user = new IdentityRole() { Name = "USER", NormalizedName = "USER" };
                _dbContext.Roles.AddRange(admin, user);
                await _dbContext.SaveChangesAsync();
            }

            if (!_dbContext.AppUsers.Any())
            {

                var user = new AppUser()
                {
                    FirstName = "Tomasz",
                    LastName = "Michniak",
                    UserName = "Tomasz@gmail.com",
                    NormalizedUserName = "TOMASZ@GMAIL.COM",
                    Email = "Tomasz@gmail.com",
                    NormalizedEmail = "TOMASZ@GMAIL.COM",
                };
                PasswordHasher<AppUser> hasher = new PasswordHasher<AppUser>();
                user.PasswordHash = hasher.HashPassword(user, "haslo");
                _dbContext.AppUsers.Add(user);
                await _dbContext.SaveChangesAsync();
                var userRole = new IdentityUserRole<string>()
                {
                    UserId = user.Id,
                    RoleId = _dbContext.Roles.Where(x => x.Name == "Admin").First().Id
                };
                _dbContext.UserRoles.Add(userRole);
            }

            if (!_dbContext.Products.Any())
            {
                var product = new Product()
                {
                    Name = "Rower Górski",
                    Price = 1250.99M,
                    Description = "Szybki i wytrzymały rower górski.",
                };
                product.Images.Add(
                    new Image()
                    {
                        FileName = "bicycle.jpg",
                        Product = product
                    });

                var secondProduct = new Product()
                {
                    Name = "Motocykl",
                    Price = 19653.99M,
                    Description = "Wytrzymały ale nie za szybki."
                };
                secondProduct.Images.Add(new Image()
                {
                    FileName = "helmet.jpg",
                    Product = secondProduct
                });
                product.EncodeName();
                secondProduct.EncodeName();
                _dbContext.Products.AddRange(product, secondProduct);
                await _dbContext.SaveChangesAsync();
            }
            if (!_dbContext.ProductRatings.Any())
            {
                var rating = new ProductRating()
                {
                    Rating = 5,
                    ProductId = _dbContext.Products.FirstOrDefault().Id,
                    AppUserId = _dbContext.AppUsers.FirstOrDefault().Id,
                    Description = "Fajne"
                };
                _dbContext.ProductRatings.Add(rating);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}