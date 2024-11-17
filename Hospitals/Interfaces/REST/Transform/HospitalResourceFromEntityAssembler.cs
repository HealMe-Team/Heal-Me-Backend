using HealMeAppBackend.API.Hospitals.Domain.Model.Aggregates;
using HealMeAppBackend.API.Hospitals.Interfaces.REST.Resources;

namespace HealMeAppBackend.API.Hospitals.Interfaces.REST.Transform
{
     /// <summary>
    ///     Assembler to transform a hospital entity into a resource.
    /// </summary>
    /// <remarks>
    ///     This static class provides a method to convert a <see cref="Hospital"/> entity 
    ///     into a <see cref="HospitalResource"/> used by the REST interface.
    /// </remarks>
    public static class HospitalResourceFromEntityAssembler
    {
        public static HospitalResource ToResourceFromEntity(Hospital entity) =>
            new HospitalResource(entity.Id, entity.Name, entity.Description, entity.Location, entity.Rating);
    }
}
