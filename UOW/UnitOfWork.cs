using InventoryProjectBackend.Entities;
using InventoryProjectBackend.Interfaces;

namespace InventoryProjectBackend.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InventoryProjectContext _dbContext;

        public IProductRepository ProductRepository { get; set; }
        public IPurchaseRepository PurchaseRepository { get; set; }
        public ISaleRepository SaleRepository { get; set; }
        public UnitOfWork(InventoryProjectContext dbContext,
            IProductRepository productRepository,
            IPurchaseRepository purchaseRepository,
            ISaleRepository saleRepository
            )
        {
            _dbContext = dbContext;
            ProductRepository = productRepository;
            PurchaseRepository = purchaseRepository;
            SaleRepository = saleRepository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
