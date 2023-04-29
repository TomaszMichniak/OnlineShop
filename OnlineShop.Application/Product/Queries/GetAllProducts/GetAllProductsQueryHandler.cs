using AutoMapper;
using MediatR;
using OnlineShop.Domain.Interfaces;

namespace OnlineShop.Application.Product.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
    {
        private readonly IMapper _mapper;
        private readonly IProductsRepository _productsRepository;

        public GetAllProductsQueryHandler(IProductsRepository productsRepository, IMapper mapper)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productsRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<ProductDto>>(products);
            return dtos;
        }

    }
}
