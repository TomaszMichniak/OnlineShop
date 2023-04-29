using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Repositories
{
	public class CartPositonRepository:ICartPositionRepository
	{
		private readonly OnlineShopDbContext _context;

		public CartPositonRepository(OnlineShopDbContext context)
		{
			_context = context;
		}

		public async Task Create(int productId,int cartId) 
		{
			var newCartPosition = new CartPosition()
			{
				ProductId = productId,
				CartId = cartId,
				Count = 1
			};
			_context.CartPositions.Add(newCartPosition);
			await _context.SaveChangesAsync();
		}
		public async Task<CartPosition?> GetByCartIdAndProductId(int cartId, int productId)
		=> await _context.CartPositions
				.Where(x => x.CartId == cartId)
				.Where(x => x.ProductId == productId)
				.FirstOrDefaultAsync();
		public async Task PlusCount(CartPosition cartPosition)
		{
			cartPosition.Count++;
			await _context.SaveChangesAsync();
		}		
		
	}
}
