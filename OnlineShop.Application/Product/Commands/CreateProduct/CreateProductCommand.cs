using MediatR;
using Microsoft.AspNetCore.Http;

namespace OnlineShop.Application.Product.Commands.CreateProduct
{
    public class CreateProductCommand: ProductDto, IRequest
    {
        public List<IFormFile> File { get; set; } = default!;
    }
}
