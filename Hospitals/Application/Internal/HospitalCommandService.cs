using HealMeAppBackend.API.Hospitals.Domain.Model.Aggregates;
using HealMeAppBackend.API.Hospitals.Domain.Model.Commands;
using HealMeAppBackend.API.Hospitals.Domain.Repositories;
using HealMeAppBackend.API.Hospitals.Domain.Services;
using HealMeAppBackend.API.Shared.Domain.Repositories;
using System;

namespace HealMeAppBackend.API.Hospitals.Application.Internal
{
    /// <summary>
    ///     Hospital command service.
    /// </summary>
    /// <remarks>
    ///     This class implements the basic operations for a hospital command service.
    /// </remarks>
    public class HospitalCommandService(IHospitalRepository hospitalRepository, IUnitOfWork unitOfWork) : IHospitalCommandService
    {
        /// <inheritdoc />
        public async Task<Hospital?> Handle(CreateHospitalCommand command)
        {
            var existingHospital = await hospitalRepository.FindByNameAsync(command.Name);

            if (existingHospital != null) throw new Exception("Hospital already exists");

            var hospital = new Hospital(command);

            try
            {
                await hospitalRepository.AddAsync(hospital);
                await unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                return null;
            }

            return hospital;
        }
    }
}


