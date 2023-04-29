using AutoMapper;
using MediatR;
using OnlineShop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Application.Image.Command;

namespace OnlineShop.Application.Product.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;


        public CreateProductCommandHandler(IProductsRepository productsRepository, IMapper mapper, IMediator mediator)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Domain.Entities.Product>(request);
            foreach (var item in request.File)
            {
                await _mediator.Send(new CreateImageCommand() { File = item });
                var newImg = new Domain.Entities.Image()
                {
                    Product = product,
                    FileName = item.FileName
                };
                product.Images.Add(newImg);
            }

            product.EncodeName();
            await _productsRepository.Create(product);
            return Unit.Value;
        }
    }
}