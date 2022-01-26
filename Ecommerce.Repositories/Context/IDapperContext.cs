using System.Data;

namespace Ecommerce.Repositories
{
    public interface IDapperContext
    {
        public IDbConnection CreateConnection();
    }
}