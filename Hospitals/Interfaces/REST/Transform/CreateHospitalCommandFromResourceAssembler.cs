using HealMeAppBackend.API.Hospitals.Domain.Model.Commands;
using HealMeAppBackend.API.Hospitals.Interfaces.REST.Resources;

namespace HealMeAppBackend.API.Hospitals.Interfaces.REST.Transform
{
    /// <summary>
    ///     Assembler to transform a resource into a hospital creation command.
    /// </summary>
    /// <remarks>
    ///     This static class provides a method to convert a `CreateHospitalResource` 
    ///     into a `CreateHospitalCommand` used by the domain layer.
    /// </remarks>
    public static class CreateHospitalCommandFromResourceAssembler
    {
        public static CreateHospitalCommand ToCommandFromResource(CreateHospitalResource resource) =>
            new CreateHospitalCommand(resource.Name, resource.Description, resource.Location, resource.Rating);
    }
}
