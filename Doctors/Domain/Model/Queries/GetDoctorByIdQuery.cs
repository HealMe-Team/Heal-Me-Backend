namespace HealMeAppBackend.API.Doctors.Domain.Model.Queries
{
    /// <summary>
    ///     Query to get a doctor by its ID.
    /// </summary>
    /// <param name="Id">The ID of the doctor.</param>
    public record GetDoctorByIdQuery(int Id);
}
