namespace HealMeAppBackend.API.Doctors.Domain.Model.Queries
{
    /// <summary>
    /// Query to get doctors by their rating.
    /// </summary>
    /// <param name="Rating">The rating of the doctors.</param>
    public record GetDoctorByRatingQuery(int Rating);
}
