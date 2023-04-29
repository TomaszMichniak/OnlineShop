using OnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.ProductRating
{
    public class ProductRatingDto
    {
        public int Id { get; set; } 
        public int Rating { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? UserName { get; set; }
        public bool? IsDeleted { get; set; }

    }
}
