using System.Linq.Expressions;

namespace InventoryProjectBackend.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task InsertAsync(TEntity entity);
        void Update(TEntity entity);
        Task<IEnumerable<TEntity>> FindByConditionAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity?> FindOneByConditionAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
