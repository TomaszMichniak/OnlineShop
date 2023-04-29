using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.ProductRating.Commands.Delete
{
	public class DeleteProductRatingCommand:IRequest
	{
		public int Id { get; set; }
	}
}
