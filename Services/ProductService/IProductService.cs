using InventoryProjectBackend.DTOs.Product;
using InventoryProjectBackend.DTOs;

namespace InventoryProjectBackend.Services.ProductService
{
    public interface IProductService
    {
        Task<AddResponse> AddProduct(AddProductDto add);

        Task<PagedList<GetPaginatedProduct>> GetAllProductPaginated(PaginatedRequest get);

        Task<UpdateResponse> Update(UpdateProductDto update);
        Task<DeleteResponse> Delete(long productId);
    }
}
