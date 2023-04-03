using AutoMapper;
using MediatR;
using OnlineShop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Product.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductsRepository productsRepository,IMapper mapper)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product=_mapper.Map<Domain.Entities.Product>(request);
            product.EncodeName();
            await _productsRepository.Create(product);
            return Unit.Value;
        }
    }
}
