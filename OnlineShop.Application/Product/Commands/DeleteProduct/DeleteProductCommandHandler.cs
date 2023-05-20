using MediatR;
using OnlineShop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Application.Image.Command.Delete;

namespace OnlineShop.Application.Product.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductsRepository _repository;
        private readonly IMediator _mediator;
        public DeleteProductCommandHandler(IProductsRepository repository,IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product=await _repository.GetByEncodedName(request.EncodedName);
            await _repository.Delete(request.EncodedName);
            foreach (var item in product.Images)
            {
                _mediator.Send(new DeleteImageCommand(item.FileName));
            }
            return Unit.Value;
        }
    }
}
