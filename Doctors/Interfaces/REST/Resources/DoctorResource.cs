namespace HealMeAppBackend.API.Doctors.Interfaces.REST.Resources
{
    /// <summary>
    ///  Represents the data provided by the server about a doctor.
    /// </summary>
    /// <param name="Id">The doctor's ID</param>
    /// <param name="Name">The doctor's name</param>
    /// <param name="Description">The doctor's description</param>
    /// <param name="Rating">The doctor's rating (1 to 5 stars)</param>
    public record DoctorResource(int Id, string Name, string Description, int Rating);
}
