using System.Collections.Generic;
using System.Threading.Tasks;
using Ecommerce.Models;

namespace Ecommerce.Services
{
    public interface IProductService
    {
        public Task<List<ProductViewModel>> GetList();
        // public Task Create(User user);
        // public Task<List<UserViewModel>> Read();
        // public Task<UserViewModel> Read(string id);
    }
}
