using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Paginations
{
	public class Pagination
	{
		public string? SearchPhrase { get; set; } = default!;
		public int PageNumber { get; set; } = 1;
		public int PageSize { get; set; } = 5;

		
	}
}
