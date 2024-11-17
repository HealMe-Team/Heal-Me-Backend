namespace HealMeAppBackend.API.Hospitals.Domain.Model.Queries
{
    /// <summary>
    /// Query to get doctors by their rating.
    /// </summary>
    /// <param name="Rating">The rating of the doctors.</param>
    public record GetHospitalByRatingQuery(int Rating);
}
