using InventoryProjectBackend.DTOs.Purchase;
using InventoryProjectBackend.DTOs;
using InventoryProjectBackend.Entities;

namespace InventoryProjectBackend.Interfaces
{
    public interface IPurchaseRepository : IGenericRepository<Purchase>
    {
        Task<PagedList<GetPaginatedPurchase>> GetAllPurchasePaginated(PaginatedRequest get);
        Task<List<ProductDropdownDto>> GetProductList();
    }
}
