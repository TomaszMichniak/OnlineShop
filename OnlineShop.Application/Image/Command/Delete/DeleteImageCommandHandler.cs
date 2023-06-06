using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace OnlineShop.Application.Image.Command.Delete
{
    public class DeleteImageCommandHandler : IRequestHandler<DeleteImageCommand>
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public DeleteImageCommandHandler(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        public Task<Unit> Handle(DeleteImageCommand request, CancellationToken cancellationToken)
        { 
            var filePath = Path.Combine(_hostEnvironment.WebRootPath, "Img", request.FileName);
            File.Delete(filePath);
            return Unit.Task;
        }
    }
}
