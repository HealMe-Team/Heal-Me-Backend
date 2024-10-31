namespace HealMeAppBackend.API.Doctors.Domain.Model.Commands
{
    /// <summary>
    ///     Command to create a doctor.
    /// </summary>
    /// <param name="Name">The doctor's name.</param>
    /// <param name="Description">The doctor's description.</param>
    /// <param name="Rating">The doctor's rating, from 1 to 5 stars.</param>
    public record CreateProductCommand(string Name, string Description, int Rating);
}
