using HealMeAppBackend.API.Hospitals.Domain.Model.Aggregates;
using HealMeAppBackend.API.Hospitals.Domain.Model.Commands;

namespace HealMeAppBackend.API.Hospitals.Domain.Services
{
    /// <summary>
    ///     Interface for the HospitalCommandService
    /// </summary>
    /// <remarks>
    ///     This interface defines the basic operations for the HospitalCommandService.
    /// </remarks>
    public interface IHospitalCommandService
    {
        /// <summary>
        ///     Handle the CreateHospitalCommand.
        /// </summary>
        /// <remarks>
        ///     This method handles the CreateHospitalCommand. It checks if the hospital already exists, and if not, creates it.
        /// </remarks>
        /// <param name="command">CreateHospitalCommand</param>
        /// <returns>The Hospital object if created, or null otherwise</returns>
        /// <exception cref="Exception"></exception>
        Task<Hospital?> Handle(CreateHospitalCommand command);
    }
}
