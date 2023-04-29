using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Product.Queries.GetProduct
{
	public class GetProductByEncodedNameQuery : IRequest<ProductDto>
	{
		public string EncodedName { get; set; }
		public GetProductByEncodedNameQuery(string encodedName)
		{
			EncodedName = encodedName;
		}
	}
}
