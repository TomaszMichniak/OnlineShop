namespace OnlineShop.Domain.Entities;

public class Image
{
    public int Id { get; set; }
    public string FileName { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
}