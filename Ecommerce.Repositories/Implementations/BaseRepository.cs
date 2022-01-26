using System.Data;

namespace Ecommerce.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        public IDbConnection Database;
        public string Message { get; set; }
        public BaseRepository(IDapperContext dbContext)
        {
            Database = dbContext.CreateConnection();
        }
    }
}
