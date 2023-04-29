using OnlineShop.Application.ProductRating;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Application.Product
{
    public class ProductDto
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public string? EncodedName { get; set; }
        public List<Domain.Entities.Image> Images { get; set; } = new List<Domain.Entities.Image>();
    }
}
