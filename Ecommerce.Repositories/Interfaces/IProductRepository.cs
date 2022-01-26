using System.Collections.Generic;
using System.Threading.Tasks;
using Ecommerce.Models;

namespace Ecommerce.Repositories
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetList(IGridFilters filters);
        public Task<List<ProductCategory>> GetAllProductCategory();
        public Task CreateProduct(Product product);
        public Task<Product> GetProduct(int id);
        public Task<List<ProductAttributeLookup>> GetProductAttributeLookup(int CatId);
    }
}
