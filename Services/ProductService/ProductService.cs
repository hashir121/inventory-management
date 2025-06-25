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
            var existingProduct = await _unitOfWork.ProductRepository.FindOneByConditionAsync(x => !x.IsDeleted && (x.Name ?? "").ToLower() == (add.Name ?? "").ToLower());
            if (existingProduct != null)
            {
                response.Success = false;
                response.Message = "Product with the same name already exists";
                return response;
            }
            Product product = new Product();
            product.Name = add.Name;
            product.Description = add.Description;
            product.CreatedDate = DateTime.Now;
            product.IsDeleted = false;

            await _unitOfWork.ProductRepository.InsertAsync(product);
            await _unitOfWork.SaveChangesAsync();



            return response;
        }


        public async Task<PagedList<GetPaginatedProduct>> GetAllProductPaginated(PaginatedRequest get)
        {
            return await _unitOfWork.ProductRepository.GetAllProductPaginated(get);
        }
    }
}
