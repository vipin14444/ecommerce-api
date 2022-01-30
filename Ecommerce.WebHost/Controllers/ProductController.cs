using System;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Services;
using Ecommerce.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.WebHost.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : BaseController
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // Get All Products.
        [HttpPost("GetList")]
        public async Task<IActionResult> GetList([FromBody] GridFilters filters)
        {
            try
            {
                var data = await _productService.GetList(filters);
                return Ok(new { StatusCode = 200, StatusMessage = "Success", Payload = data });
            }
            catch (Exception e)
            {
                return Ok(new { StatusCode = 500, StatusMessage = e.Message });
            }
        }

        // Get All Product Categories For Dropdown.
        [HttpGet("GetAllProductCategory")]
        public async Task<IActionResult> GetAllProductCategory()
        {
            try
            {
                List<ProductCategoryViewModel> list = await _productService.GetAllProductCategory();
                return Ok(new { StatusCode = 200, StatusMessage = "Success", Payload = list });
            }
            catch (Exception e)
            {
                return Ok(new { StatusCode = 500, StatusMessage = e.Message });
            }
        }

        // Get Single Product By Id.
        [HttpGet("GetProduct")]
        public async Task<IActionResult> GetProduct(int id)
        {
            try
            {
                ProductViewModel product = await _productService.GetProduct(id);
                return Ok(new { StatusCode = 200, StatusMessage = "Success", Payload = product });
            }
            catch (Exception e)
            {
                return Ok(new { StatusCode = 500, StatusMessage = e.Message });
            }
        }

        // Create New Record in Product Table and Add It's Attributes to Atributes Table.
        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductViewModel product)
        {
            try
            {
                await _productService.CreateProduct(product);
                return Ok(new { StatusCode = 200, StatusMessage = "Success" });
            }
            catch (Exception e)
            {
                return Ok(new { StatusCode = 500, StatusMessage = e.Message });
            }
        }

        // Edit Existing Product and Attributes.
        [HttpPost("EditProduct")]
        public async Task<IActionResult> EditProduct([FromBody] ProductViewModel product)
        {
            try
            {
                await _productService.EditProduct(product);
                return Ok(new { StatusCode = 200, StatusMessage = "Success" });
            }
            catch (Exception e)
            {
                return Ok(new { StatusCode = 500, StatusMessage = e.Message });
            }
        }

        // Get All Attributes From ProductAttributeLookup Table Based on Category Selected. 
        [HttpGet("GetProductAttributeLookup")]
        public async Task<IActionResult> GetProductAttributeLookup(int CatId)
        {
            try
            {
                List<ProductAttributeLookupViewModel> list = await _productService.GetProductAttributeLookup(CatId);
                return Ok(new { StatusCode = 200, StatusMessage = "Success", Payload = list });
            }
            catch (Exception e)
            {
                return Ok(new { StatusCode = 500, StatusMessage = e.Message });
            }
        }
    }
}
