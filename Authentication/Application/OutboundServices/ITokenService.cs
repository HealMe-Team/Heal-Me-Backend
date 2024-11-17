namespace HealMeAppBackend.API.Authentication.Application.OutboundServices
{
    public interface ITokenService
    {
        string GenerateToken(int userId, string username);
        int? ValidateToken(string token);
    }
}
