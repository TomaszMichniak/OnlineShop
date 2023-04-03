using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; }=default!;
        public DateTime CreatedAt { get; set; }=DateTime.Now;
        public decimal Price { get; set; } = default!;
        public string EncodedName { get; private set; }=default!;


        public void EncodeName() => EncodedName = Name.ToLower().Replace(" ", "-");
    }
}
