using MediatR;
using OnlineShop.Application.ApplicationUser;
using OnlineShop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Cart.Commands.DeleteFromCartCommand
{
	public class DeleteFromCartCommandHandler : IRequestHandler<DeleteFromCartCommand>
	{
		private readonly IUserRepository _userRepository;
		private readonly ICartPositionRepository _cartPositionRepository;
		private readonly IUserContext _userContext;
		private readonly IProductsRepository _productsRepository;

		public DeleteFromCartCommandHandler(IUserRepository userRepository
			, ICartPositionRepository cartPositionRepository
			, IUserContext userContext
			, IProductsRepository productsRepository)
		{
			_userRepository = userRepository;
			_cartPositionRepository = cartPositionRepository;
			_userContext = userContext;
			_productsRepository = productsRepository;
		}

		public async Task<Unit> Handle(DeleteFromCartCommand request, CancellationToken cancellationToken)
		{
			var user=_userContext.GetCurrentUser();
			if (user == null)
				return Unit.Value;
			var cartId = _userRepository.GetUserCartId(user.Id);
			var productId = _productsRepository.GetByEncodedName(request.ProductEncodedName).Result.Id;
			var cartPosition=_cartPositionRepository.GetByCartIdAndProductId(cartId,productId).Result;
			if (cartPosition !=null)
			{
				await _cartPositionRepository.Delete(cartPosition);
			}
			return Unit.Value;
		}
	}
}
