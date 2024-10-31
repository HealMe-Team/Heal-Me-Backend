namespace HealMeAppBackend.API.Hospitals.Domain.Model.Commands
{
    /// <summary>
    ///     Command to create a hospital.
    /// </summary>
    /// <param name="Name">The hospital's name.</param>
    /// <param name="Description">The hospital's description.</param>
    /// <param name="Location">The hospital's location.</param>
    /// <param name="Rating">The hospital's rating, from 1 to 5 stars.</param>
    public record CreateHospitalCommand(string Name, string Description, string Location, int Rating);
}
