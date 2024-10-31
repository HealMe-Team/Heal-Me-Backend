using HealMeAppBackend.API.Doctors.Domain.Model.Aggregates;
using HealMeAppBackend.API.Doctors.Domain.Model.Commands;
using HealMeAppBackend.API.Doctors.Domain.Repositories;
using HealMeAppBackend.API.Doctors.Domain.Services;
using HealMeAppBackend.API.Shared.Domain.Repositories;
using System.Numerics;

namespace HealMeAppBackend.API.Doctors.Application.Internal
{
    /// <summary>
    ///     Doctor command service.
    /// </summary>
    /// <remarks>
    ///     This class implements the basic operations for a doctor command service.
    /// </remarks>
    public class DoctorCommandService(IDoctorRepository doctorRepository, IUnitOfWork unitOfWork) : IDoctorCommandService
    {

        /// <inheritdoc />
        public async Task<Doctor?> Handle(CreateProductCommand command)
        {
            var existingDoctor = await doctorRepository.FindByNameAsync(command.Name);

            if (existingDoctor != null) throw new Exception("Doctor already exists");

            var doctor = new Doctor(command);

            try
            {
                await doctorRepository.AddAsync(doctor);
                await unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                return null;
            }

            return doctor;
        }
    }
}

