namespace HealMeAppBackend.API.Authentication.Infrastructure.Tokens.JWT.Configuration
{
    /// <summary>
    /// Configuration class for JWT token settings.
    /// </summary>
    public class TokenSettings
    {
        /// <summary>
        /// Secret key used to sign the JWT.
        /// </summary>
        public string Secret { get; set; }
    }
}
