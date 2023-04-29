using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Paginations
{
	public class PagedResult<T>
	{
		public List<T> Items { get; set; }
		public int PageNumber { get; set; }
		public int TotalPages { get; set; }
		public int TotalItemsCount { get; set; }

		public PagedResult(List<T> items, int totalCount, int pageSize, int pageNumber)
		{
			Items = items;
			PageNumber = pageNumber;
			TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize); ;
			TotalItemsCount = totalCount;
		}
	}
	
}
