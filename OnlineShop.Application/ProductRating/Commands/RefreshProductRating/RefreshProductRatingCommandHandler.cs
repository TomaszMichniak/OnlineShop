using MediatR;
using OnlineShop.Domain.Interfaces;

namespace OnlineShop.Application.ProductRating.Commands.RefreshProductRating;

public class RefreshProductRatingCommandHandler:IRequestHandler<RefreshProductRatingCommand>
{
    private readonly IProductsRepository _productsRepository;

    public RefreshProductRatingCommandHandler(IProductsRepository productsRepository)
    {
        _productsRepository = productsRepository;
    }

    public async Task<Unit> Handle(RefreshProductRatingCommand request, CancellationToken cancellationToken)
    {
        var product=await _productsRepository.GetByEncodedName(request.ProductEncodedName);
        var allRatings=product.ProductRatings.Count();
        decimal sum = 0.0m;
        foreach (var item in product.ProductRatings)
        {
            sum +=item.Rating;
        }

        var average = sum / allRatings;
        product.AverageRating = average;
        await _productsRepository.Update(product);
        return Unit.Value;
    }
}