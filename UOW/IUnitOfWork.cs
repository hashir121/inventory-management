

using InventoryProjectBackend.Interfaces;

namespace InventoryProjectBackend.UOW
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; set; }



        Task<int> SaveChangesAsync();
    }
}
