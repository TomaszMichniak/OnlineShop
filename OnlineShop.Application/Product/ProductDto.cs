﻿using OnlineShop.Application.Image;
using OnlineShop.Application.ProductRating;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Application.Product
{
    public class ProductDto
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public decimal AverageRating { get; set; } = 5.0m;
        public string? EncodedName { get; set; }
        public List<ImageDto> Images { get; set; } = new List<ImageDto>();
    }
}
