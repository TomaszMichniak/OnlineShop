using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Cart.Commands.DeleteFromCartCommand
{
	public class DeleteFromCartCommand:IRequest
	{
		public string ProductEncodedName { get; set; } = default!;
	}
}
