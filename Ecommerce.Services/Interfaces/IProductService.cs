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
        public Task EditProduct(ProductViewModel product);
        public Task<List<ProductAttributeLookupViewModel>> GetProductAttributeLookup(int CatId);
        public Task<ProductViewModel> GetProduct(int id);
    }
}
