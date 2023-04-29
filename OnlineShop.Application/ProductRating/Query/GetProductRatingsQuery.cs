using MediatR;
using OnlineShop.Application.Paginations;

namespace OnlineShop.Application.ProductRating.Query
{
    public class GetProductRatingsQuery : IRequest<PagedResult<ProductRatingDto>>
    {
        public string EncodedName { get; set; } = default!;
        public Pagination Pagination { get; set; } = default!;
	}
}
