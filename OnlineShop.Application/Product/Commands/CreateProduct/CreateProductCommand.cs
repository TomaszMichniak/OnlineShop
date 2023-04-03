using MediatR;

namespace OnlineShop.Application.Product.Commands.CreateProduct
{
    public class CreateProductCommand: ProductDto, IRequest
    {
    }
}
