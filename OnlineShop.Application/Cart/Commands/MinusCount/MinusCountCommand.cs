using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Cart.Commands.MinusCount
{
    public class MinusCountCommand:IRequest
    {
        public string ProductEncodedName { get; set; }

        public MinusCountCommand(string productEncodedName)
        {
            ProductEncodedName = productEncodedName;
        }
    }
}
