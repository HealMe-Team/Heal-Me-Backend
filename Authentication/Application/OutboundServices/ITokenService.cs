namespace HealMeAppBackend.API.Authentication.Application.OutboundServices
{
    /// <summary>
    ///     Token service interface.
    /// </summary>
    /// <remarks>
    ///     This interface defines the basic operations for managing tokens, 
    ///     including token generation and validation.
    /// </remarks>
    public interface ITokenService
    {
        string GenerateToken(int userId, string username);
        int? ValidateToken(string token);
    }
}
