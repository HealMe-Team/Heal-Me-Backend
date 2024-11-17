using HealMeAppBackend.API.Shared.Domain.Repositories;
using HealMeAppBackend.API.Shared.Infrastructure.Persistence.EFC.Configuration;

using Microsoft.EntityFrameworkCore;

namespace HealMeAppBackend.API.Shared.Infrastructure.Persistence.EFC.Repositories
{
     /// <summary>
    ///     Implements the Unit of Work pattern to manage transactions and ensure changes
    ///     are persisted to the database.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
