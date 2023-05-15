using MediatR;
using OnlineShop.Application.ApplicationUser;
using OnlineShop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Cart.Commands.MinusCount
{
    public class MinusCountCommandHandler : IRequestHandler<MinusCountCommand>
    {
        private readonly IUserContext _userContext;
        private readonly IUserRepository _userRepository;
        private readonly IProductsRepository _productsRepository;
        private readonly ICartPositionRepository _cartPositionRepository;
        public MinusCountCommandHandler(IUserContext userContext
            , IUserRepository userRepository
            , IProductsRepository productsRepository
            , ICartPositionRepository cartPositionRepository)
        {
            _userContext = userContext;
            _userRepository = userRepository;
            _productsRepository = productsRepository;
            _cartPositionRepository = cartPositionRepository;
        }
        public async Task<Unit> Handle(MinusCountCommand request, CancellationToken cancellationToken)
        {
            var user = _userContext.GetCurrentUser();
            var allUserData = await _userRepository.GetUserById(user.Id);
            var product = await _productsRepository.GetByEncodedName(request.ProductEncodedName);
            var cartPosition = await _cartPositionRepository.GetByCartIdAndProductId(allUserData.CartId, product.Id);
            if (cartPosition == null)
            {
                return Unit.Value;
            }
            if (cartPosition.Count==1)
            {
                await _cartPositionRepository.Delete(cartPosition);
                return Unit.Value;
            }
            await _cartPositionRepository.MinusCount(cartPosition);
            return Unit.Value;
        }
    }
}
