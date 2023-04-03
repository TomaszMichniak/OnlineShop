using OnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Interfaces
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task Create(Product product);
        Task Delete(string encodedName);
        Task<Domain.Entities.Product?> GetByName(string name);
    }
}

