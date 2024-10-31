namespace HealMeAppBackend.API.Hospitals.Domain.Model.Queries
{
    /// <summary>
    ///     Query to get a hospital by its ID.
    /// </summary>
    /// <param name="Id">The ID of the hospital.</param>
    public record GetHospitalByIdQuery(int Id);
}
