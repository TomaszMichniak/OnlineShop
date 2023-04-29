using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Infrastructure.Database;

namespace OnlineShop.Infrastructure.Repositories
{
	public class ProductsRatingRepository : IProductsRatingRepository
	{
		private readonly OnlineShopDbContext _dbContext;

		public ProductsRatingRepository(OnlineShopDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task Create(ProductRating productRating)
		{
			_dbContext.ProductRatings.Add(productRating);
			await _dbContext.SaveChangesAsync();
		}
		public async Task<IEnumerable<ProductRating>> GetAllByProductEncodedName(string encodedName)
		=> await _dbContext.ProductRatings.Where(x => x.Product.EncodedName == encodedName)
				.Include(x => x.AppUser)
				.OrderByDescending(x => x.CreatedAt)
				.ToListAsync();

		public async Task<ProductRating?> GetProductRating(int id)
		=> await _dbContext.ProductRatings.FirstOrDefaultAsync(x => x.Id == id);
		public async Task Delete(ProductRating product)
		{
			_dbContext.Remove(product);
			await _dbContext.SaveChangesAsync();
		}
	}
}
