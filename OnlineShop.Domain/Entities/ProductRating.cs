using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Entities
{
    public class ProductRating
    {
        public int Id { get; set; }
       
        public int Rating { get; set; }
        public string? Description { get; set; } = default!;
        public DateTime CreatedAt { get; set; }=DateTime.Now;
        public string AppUserId { get; set; } = default!;
        public AppUser AppUser { get; set; } = default!;
        public int ProductId { get; set; } = default!;
        public Product Product { get; set; } = default!;


    }
}
