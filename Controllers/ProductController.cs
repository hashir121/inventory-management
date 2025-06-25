using InventoryProjectBackend.DTOs;
using InventoryProjectBackend.DTOs.Product;
using InventoryProjectBackend.Services.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace InventoryProjectBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("add-product")]
        public async Task<AddResponse> AddProduct(AddProductDto add)
        {
            return await _productService.AddProduct(add);
        }
    }
}
