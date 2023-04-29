using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.ProductRating.Commands.Create
{
    public class CreateProductRatingCommand : ProductRatingDto, IRequest
    {
        public string ProductEncodedName { get; set; } = default!;

    }
}
