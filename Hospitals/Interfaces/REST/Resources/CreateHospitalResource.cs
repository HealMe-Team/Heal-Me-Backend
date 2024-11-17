using System.ComponentModel.DataAnnotations;

namespace HealMeAppBackend.API.Hospitals.Interfaces.REST.Resources
{
    /// <summary>
    ///    Represents the data provided by the client to create a hospital.
    /// </summary>
    /// <param name="Name">The hospital's name</param>
    /// <param name="Description">The hospital's description</param>
    /// <param name="Location">The hospital's location</param>
    /// <param name="Rating">The hospital's rating (1 to 5 stars)</param>
    public record CreateHospitalResource(
        [Required] string Name,
        [Required] string Description,
        [Required] string Location,
        [Required, Range(0, 5)] int Rating
    );
}
