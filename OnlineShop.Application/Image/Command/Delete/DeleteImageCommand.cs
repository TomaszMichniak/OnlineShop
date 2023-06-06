using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Image.Command.Delete
{
    public class DeleteImageCommand:IRequest
    {
        public DeleteImageCommand(string fileName)
        {
            FileName = fileName;
        }

        public string FileName { get; set; }=default!;
    }
}
