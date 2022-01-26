using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Ecommerce.Models;

namespace Ecommerce.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {

        public ProductRepository(IDapperContext context) : base(context)
        { }

        public async Task<List<Product>> GetList()
        {
            try
            {
                List<Product> list = (await Database.QueryAsync<Product>("SELECT * FROM Product")).AsList();
                return list;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}