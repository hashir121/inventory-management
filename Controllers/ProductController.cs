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

        [HttpPost("add")]
        public async Task<AddResponse> AddProduct(AddProductDto add)
        {
            return await _productService.AddProduct(add);
        }

        [HttpPost("get-all")]
        public async Task<PagedList<GetPaginatedProduct>> GetAllProductPaginated(PaginatedRequest get)
        {
            return await _productService.GetAllProductPaginated(get);
        }

        [HttpPut("update")]
        public async Task<UpdateResponse> Update(UpdateProductDto update)
        {
            return await _productService.Update(update);
        }

        [HttpDelete("delete/{productId}")]
        public async Task<DeleteResponse> Delete(long productId)
        {
            return await _productService.Delete(productId);
        }
    }
}
