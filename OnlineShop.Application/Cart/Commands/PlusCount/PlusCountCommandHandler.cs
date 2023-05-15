using MediatR;
using OnlineShop.Application.ApplicationUser;
using OnlineShop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Cart.Commands.PlusCount
{
    public class PlusCountCommandHandler : IRequestHandler<PlusCountCommand>
    {
        private readonly IUserContext _userContext;
        private readonly IUserRepository _userRepository;
        private readonly IProductsRepository _productsRepository;
        private readonly ICartPositionRepository _cartPositionRepository;

        public PlusCountCommandHandler(IUserContext userContext
            , IUserRepository userRepository
            , IProductsRepository productsRepository
            , ICartPositionRepository cartPositionRepository)
        {
            _userContext = userContext;
            _userRepository = userRepository;
            _productsRepository = productsRepository;
            _cartPositionRepository = cartPositionRepository;
        }

        public async Task<Unit> Handle(PlusCountCommand request, CancellationToken cancellationToken)
        {
            var user = _userContext.GetCurrentUser();
            var allUserData = await _userRepository.GetUserById(user.Id);
            var product = await _productsRepository.GetByEncodedName(request.ProductEncodedName);
            var cartPosition = await _cartPositionRepository.GetByCartIdAndProductId(allUserData.CartId, product.Id);
            if (cartPosition == null)
            {
                return Unit.Value;
            }
            await _cartPositionRepository.PlusCount(cartPosition);
            return Unit.Value;

        }
    }
}
