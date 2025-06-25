

using InventoryProjectBackend.Interfaces;

namespace InventoryProjectBackend.UOW
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; set; }
        IPurchaseRepository PurchaseRepository { get; set; }
        ISaleRepository SaleRepository { get; set; }    



        Task<int> SaveChangesAsync();
    }
}
