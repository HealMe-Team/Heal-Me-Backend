using HealMeAppBackend.API.Hospitals.Domain.Model.Aggregates;
using HealMeAppBackend.API.Hospitals.Domain.Repositories;
using HealMeAppBackend.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using HealMeAppBackend.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HealMeAppBackend.API.Hospitals.Infrastructure.Repositories
{
    /// <summary>
    ///     Repository for managing hospital data in the database.
    /// </summary>
    /// <remarks>
    ///     This class implements methods to interact with the hospital data source, 
    ///     including retrieving hospitals by name, ID, and rating.
    /// </remarks>
    public class HospitalRepository(AppDbContext context) : BaseRepository<Hospital>(context), IHospitalRepository
    {
        /// <inheritdoc />
        public async Task<Hospital?> FindByNameAsync(string name)
        {
            return await context.Set<Hospital>().FirstOrDefaultAsync(h => h.Name == name);
        }

        /// <inheritdoc />
        public async Task<Hospital?> FindByIdAsync(int id)
        {
            return await context.Set<Hospital>().FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<IEnumerable<Hospital>> FindByRatingAsync(int rating)
        {
            return await context.Set<Hospital>()
                .Where(d => d.Rating == rating)
                .ToListAsync();
        }

    }
}
