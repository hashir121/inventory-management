using InventoryProjectBackend.Entities;
using InventoryProjectBackend.Interfaces;

namespace InventoryProjectBackend.Repositories
{
    public class ProductRepository: GenericRepository<Product> , IProductRepository
    {
        public readonly InventoryProjectContext _dbContext;

        public ProductRepository(InventoryProjectContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
