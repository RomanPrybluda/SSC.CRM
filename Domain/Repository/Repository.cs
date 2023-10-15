using DAL.DBContext;
using DAL.Entity;
using Domain.Repository;

namespace Example.Domain.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly AppDBContext _context;

        public Repository(AppDBContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> GetAllQueryable()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> CreateEntityAsync(TEntity entity)
        {
            var result = await _context.AddAsync(entity);
            return result.Entity;
        }

        public async Task<TEntity> UpdateEntityAsync(TEntity entity)
        {
            var result = _context.Update(entity);
            return await Task.FromResult(result.Entity);
        }

        public async Task<TEntity> DeleteEntityAsync(TEntity entity)
        {
            var result = _context.Remove(entity);
            return await Task.FromResult(result.Entity);
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}