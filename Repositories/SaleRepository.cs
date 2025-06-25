using InventoryProjectBackend.Entities;
using InventoryProjectBackend.Interfaces;

namespace InventoryProjectBackend.Repositories
{
    public class SaleRepository : GenericRepository<Sale>, ISaleRepository
    {
        public readonly InventoryProjectContext _dbContext;

        public SaleRepository(InventoryProjectContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
