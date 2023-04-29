using OnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Interfaces
{
	public interface IProductsRatingRepository
	{
		public Task Create(ProductRating productRating);
		public Task<IEnumerable<ProductRating>> GetAllByProductEncodedName(string encodedName);
		public Task Delete(ProductRating product);
		public Task<ProductRating?> GetProductRating(int id);
	}
}
