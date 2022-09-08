using Basket.DataAccess;
using Basket.Domain.Entities.Base;
using Basket.Domain.IGenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Basket.DataAccess.GenericRepository
{

    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        #region Constractor

        private readonly DataContext DatabaseContext;
        private readonly DbSet<TEntity> DbSet;

        public GenericRepository(DataContext databaseContext)
        {
            this.DatabaseContext = databaseContext;
            this.DbSet = databaseContext.Set<TEntity>();
        }

        #endregion

        public IQueryable<TEntity> GetEntitiesQuery()
        {
            return DbSet.AsQueryable();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await DbSet.SingleOrDefaultAsync(current => current.Id == id);
        }

        public async Task AddEntity(TEntity entity)
        {
            entity.CreateDate = DateTime.Now;
            await DbSet.AddAsync(entity);
        }

        public TEntity UpdateEntity(TEntity entity)
        {
            var result = DbSet.Update(entity);

            return result.Entity;
        }

        public async Task RemoveEntity(int entityId)
        {
            var entity = await GetByIdAsync(entityId);
            DbSet.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await DatabaseContext.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            DatabaseContext.SaveChanges();
        }
    }
}
