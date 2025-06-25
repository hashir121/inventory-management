using InventoryProjectBackend.Entities;
using InventoryProjectBackend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventoryProjectBackend.Repositories
{
    public class GenericRepository<TEntity>: IGenericRepository<TEntity> where TEntity : class
    {
        private readonly InventoryProjectContext _dbContext;
        private DbSet<TEntity> _entities;

        public GenericRepository(InventoryProjectContext dbContext)
        {
            _dbContext = dbContext;
            _entities = _dbContext.Set<TEntity>();
        }


        public async Task InsertAsync(TEntity entity)
        {
            await _entities.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            _entities.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        

    }
}
