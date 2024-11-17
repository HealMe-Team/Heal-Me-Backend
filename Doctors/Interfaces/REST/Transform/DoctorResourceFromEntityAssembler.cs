using HealMeAppBackend.API.Doctors.Domain.Model.Aggregates;
using HealMeAppBackend.API.Doctors.Interfaces.REST.Resources;

namespace HealMeAppBackend.API.Doctors.Interfaces.REST.Transform
{
     /// <summary>
    ///     Assembler to transform a <see cref="Doctor"/> entity into a <see cref="DoctorResource"/>.
    /// </summary>
    public static class DoctorResourceFromEntityAssembler
    {
        public static DoctorResource ToResourceFromEntity(Doctor entity) =>
            new DoctorResource(entity.Id, entity.Name, entity.Description, entity.Rating);
    }
}

