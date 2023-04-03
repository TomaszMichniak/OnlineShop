using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Product.Commands.DeleteProduct
{
    public class DeleteProductCommand :IRequest
    {
        public string EncodedName { get; set; }
        public DeleteProductCommand(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}
