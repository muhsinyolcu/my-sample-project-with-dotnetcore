using Common.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Product.WebApi.Services;

namespace Product.WebApi.Controllers.Product.v1
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductController : BaseApiController
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet()]
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpGet("getallproducts")]
        public IActionResult GetAlllProducts()
        {
            var products = _productService.GetAllProducts();
            return HttpEntity(products);
        }
    }
}