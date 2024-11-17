using HealMeAppBackend.API.Doctors.Domain.Model.Aggregates;
using HealMeAppBackend.API.Doctors.Domain.Repositories;
using HealMeAppBackend.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using HealMeAppBackend.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HealMeAppBackend.API.Doctors.Infrastructure.Repositories
{
    public class DoctorRepository(AppDbContext context) : BaseRepository<Doctor>(context), IDoctorRepository
    {
        /// <inheritdoc />
        public async Task<Doctor?> FindByNameAsync(string name)
        {
            return await context.Set<Doctor>().FirstOrDefaultAsync(d => d.Name == name);
        }


        /// <inheritdoc />
        public async Task<Doctor?> FindByIdAsync(int id)
        {
            return await context.Set<Doctor>().FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<Doctor>> FindByRatingAsync(int rating)
        {
            return await context.Set<Doctor>()
                .Where(d => d.Rating == rating)
                .ToListAsync();
        }

    }
}