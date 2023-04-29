using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Entities
{
	public class Cart
	{
		public int Id { get; set; }
		public ICollection<CartPosition> CartPositions { get; set; } = default!;
		public AppUser User { get; set; } = default!;
	}
}
