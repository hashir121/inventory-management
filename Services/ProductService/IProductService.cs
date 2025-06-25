using InventoryProjectBackend.DTOs.Product;
using InventoryProjectBackend.DTOs;

namespace InventoryProjectBackend.Services.ProductService
{
    public interface IProductService
    {
        Task<AddResponse> AddProduct(AddProductDto add);
    }
}
