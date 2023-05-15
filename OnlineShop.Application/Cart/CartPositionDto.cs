using OnlineShop.Application.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Cart
{
    public class CartPositionDto
    {
        public ProductDto ProductDto { get; set; } = default!;
        public int Count { get; set; }
    }
}
