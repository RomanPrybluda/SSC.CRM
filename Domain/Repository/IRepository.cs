using DAL.Entity;

namespace Domain.Repository
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetAllQueryable();

        Task<TEntity> GetByIdAsync(Guid id);

        Task<TEntity> CreateEntityAsync(TEntity entity);

        Task<TEntity> UpdateEntityAsync(TEntity entity);

        Task<TEntity> DeleteEntityAsync(TEntity entity);

        Task SaveChangesAsync();
    }
}