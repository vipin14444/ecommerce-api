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

        [HttpPost]
        public async Task<IActionResult> GetList([FromBody] IGridFilters filters)
        {
            try
            {
                List<ProductViewModel> list = await _productService.GetList(filters);
                return Ok(new { StatusCode = 200, StatusMessage = "Success", Payload = list });
            }
            catch (Exception e)
            {
                return Ok(new { StatusCode = 500, StatusMessage = e.Message });
            }
        }

        [HttpGet("/GetAllProductCategory")]
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

        [HttpPost]
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
    }
}
