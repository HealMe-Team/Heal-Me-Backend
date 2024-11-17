using HealMeAppBackend.API.Hospitals.Domain.Model.Aggregates;
using HealMeAppBackend.API.Hospitals.Domain.Model.Queries;
using HealMeAppBackend.API.Hospitals.Domain.Repositories;
using HealMeAppBackend.API.Hospitals.Domain.Services;
using HealMeAppBackend.API.Hospitals.Infrastructure.Repositories;
using HealMeAppBackend.API.Shared.Domain.Repositories;

namespace HealMeAppBackend.API.Hospitals.Application.Internal
{
    /// <summary>
    ///     Hospital query service.
    /// </summary>
    /// <remarks>
    ///     This class implements the basic operations for a hospital query service.
    /// </remarks>
    /// <param name="hospitalRepository">The HospitalRepository instance.</param>
    public class HospitalQueryService(IHospitalRepository hospitalRepository, IUnitOfWork unitOfWork) : IHospitalQueryService
    {
        /// <inheritdoc />
        public async Task<Hospital?> Handle(GetHospitalByIdQuery query)
        {
            return await hospitalRepository.FindByIdAsync(query.Id);
        }

        /// <inheritdoc />
        public async Task<Hospital?> Handle(GetHospitalByNameQuery query)
        {
            return await hospitalRepository.FindByNameAsync(query.Name);
        }

        public async Task<IEnumerable<Hospital>> Handle(GetHospitalByRatingQuery query)
        {
            return await hospitalRepository.FindByRatingAsync(query.Rating);
        }

    }
}
