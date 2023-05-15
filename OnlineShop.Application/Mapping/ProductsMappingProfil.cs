using AutoMapper;
using OnlineShop.Application.ApplicationUser;
using OnlineShop.Application.Cart;
using OnlineShop.Application.Image;
using OnlineShop.Application.Product;
using OnlineShop.Application.ProductRating;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Application.Mapping
{
	public class ProductsMappingProfil : Profile
	{
		public ProductsMappingProfil(IUserContext userContext)
		{
			var user =userContext.GetCurrentUser();

			CreateMap<Domain.Entities.Image,ImageDto>()
				.ForMember(x=>x.ProductEncodedName
					,opt=>opt.MapFrom(src=>src.Product.EncodedName))
				.ReverseMap();

			CreateMap<Domain.Entities.Product, ProductDto>()
                .ForMember(x => x.Images
                    , opt => opt.MapFrom(src => src.Images))
				.ForMember(x=>x.Price,
					opt=>opt.MapFrom(src=>src.Price.ToString("0.00")))
				.ReverseMap();

			CreateMap<Domain.Entities.ProductRating, ProductRatingDto>()
				.ForMember(x => x.UserName, opt => opt.MapFrom(src => new AppUser()
				{
					UserName = src.AppUser.UserName,

				}))
				.ForMember(x=>x.IsDeleted,opt=> opt.MapFrom(src=> user!=null
					&&src.AppUserId==user.Id));
			CreateMap<Domain.Entities.CartPosition, CartPositionDto>()
				.ForMember(x => x.ProductDto
					, opt => opt.MapFrom(src => src.Product));

        }
    }
}
