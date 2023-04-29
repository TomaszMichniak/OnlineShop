using MediatR;
using Microsoft.AspNetCore.Hosting;
using OnlineShop.Domain.Interfaces;

namespace OnlineShop.Application.Image.Command.Create;

public class CreateImageCommandHandler : IRequestHandler<CreateImageCommand>
{
    private readonly IWebHostEnvironment _hostEnvironment;
    private readonly IImagesRepository _imagesRepository;

    public CreateImageCommandHandler(IWebHostEnvironment hostEnvironment, IImagesRepository imagesRepository)
    {
        _hostEnvironment = hostEnvironment;
        _imagesRepository = imagesRepository;
    }

    public async Task<Unit> Handle(CreateImageCommand request, CancellationToken cancellationToken)
    {
        var filePath = Path.Combine(_hostEnvironment.WebRootPath, "Img", request.File.FileName);
       await using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await request.File.CopyToAsync(stream);
        }
        
        return Unit.Value;
    }
}