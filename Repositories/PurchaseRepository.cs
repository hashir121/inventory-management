using InventoryProjectBackend.Entities;
using InventoryProjectBackend.Interfaces;

namespace InventoryProjectBackend.Repositories
{
    public class PurchaseRepository : GenericRepository<Purchase>, IPurchaseRepository
    {
        public readonly InventoryProjectContext _dbContext;

        public PurchaseRepository(InventoryProjectContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
