using Order.Domain.Entities.Base;

namespace Order.Domain.IGenericRepository
{
    public interface IGenericRepository <TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetEntitiesQuery();
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task AddEntity(TEntity entity);
        void UpdateEntity(TEntity entity);
        void RemoveEntity(TEntity entity);
        Task RemoveEntity(int entityId);
        Task SaveChangesAsync();
        void SaveChanges();
    }
}
