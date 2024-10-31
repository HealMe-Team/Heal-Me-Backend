using HealMeAppBackend.API.Hospitals.Domain.Model.Aggregates;
using HealMeAppBackend.API.Hospitals.Interfaces.REST.Resources;

namespace HealMeAppBackend.API.Hospitals.Interfaces.REST.Transform
{
    public static class HospitalResourceFromEntityAssembler
    {
        public static HospitalResource ToResourceFromEntity(Hospital entity) =>
            new HospitalResource(entity.Id, entity.Name, entity.Description, entity.Location, entity.Rating);
    }
}
