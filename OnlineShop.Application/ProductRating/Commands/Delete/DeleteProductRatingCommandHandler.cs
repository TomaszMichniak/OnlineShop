using MediatR;
using OnlineShop.Application.ApplicationUser;
using OnlineShop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Application.ProductRating.Commands.RefreshProductRating;

namespace OnlineShop.Application.ProductRating.Commands.Delete
{
	public class DeleteProductRatingCommandHandler : IRequestHandler<DeleteProductRatingCommand>
	{
		private readonly IProductsRatingRepository _productsRatingRepository;
		private readonly IUserContext _userContext;
		private readonly IMediator _mediator;
		public DeleteProductRatingCommandHandler(IProductsRatingRepository productsRatingRepository, IUserContext userContext
		,IMediator mediator)
		{
			_productsRatingRepository = productsRatingRepository;
			_userContext = userContext;
			_mediator = mediator;
		}

		public async Task<Unit> Handle(DeleteProductRatingCommand request, CancellationToken cancellationToken)
		{
			var rating = await _productsRatingRepository.GetProductRating(request.Id);
			var user = _userContext.GetCurrentUser();
			if (rating != null && user != null)
			{
				if (rating.AppUserId == user.Id)
				{
					await _productsRatingRepository.Delete(rating);
				}
			}
			await _mediator.Send(new RefreshProductRatingCommand(rating.Product.EncodedName));
			return Unit.Value;
		}
	}
}
