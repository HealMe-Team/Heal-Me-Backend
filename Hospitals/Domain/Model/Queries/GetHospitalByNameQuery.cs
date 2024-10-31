namespace HealMeAppBackend.API.Hospitals.Domain.Model.Queries
{
    /// <summary>
    ///     Query to get a hospital by name.
    /// </summary>
    /// <param name="Name">The name of the hospital.</param>
    public record GetHospitalByNameQuery(string Name);
}
