namespace HealMeAppBackend.API.Hospitals.Interfaces.REST.Resources
{
    /// <summary>
    ///  Represents the data provided by the server about a hospital.
    /// </summary>
    /// <param name="Id">The hospital's ID</param>
    /// <param name="Name">The hospital's name</param>
    /// <param name="Description">The hospital's description</param>
    /// <param name="Location">The hospital's location</param>
    /// <param name="Rating">The hospital's rating (1 to 5 stars)</param>
    public record HospitalResource(int Id, string Name, string Description, string Location, int Rating);
}
