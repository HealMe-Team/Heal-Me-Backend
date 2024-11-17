namespace HealMeAppBackend.API.Authentication.Application.OutboundServices
{
    /// <summary>
    ///     Service interface for hashing and verifying passwords.
    /// </summary>
    public interface IHashingService
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string hashedPassword);
    }
}
