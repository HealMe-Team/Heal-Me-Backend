using HealMeAppBackend.API.Shared.Domain.Repositories;
using HealMeAppBackend.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace HealMeAppBackend.API.Shared.Infrastructure.Persistence.EFC.Repositories
{
    /// <summary>
    ///     Provides a generic base implementation for repository operations.
    /// </summary>
    /// <typeparam name="TEntity">
    ///     The type of entity the repository will handle.
    /// </typeparam>
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {

        protected readonly AppDbContext _context;

        protected BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        async Task IBaseRepository<TEntity>.AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        void IBaseRepository<TEntity>.Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        void IBaseRepository<TEntity>.Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        async Task<TEntity?> IBaseRepository<TEntity>.FindByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        async Task<IEnumerable<TEntity>> IBaseRepository<TEntity>.ListAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

    }
}
