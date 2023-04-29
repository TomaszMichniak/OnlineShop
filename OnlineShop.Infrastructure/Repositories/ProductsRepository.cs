using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Infrastructure.Database;

namespace OnlineShop.Infrastructure.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly OnlineShopDbContext _dbContext;

        public ProductsRepository(OnlineShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Product>> GetAll()
            => await _dbContext.Products.ToListAsync();

        public async Task Create(Product product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Product> GetByEncodedName(string encodedName)
            => await _dbContext.Products
                .Include(x => x.Images)
                .Include(x => x.ProductRatings)
                .ThenInclude(x => x.AppUser)
                .FirstAsync(x => x.EncodedName == encodedName);


        public Task<Domain.Entities.Product?> GetByName(string name)
            => _dbContext.Products
                .FirstOrDefaultAsync(x => x.Name.ToLower().Replace(" ", "-") == name.ToLower().Replace(" ", "-"));

        public async Task Delete(string encodedName)
        {
            var product = _dbContext.Products.First(x => x.EncodedName == encodedName);
            if (product != null)
            {
                _dbContext.Products.Remove(product);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}