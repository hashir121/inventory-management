using InventoryProjectBackend.DTOs;
using InventoryProjectBackend.DTOs.Product;
using InventoryProjectBackend.Entities;
using InventoryProjectBackend.UOW;

namespace InventoryProjectBackend.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<AddResponse> AddProduct(AddProductDto add)
        {
            var response = new AddResponse("Product");

            Product product = new Product();
            product.Name = add.Name;
            product.Description = add.Description;
            product.CreatedDate = DateTime.Now;
            product.IsDeleted = false;

            await _unitOfWork.ProductRepository.InsertAsync(product);
            await _unitOfWork.SaveChangesAsync();



            return response;
        }
    }
}
