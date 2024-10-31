using HealMeAppBackend.API.Hospitals.Domain.Model.Commands;
using HealMeAppBackend.API.Hospitals.Interfaces.REST.Resources;

namespace HealMeAppBackend.API.Hospitals.Interfaces.REST.Transform
{
    public static class CreateHospitalCommandFromResourceAssembler
    {
        public static CreateHospitalCommand ToCommandFromResource(CreateHospitalResource resource) =>
            new CreateHospitalCommand(resource.Name, resource.Description, resource.Location, resource.Rating);
    }
}
