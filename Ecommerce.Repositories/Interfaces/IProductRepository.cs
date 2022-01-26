using System.Collections.Generic;
using System.Threading.Tasks;
using Ecommerce.Models;

namespace Ecommerce.Repositories
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetList();
    }
}
