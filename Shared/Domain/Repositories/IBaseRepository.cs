namespace HealMeAppBackend.API.Shared.Domain.Repositories
{
    /// <summary>
    ///     Defines the base operations for a repository.
    /// </summary>
    /// <typeparam name="TEntity">
    ///     The type of entity that the repository manages.
    /// </typeparam>
    public interface IBaseRepository<TEntity>
    {
        Task AddAsync(TEntity entity);
        Task<TEntity?> FindByIdAsync(int id);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        Task<IEnumerable<TEntity>> ListAsync();
    }
}
