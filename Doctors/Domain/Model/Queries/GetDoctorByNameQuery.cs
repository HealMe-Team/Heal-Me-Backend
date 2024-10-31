namespace HealMeAppBackend.API.Doctors.Domain.Model.Queries
{
    /// <summary>
    ///     Query to get a doctor by name.
    /// </summary>
    /// <param name="Name">The name of the doctor.</param>
    public record GetDoctorByNameQuery(string Name);
}
