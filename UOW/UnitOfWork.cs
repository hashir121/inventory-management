using InventoryProjectBackend.Entities;
using InventoryProjectBackend.Interfaces;

namespace InventoryProjectBackend.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InventoryProjectContext _dbContext;

        public IProductRepository ProductRepository { get; set; }
        public UnitOfWork(InventoryProjectContext dbContext,
            IProductRepository productRepository
            )
        {
            _dbContext = dbContext;
            ProductRepository = productRepository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
