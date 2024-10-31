using HealMeAppBackend.API.Doctors.Domain.Model.Commands;
using HealMeAppBackend.API.Doctors.Interfaces.REST.Resources;

namespace HealMeAppBackend.API.Doctors.Interfaces.REST.Transform
{
    public static class CreateDoctorCommandFromResourceAssembler
    {
        public static CreateProductCommand ToCommandFromResource(CreateDoctorResource resource) =>
            new CreateProductCommand(resource.Name, resource.Description, resource.Rating);
    }
}
