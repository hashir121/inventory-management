using InventoryProjectBackend.DTOs;
using InventoryProjectBackend.DTOs.Purchase;
using InventoryProjectBackend.Entities;
using InventoryProjectBackend.UOW;

namespace InventoryProjectBackend.Services.PurchaseService
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PurchaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AddResponse> Add(AddPurchaseDto add)
        {
            var response = new AddResponse("Purchase");

            var productEntity = await _unitOfWork.ProductRepository.FindOneByConditionAsync(x => !x.IsDeleted && x.Id == add.ProductId);
            if (productEntity == null)
            {
                response.Success = false;
                response.Message = "Product with the ID does not exist";
                return response;
            }

            Purchase purchaseEntity = new Purchase();

            purchaseEntity.ProductId = add.ProductId;
            purchaseEntity.Quantity = add.Quantity;
            purchaseEntity.Price = add.Price;
            purchaseEntity.CreatedDate = DateTime.Now;
            purchaseEntity.IsDeleted = false;

            await _unitOfWork.PurchaseRepository.InsertAsync(purchaseEntity);
            await _unitOfWork.SaveChangesAsync();

            return response;
        }


        public async Task<PagedList<GetPaginatedPurchase>> GetAllPurchasePaginated(PaginatedRequest get)
        {
            return await _unitOfWork.PurchaseRepository.GetAllPurchasePaginated(get);
        }

        public async Task<List<ProductDropdownDto>> GetProductList()
        {
            return await _unitOfWork.PurchaseRepository.GetProductList();
        }


        public async Task<UpdateResponse> Update(UpdatePurchaseDto up)
        {
            var response = new UpdateResponse();

            var purchaseEntity = await _unitOfWork.PurchaseRepository.FindOneByConditionAsync(x => !x.IsDeleted && x.Id == up.Id);
            if (purchaseEntity == null)
            {
                response.Success = false;
                response.Message = "Purchase with the ID does not exist";
                return response;
            }

            var productEntity = await _unitOfWork.ProductRepository.FindOneByConditionAsync(x => !x.IsDeleted && x.Id == up.ProductId);
            if (productEntity == null)
            {
                response.Success = false;
                response.Message = "Product with the ID does not exist";
                return response;

            }

            purchaseEntity.ProductId = up.ProductId;
            purchaseEntity.Quantity = up.Quantity;
            purchaseEntity.Price = up.Price;

            _unitOfWork.PurchaseRepository.Update(purchaseEntity);
            await _unitOfWork.SaveChangesAsync();

            response.Success = true;
            response.Message = "Purchase updated successfully";
            return response;

        }

        public async Task<DeleteResponse> Delete(long? purchaseId)
        {
            var response = new DeleteResponse();

            var purchaseEntity = await _unitOfWork.PurchaseRepository.FindOneByConditionAsync(x => !x.IsDeleted && x.Id == purchaseId);
            if (purchaseEntity == null)
            {
                response.Success = false;
                response.Message = "Purchase ID does not exist";
                return response;
            }
            purchaseEntity.IsDeleted = true;


            _unitOfWork.PurchaseRepository.Update(purchaseEntity);
            await _unitOfWork.SaveChangesAsync();

            response.Success = true;
            response.Message = "Purchase entity deleted successfully";
            return response;

        }
    }
}
