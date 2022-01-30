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

        public async Task<List<ProductAttributeLookup>> GetProductAttributeLookup(int CatId)
        {
            try
            {
                string query = $"SELECT * FROM ProductAttributeLookup where ProdCatId={CatId}";
                List<ProductAttributeLookup> list =
                    (await Database.QueryAsync<ProductAttributeLookup>(query))
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
                    string query = $"SELECT PA.*, PAL.AttributeName FROM ProductAttribute AS PA LEFT JOIN ProductAttributeLookup AS PAL ON PA.AttributeId=PAL.AttributeId where productid = {product.ProductId} ";
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
                int id = await Database.InsertAsync<Product>(product);
                if (id != null && id != 0)
                {
                    foreach (ProductAttribute attribute in product.ProdAttributes)
                    {
                        attribute.ProductId = id;
                        await Database.InsertAsync<ProductAttribute>(attribute);
                    }
                }
            }
            catch (Exception e)
            {
            }
        }
        public async Task EditProduct(Product product)
        {
            try
            {
                // Update Product
                bool id = await Database.UpdateAsync<Product>(product);
                if (id && product.ProductId != 0 && product.ProductId != null)
                {
                    // Delete Previous Attributes
                    string query = $"Delete FROM ProductAttribute where productid = {product.ProductId}";
                    await Database.QueryAsync<ProductAttribute>(query);
                    // Add New Attributes
                    foreach (ProductAttribute attribute in product.ProdAttributes)
                    {
                        attribute.ProductId = product.ProductId;
                        await Database.InsertAsync<ProductAttribute>(attribute);
                    }
                }
            }
            catch (Exception e)
            {
            }
        }
    }
}
