using OnlineShop.Application.ApplicationUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Domain.Interfaces;
using MediatR;

namespace OnlineShop.Application.Cart.Commands.AddToCartCommand
{
	public class AddToCartCommandHandler:IRequestHandler<AddToCartCommand>
	{
		private readonly IUserContext _userContext;
		private readonly ICartPositionRepository _cartPositionRepository;
		private readonly IUserRepository _userRepository;
		private readonly IProductsRepository _productsRepository;
		public AddToCartCommandHandler(ICartPositionRepository cartPositionRepository, IUserContext userContext, IUserRepository userRepository, IProductsRepository productsRepository)
		{
			_cartPositionRepository = cartPositionRepository;
			_userContext = userContext;
			_userRepository = userRepository;
			_productsRepository = productsRepository;
		}

		public async Task<Unit> Handle(AddToCartCommand request, CancellationToken cancellationToken)
		{
			var user=_userContext.GetCurrentUser();
			var allUserData =await _userRepository.GetUserById(user.Id);
			var product =await _productsRepository.GetByEncodedName(request.EncodedNameProduct);
			var isExistCartPosition =await  _cartPositionRepository.GetByCartIdAndProductId(allUserData.CartId, product.Id);
			if (isExistCartPosition !=null)
			{
				await _cartPositionRepository.PlusCount(isExistCartPosition);
                return Unit.Value;
            }
			await _cartPositionRepository.Create(product.Id, allUserData.CartId);
			return Unit.Value;
		}
	}
}
