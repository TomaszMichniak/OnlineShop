using OnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Interfaces
{
	public interface IUserRepository
	{
		public Task<AppUser?> GetUserById(string id);
	}
}
