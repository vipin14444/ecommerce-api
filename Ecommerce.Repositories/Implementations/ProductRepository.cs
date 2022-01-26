using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using Dapper;
using Ecommerce.Models;

namespace Ecommerce.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(IDapperContext context) :
            base(context)
        {
        }

        public async Task<List<Product>> GetList(IGridFilters filters)
        {
            try
            {
                string query = $"SELECT * FROM Product Order by ProductId OFFSET {filters.PageSize * filters.PageNo} Rows Fetch next {filters.PageSize} Rows Only";
                List<Product> list =
                    (await Database.QueryAsync<Product>(query))
                        .AsList();
                return list;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Product> GetProduct(int id)
        {
            try
            {
                Product product = await Database.GetAsync<Product>(id);
                if (product != null)
                {
                    string query = $"SELECT * FROM ProductAttribute where productid = {product.ProductId}";
                    product.ProdAttributes = (await Database.QueryAsync<ProductAttribute>(query)).AsList();
                }
                return product;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<ProductCategory>> GetAllProductCategory()
        {
            try
            {
                List<ProductCategory> list = (await Database.GetAllAsync<ProductCategory>()).AsList();
                return list;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task CreateProduct(Product product)
        {
            try
            {
                await Database.InsertAsync<Product>(product);
            }
            catch (Exception e)
            {
            }
        }
    }
}
