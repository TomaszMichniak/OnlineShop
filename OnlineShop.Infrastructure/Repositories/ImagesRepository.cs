using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Infrastructure.Database;

namespace OnlineShop.Infrastructure.Repositories;

public class ImagesRepository : IImagesRepository
{
    private readonly OnlineShopDbContext _dbContext;

    public ImagesRepository(OnlineShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Create(Image image)
    {
        _dbContext.Images.Add(image);
        await _dbContext.SaveChangesAsync();
    }
}