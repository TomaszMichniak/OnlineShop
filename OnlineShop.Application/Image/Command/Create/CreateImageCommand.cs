using MediatR;
using Microsoft.AspNetCore.Http;

namespace OnlineShop.Application.Image.Command;

public class CreateImageCommand:IRequest
{
    public IFormFile File { get; set; } = default!;
}