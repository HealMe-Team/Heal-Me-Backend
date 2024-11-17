namespace HealMeAppBackend.API.Shared.Domain.Repositories
{
    /// <summary>
    ///     Defines the contract for a unit of work pattern.
    /// </summary>
    /// <remarks>
    ///     The unit of work pattern is used to group multiple operations 
    ///     into a single transaction, ensuring consistency and reducing overhead.
    /// </remarks>
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
