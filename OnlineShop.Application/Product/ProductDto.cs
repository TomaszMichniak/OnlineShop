namespace OnlineShop.Application.Product
{
    public class ProductDto
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public string? EncodedName { get; set; }
        
    }
}
