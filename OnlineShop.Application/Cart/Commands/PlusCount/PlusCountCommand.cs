using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Cart.Commands.PlusCount
{
    public class PlusCountCommand:IRequest
    {
        public string ProductEncodedName { get; set; }

        public PlusCountCommand(string productEncodedName)
        {
            ProductEncodedName = productEncodedName;
        }
    }
}
