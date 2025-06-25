using InventoryProjectBackend.DTOs.Product;
using InventoryProjectBackend.DTOs;
using InventoryProjectBackend.Entities;

namespace InventoryProjectBackend.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<PagedList<GetPaginatedProduct>> GetAllProductPaginated(PaginatedRequest get);
    }
}
