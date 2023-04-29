using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Domain.Entities
{
	public class CartPosition
	{
		[Key,Column(Order =0)]
		public int ProductId { get; set; }	
		[Key,Column(Order = 1)]
		public int CartId { get; set;}
		public Cart Cart { get; set; } = default!;
		public Product Product { get; set; } = default!;
		public int Count { get; set; }
	}
}