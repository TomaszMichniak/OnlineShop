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
                var secondUser = new AppUser()
                {
                    FirstName = "Test",
                    LastName = "Test",
                    UserName = "Test@Test.com",
                    NormalizedUserName = "TEST@TEST.COM",
                    Email = "Test@Test.com",
                    NormalizedEmail = "TEST@TEST.COM",
                };
                PasswordHasher<AppUser> hasher = new PasswordHasher<AppUser>();
                user.PasswordHash = hasher.HashPassword(user, "haslo");
                secondUser.PasswordHash = hasher.HashPassword(secondUser, "haslo");
                _dbContext.AppUsers.Add(user);
                _dbContext.AppUsers.Add(secondUser);
                var userRole = new IdentityUserRole<string>()
                {
                    UserId = user.Id,
                    RoleId = _dbContext.Roles.Where(x => x.Name == "Admin").First().Id
                };
                var userRoleTwo = new IdentityUserRole<string>()
                {
                    UserId = secondUser.Id,
                    RoleId = _dbContext.Roles.Where(x => x.Name == "User").First().Id
                };
                _dbContext.UserRoles.Add(userRole);
                _dbContext.UserRoles.Add(userRoleTwo);
                await _dbContext.SaveChangesAsync();
            }

            if (!_dbContext.Products.Any())
            {
                var product = new Product()
                {
                    Name = "Rower Górski",
                    Price = 1250.99M,
                    Description = "Szybki i wytrzymały rower górski.",
                };
                var img1 = new Image()
                {
                    FileName = "bicycle.jpg",
                    Product = product
                };
                var img2 = new Image()
                {
                    FileName = "bicycle2.jpg",
                    Product = product
                };
                product.Images.Add(img1);
                product.Images.Add(img2);


                var secondProduct = new Product()
                {
                    Name = "Kask",
                    Price = 129.99M,
                    Description = "Bardzo wytrzymały."
                };
                var listImg = new List<Image>()
                {
                    new Image()
                    {
                        FileName = "helmet.jpg",
                        Product = secondProduct
                    },
                    new Image()
                    {
                        FileName = "helmet2.jpg",
                        Product = secondProduct
                    }
                };
                secondProduct.Images.AddRange(listImg);
                var thirdProduct = new Product()
                {
                    Name = "Bidon",
                    Price = 30.99M,
                    Description = "Najlepszy bidon."
                };
                var listImgBidon = new List<Image>()
                {
                    new Image()
                    {
                        FileName = "bidon.jpg",
                        Product = thirdProduct
                    },
                    new Image()
                    {
                        FileName = "bidon2.jpg",
                        Product = thirdProduct
                    }
                };
                thirdProduct.Images.AddRange(listImgBidon);
                product.EncodeName();
                secondProduct.EncodeName();
                thirdProduct.EncodeName();
                _dbContext.Products.AddRange(product, secondProduct,thirdProduct);
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