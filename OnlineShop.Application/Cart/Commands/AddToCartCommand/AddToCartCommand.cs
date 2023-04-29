using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Cart.Commands.AddToCartCommand
{
	public class AddToCartCommand:IRequest
	{
		public string EncodedNameProduct { get; set; } = default!;
	}
}
