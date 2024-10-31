using HealMeAppBackend.API.Doctors.Domain.Model.Aggregates;
using HealMeAppBackend.API.Doctors.Domain.Model.Commands;

namespace HealMeAppBackend.API.Doctors.Domain.Services
{
    /// <summary>
    ///     Interface for the DoctorCommandService
    /// </summary>
    /// <remarks>
    ///     This interface defines the basic operations for the DoctorCommandService
    /// </remarks>
    public interface IDoctorCommandService
    {
        /// <summary>
        ///     Handle the CreateDoctorCommand
        /// </summary>
        /// <remarks>
        ///     This method handles the CreateDoctorCommand. It checks if the doctor already exists, and if not, creates it.
        /// </remarks>
        /// <param name="command">CreateDoctorCommand</param>
        /// <returns>The Doctor object if created, or null otherwise</returns>
        /// <exception cref="Exception"></exception>
        Task<Doctor?> Handle(CreateProductCommand command);
    }
}
