using AutoMapper;
using MediatR;
using OnlineShop.Application.ApplicationUser;
using OnlineShop.Application.Paginations;
using OnlineShop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.ProductRating.Query
{
    public class GetProductRatingsQueryHandler : IRequestHandler<GetProductRatingsQuery, PagedResult<ProductRatingDto>>
    {

        private readonly IProductsRatingRepository _productsRatingRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;
        public GetProductRatingsQueryHandler(IProductsRatingRepository productsRatingRepository, IMapper mapper, IUserContext userContext)
        {
            _productsRatingRepository = productsRatingRepository;
            _mapper = mapper;
            _userContext= userContext;
        }

        public async Task<PagedResult<ProductRatingDto>> Handle(GetProductRatingsQuery request, CancellationToken cancellationToken)
        {
            var baseQuery = await _productsRatingRepository.GetAllByProductEncodedName(request.EncodedName);
            var products = baseQuery
            .Skip(request.Pagination.PageSize * (request.Pagination.PageNumber - 1))
            .Take(request.Pagination.PageSize);

			var productsDto=_mapper.Map<List<ProductRatingDto>>(products);

            var totalCount = baseQuery.Count();
            var result = new PagedResult<ProductRatingDto>(productsDto,totalCount,request.Pagination.PageSize,request.Pagination.PageNumber);
            return result;
        }
    }
}
