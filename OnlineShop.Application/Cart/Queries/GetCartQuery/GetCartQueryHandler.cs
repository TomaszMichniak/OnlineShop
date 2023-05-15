using AutoMapper;
using MediatR;
using OnlineShop.Application.ApplicationUser;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Cart.Queries.GetCartQuery
{
    public class GetCartQueryHandler : IRequestHandler<GetCartQuery, IEnumerable<CartPositionDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserContext _userContext;
        private readonly ICartPositionRepository _cartPositionRepository;
        private readonly IMapper _mapper;
        public GetCartQueryHandler(IUserRepository userRepository
            , ICartPositionRepository cartPositionRepository
            ,IMapper mapper
            , IUserContext userContext)
        {
            _userRepository = userRepository;
            _cartPositionRepository = cartPositionRepository;
            _userContext = userContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CartPositionDto>> Handle(GetCartQuery request, CancellationToken cancellationToken)
        {
            var user =_userContext.GetCurrentUser();
            if (user ==null)
            {
                return null;
            }
            var cartId=_userRepository.GetUserCartId(user.Id);
            var cart=await _cartPositionRepository.GetAllByCartId(cartId);
            var cartDto=_mapper.Map<IEnumerable<CartPositionDto>>(cart);
            return cartDto;
        }
    }
}
