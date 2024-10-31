using HealMeAppBackend.API.Doctors.Domain.Model.Aggregates;
using HealMeAppBackend.API.Shared.Domain.Repositories;

namespace HealMeAppBackend.API.Doctors.Domain.Repositories
{
    /// <summary>
    ///     The Doctor repository contract.
    /// </summary>
    public interface IDoctorRepository : IBaseRepository<Doctor>
    {
        /// <summary>
        ///     Find a doctor by its name.
        /// </summary>
        /// <param name="name">The doctor's name.</param>
        /// <returns>
        ///     An Enumerable of doctors.
        /// </returns>
        Task<Doctor?> FindByIdAsync(int id);

        /// <summary>
        ///     Find a doctor by name and ID.
        /// </summary>
        /// <param name="name">The doctor's name.</param>
        /// <param name="id">The doctor's ID.</param>
        /// <returns>
        ///     The doctor object if found, null otherwise.
        /// </returns>
        Task<Doctor?> FindByNameAsync(string name);

    }
}
