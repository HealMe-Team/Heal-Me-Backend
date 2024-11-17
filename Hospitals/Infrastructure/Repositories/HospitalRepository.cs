using HealMeAppBackend.API.Hospitals.Domain.Model.Aggregates;
using HealMeAppBackend.API.Hospitals.Domain.Repositories;
using HealMeAppBackend.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using HealMeAppBackend.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HealMeAppBackend.API.Hospitals.Infrastructure.Repositories
{
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
