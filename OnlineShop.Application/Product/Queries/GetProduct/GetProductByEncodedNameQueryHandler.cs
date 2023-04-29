using AutoMapper;
using MediatR;
using OnlineShop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Product.Queries.GetProduct
{
	public class GetProductByEncodedNameQueryHandler : IRequestHandler<GetProductByEncodedNameQuery, ProductDto>
	{
		private readonly IProductsRepository _productsRepository;
		private readonly IMapper _mapper;

		public GetProductByEncodedNameQueryHandler(IProductsRepository productsRepository,IMapper mapper)
		{
			_productsRepository = productsRepository;
			_mapper = mapper;
		}
		public async Task<ProductDto> Handle(GetProductByEncodedNameQuery request, CancellationToken cancellationToken)
		{
			var product=await _productsRepository.GetByEncodedName(request.EncodedName);
			var productDto = _mapper.Map<ProductDto>(product);
			return productDto;
		}
	}
}
