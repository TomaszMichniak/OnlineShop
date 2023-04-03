using AutoMapper;
using OnlineShop.Application.Product;

namespace OnlineShop.Application.Mapping
{
    public class ProductsMappingProfil : Profile
    {
        public ProductsMappingProfil() {
            CreateMap<Domain.Entities.Product, ProductDto>().ReverseMap();
        
        }
    }
}
