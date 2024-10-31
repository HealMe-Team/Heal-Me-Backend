using HealMeAppBackend.API.Doctors.Domain.Model.Aggregates;
using HealMeAppBackend.API.Doctors.Domain.Model.Queries;
using HealMeAppBackend.API.Doctors.Domain.Repositories;
using HealMeAppBackend.API.Doctors.Domain.Services;
using HealMeAppBackend.API.Shared.Domain.Repositories;

namespace HealMeAppBackend.API.Doctors.Application.Internal
{
    /// <summary>
    ///     Doctor query service.
    /// </summary>
    /// <remarks>
    ///     This class implements the basic operations for a doctor query service.
    /// </remarks>
    /// <param name="doctorRepository">The DoctorRepository instance.</param>
    public class DoctorQueryService(IDoctorRepository doctorRepository, IUnitOfWork unitOfWork) : IDoctorQueryService
    {
        /// <inheritdoc />
        public async Task<Doctor?> Handle(GetDoctorByIdQuery query)
        {
            return await doctorRepository.FindByIdAsync(query.Id);
        }

        /// <inheritdoc />
        public async Task<Doctor?> Handle(GetDoctorByNameQuery query)
        {
            return await doctorRepository.FindByNameAsync(query.Name);
        }
    }
}
