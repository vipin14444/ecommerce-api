using System.Collections.Generic;
using System.Threading.Tasks;
using Ecommerce.Models;

namespace Ecommerce.Services
{
    public interface IProductService
    {
        public Task<List<ProductViewModel>> GetList(IGridFilters filters);
        public Task<List<ProductCategoryViewModel>> GetAllProductCategory();
        public Task CreateProduct(ProductViewModel product);
        public Task<ProductViewModel> GetProduct(int id);
    }
}
