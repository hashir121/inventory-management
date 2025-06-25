using InventoryProjectBackend.DTOs.Purchase;
using InventoryProjectBackend.DTOs;
using InventoryProjectBackend.Services.ProductService;
using InventoryProjectBackend.Services.PurchaseService;
using Microsoft.AspNetCore.Mvc;

namespace InventoryProjectBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        [HttpPost("add")]
        public async Task<AddResponse> Add(AddPurchaseDto add)
        {
            return await _purchaseService.Add(add);
        }

        [HttpPost("get-all")]
        public async Task<PagedList<GetPaginatedPurchase>> GetAllPurchasePaginated(PaginatedRequest get)
        {
            return await _purchaseService.GetAllPurchasePaginated(get);
        }

        [HttpGet("get-product-list")]
        public async Task<List<ProductDropdownDto>> GetProductList()
        {
            return await _purchaseService.GetProductList();
        }

        [HttpPut("update")]
        public async Task<UpdateResponse> Update(UpdatePurchaseDto up)
        {
            return await _purchaseService.Update(up);
        }

        [HttpDelete("delete/{purchaseId}")]
        public async Task<DeleteResponse> Delete(long? purchaseId)
        {
            return await _purchaseService.Delete(purchaseId);
        }
    }
}
