using System.Collections.Generic;
using System.Threading.Tasks;
using Ecommerce.Models;

namespace Ecommerce.Repositories
{
    public interface IBaseRepository
    {
        public string Message { get; set; }
    }
}
