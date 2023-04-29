using AutoMapper;
using OnlineShop.Application.ApplicationUser;
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
			CreateMap<Domain.Entities.Product, ProductDto>().ReverseMap();

			CreateMap<Domain.Entities.ProductRating, ProductRatingDto>()
				.ForMember(x => x.UserName, opt => opt.MapFrom(src => new AppUser()
				{
					UserName = src.AppUser.UserName,

				}))
				.ForMember(x=>x.IsDeleted,opt=> opt.MapFrom(src=> user!=null
					&&src.AppUserId==user.Id));


		}
	}
}
