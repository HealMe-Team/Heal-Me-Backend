using HealMeAppBackend.API.Hospitals.Domain.Model.Aggregates;
using HealMeAppBackend.API.Hospitals.Domain.Model.Queries;

namespace HealMeAppBackend.API.Hospitals.Domain.Services
{
    /// <summary>
    ///     Interface for the HospitalQueryService
    /// </summary>
    /// <remarks>
    ///     This interface defines the basic operations for the HospitalQueryService.
    /// </remarks>
    public interface IHospitalQueryService
    {
        /// <summary>
        ///     Handle the GetHospitalByIdQuery
        /// </summary>
        /// <remarks>
        ///     This method handles the GetHospitalByIdQuery. It returns the hospital with the given id.
        /// </remarks>
        /// <param name="query">The GetHospitalByIdQuery</param>
        /// <returns>The Hospital object if found, or null otherwise</returns>
        Task<Hospital?> Handle(GetHospitalByIdQuery query);

        /// <summary>
        ///     Handle the GetHospitalByNameQuery
        /// </summary>
        /// <remarks>
        ///     This method handles the GetHospitalByNameQuery. It returns the hospital with the given name.
        /// </remarks>
        /// <param name="query">The GetHospitalByNameQuery</param>
        /// <returns>The Hospital object if found, or null otherwise</returns>
        Task<Hospital?> Handle(GetHospitalByNameQuery query);

        Task<IEnumerable<Hospital>> Handle(GetHospitalByRatingQuery query);

    }
}

