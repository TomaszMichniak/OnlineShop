using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Paginations
{
    public class Pagination
    {
        public string SearchPhrase { get; set; }=default!;
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
