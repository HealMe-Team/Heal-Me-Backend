using HealMeAppBackend.API.Hospitals.Domain.Model.Aggregates;
using HealMeAppBackend.API.Shared.Domain.Repositories;

namespace HealMeAppBackend.API.Hospitals.Domain.Repositories
{
    /// <summary>
    ///     The Hospital repository contract.
    /// </summary>
    public interface IHospitalRepository : IBaseRepository<Hospital>
    {
        /// <summary>
        ///     Find a hospital by its ID.
        /// </summary>
        /// <param name="id">The hospital's ID.</param>
        /// <returns>
        ///     The hospital object if found, null otherwise.
        /// </returns>
        Task<Hospital?> FindByIdAsync(int id);

        /// <summary>
        ///     Find a hospital by its name.
        /// </summary>
        /// <param name="name">The hospital's name.</param>
        /// <returns>
        ///     The hospital object if found, null otherwise.
        /// </returns>
        Task<Hospital?> FindByNameAsync(string name);

        Task<IEnumerable<Hospital>> FindByRatingAsync(int rating);

    }
}
