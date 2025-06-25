using InventoryProjectBackend.DTOs.Purchase;
using InventoryProjectBackend.DTOs;

namespace InventoryProjectBackend.Services.PurchaseService
{
    public interface IPurchaseService
    {
        Task<AddResponse> Add(AddPurchaseDto add);

        Task<PagedList<GetPaginatedPurchase>> GetAllPurchasePaginated(PaginatedRequest get);
        Task<List<ProductDropdownDto>> GetProductList();
        Task<UpdateResponse> Update(UpdatePurchaseDto up);
        Task<DeleteResponse> Delete(long? purchaseId);
    }
}
