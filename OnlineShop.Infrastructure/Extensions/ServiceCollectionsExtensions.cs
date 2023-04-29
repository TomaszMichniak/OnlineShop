using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Infrastructure.Database;
using OnlineShop.Infrastructure.Repositories;
using OnlineShop.Infrastructure.Seeders;

namespace OnlineShop.Infrastructure.Extensions
{
    public static class ServiceCollectionsExtensions
    {
        public static void AddInfrastructures(this IServiceCollection Services, IConfiguration Configuration) {

            Services.AddDbContext<OnlineShopDbContext>(options => options.UseSqlServer(
                   Configuration.GetConnectionString("DefaultConnection")));

            
            Services.AddDefaultIdentity<AppUser>()
                .AddEntityFrameworkStores<OnlineShopDbContext>();

            Services.AddScoped<OnlineShopSeeder>();
            Services.AddScoped<IImagesRepository, ImagesRepository>();
            Services.AddScoped<IProductsRepository, ProductsRepository>();
            Services.AddScoped<IProductsRatingRepository, ProductsRatingRepository>();
            Services.AddScoped<ICartPositionRepository, CartPositonRepository>();
            Services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
