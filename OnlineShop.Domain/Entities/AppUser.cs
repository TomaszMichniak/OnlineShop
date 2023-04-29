using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Entities
{
    public class AppUser: IdentityUser
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; }=default!;
        public List<ProductRating> ProductRatings { get; set; }  = new ();
        public int CartId { get; set; } = default!;
        public Cart Cart { get; set; }=new ();
    }
}
