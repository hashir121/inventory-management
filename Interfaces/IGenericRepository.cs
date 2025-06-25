namespace InventoryProjectBackend.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task InsertAsync(TEntity entity);
        void Update(TEntity entity);
    }
}
