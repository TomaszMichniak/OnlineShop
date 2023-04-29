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
	public class UserRepository : IUserRepository
	{
		private readonly OnlineShopDbContext _context;

		public UserRepository(OnlineShopDbContext context)
		{
			_context = context;
		}

		public async Task<AppUser?> GetUserById(string id)
		=> await _context.AppUsers.FindAsync(id);
	}
}
