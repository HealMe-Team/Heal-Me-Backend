using HealMeAppBackend.API.Doctors.Domain.Model.Aggregates;
using HealMeAppBackend.API.Doctors.Domain.Model.Queries;

namespace HealMeAppBackend.API.Doctors.Domain.Services
{
    /// <summary>
    ///     Interface for the DoctorQueryService
    /// </summary>
    /// <remarks>
    ///     This interface defines the basic operations for the DoctorQueryService
    /// </remarks>
    public interface IDoctorQueryService
    {
        /// <summary>
        ///     Handle the GetDoctorByIdQuery
        /// </summary>
        /// <remarks>
        ///     This method handles the GetDoctorByIdQuery. It returns the doctor with the given id.
        /// </remarks>
        /// <param name="query">The GetDoctorByIdQuery</param>
        /// <returns>The Doctor object if found, or null otherwise</returns>
        Task<Doctor?> Handle(GetDoctorByIdQuery query);

        /// <summary>
        ///     Handle the GetDoctorByNameQuery
        /// </summary>
        /// <remarks>
        ///     This method handles the GetDoctorByNameQuery. It returns the doctor with the given name.
        /// </remarks>
        /// <param name="query">The GetDoctorByNameQuery</param>
        /// <returns>The Doctor object if found, or null otherwise</returns>
        Task<Doctor?> Handle(GetDoctorByNameQuery query);
    }
}
