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

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            try
            {
                List<ProductViewModel> list = await _productService.GetList();
                return Ok(new { StatusCode = 200, StatusMessage = "Success", Payload = list });
            }
            catch (Exception e)
            {
                return Ok(new { StatusCode = 500, StatusMessage = e.Message });
            }
        }

        // [AllowAnonymous]
        // [HttpPost]
        // public async Task<IActionResult> Post([FromBody] User user)
        // {
        //     try
        //     {
        //         await _productService.Create(user);
        //         return Ok(new { StatusCode = 200, StatusMessage = "Success" });
        //     }
        //     catch (Exception e)
        //     {
        //         _logger.LogError(e.Message, e);
        //         return Ok(new { StatusCode = 500, StatusMessage = e.Message });
        //     }
        // }
    }
}
