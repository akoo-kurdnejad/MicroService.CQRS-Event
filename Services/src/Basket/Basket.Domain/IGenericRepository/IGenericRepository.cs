using Basket.Domain.Entities.Base;

namespace Basket.Domain.IGenericRepository
{
    public interface IGenericRepository <TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetEntitiesQuery();
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task AddEntity(TEntity entity);
        TEntity UpdateEntity(TEntity entity);
        Task RemoveEntity(int entityId);
        Task SaveChangesAsync();
        void SaveChanges();
    }
}
