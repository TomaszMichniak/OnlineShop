using MediatR;

namespace OnlineShop.Application.ProductRating.Commands.RefreshProductRating;

public class RefreshProductRatingCommand : IRequest
{
    public string ProductEncodedName { get; set; }

    public RefreshProductRatingCommand(string productEncodedName)
    {
        ProductEncodedName = productEncodedName;
    }
}