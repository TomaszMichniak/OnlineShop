using OnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Interfaces
{
	public interface ICartPositionRepository
	{
		public Task Create(int productId, int cartId);
		public Task<CartPosition?> GetByCartIdAndProductId(int cartId, int productId);
		public Task PlusCount(CartPosition cartPosition);
		public Task MinusCount(CartPosition cartPosition);
		public Task<IEnumerable<CartPosition?>> GetAllByCartId(int cartId);
		public Task Delete(CartPosition cartPosition);


	}
}
