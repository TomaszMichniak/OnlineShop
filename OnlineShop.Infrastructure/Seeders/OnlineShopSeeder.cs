using OnlineShop.Domain.Entities;
using OnlineShop.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (!_dbContext.Products.Any())
            {
                var product = new Product()
                {
                    Name = "Rower Górski",
                    Price = 1250.99M,
                    Description = "Szybki i wytrzymały rower górski."
                };
                var secondProduct = new Product()
                {
                    Name = "Motocykl",
                    Price = 19653.99M,
                    Description = "Wytrzymały ale nie za szybki."
                };
                product.EncodeName();
                secondProduct.EncodeName();
                _dbContext.Products.AddRange(product,secondProduct);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
