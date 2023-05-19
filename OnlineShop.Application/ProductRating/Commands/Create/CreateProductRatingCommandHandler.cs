using MediatR;
using OnlineShop.Application.ApplicationUser;
using OnlineShop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Application.ProductRating.Commands.RefreshProductRating;

namespace OnlineShop.Application.ProductRating.Commands.Create
{
	public class CreateProductRatingCommandHandler : IRequestHandler<CreateProductRatingCommand>
	{
		private readonly IProductsRepository _productsRepository;
		private readonly IProductsRatingRepository _productsRatingRepository;
		private readonly IUserContext _userContext;
		private readonly IMediator _mediator;
		public CreateProductRatingCommandHandler(IProductsRepository productsRepository
			,IProductsRatingRepository productsRatingRepository, IUserContext userContext
			,IMediator mediator)
		{
			_productsRepository = productsRepository;
			_productsRatingRepository = productsRatingRepository;
			_userContext = userContext;
			_mediator = mediator;
		}

		public async Task<Unit> Handle(CreateProductRatingCommand request, CancellationToken cancellationToken)
		{
			var product = await _productsRepository.GetByEncodedName(request.ProductEncodedName!);
			var user = _userContext.GetCurrentUser();
			
			var productRating = new Domain.Entities.ProductRating()
			{
				ProductId = product.Id,
				AppUserId = user.Id,
				Rating = request.Rating,
				Description = request.Description,
			};
			await _productsRatingRepository.Create(productRating);
			await _mediator.Send(new RefreshProductRatingCommand(product.EncodedName));
			return Unit.Value;
		}
	}
}
