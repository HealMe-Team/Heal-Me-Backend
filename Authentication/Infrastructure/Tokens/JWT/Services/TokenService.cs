using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HealMeAppBackend.API.Authentication.Application.OutboundServices;
using HealMeAppBackend.API.Authentication.Infrastructure.Tokens.JWT.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace HealMeAppBackend.API.Authentication.Infrastructure.Tokens.JWT.Services
{
    /// <summary>
    /// Service to manage JWT tokens.
    /// </summary>
    public class TokenService : ITokenService
    {
        private readonly TokenSettings _tokenSettings;

        public TokenService(IOptions<TokenSettings> tokenSettings)
        {
            _tokenSettings = tokenSettings.Value;

            if (string.IsNullOrWhiteSpace(_tokenSettings.Secret) || _tokenSettings.Secret.Length < 32)
            {
                throw new ArgumentException("The secret key must be at least 32 characters long.");
            }
        }



        /// <summary>
        /// Generates a JWT token for a user.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        /// <param name="username">The username.</param>
        /// <returns>A signed JWT token.</returns>
        public string GenerateToken(int userId, string username)
        {
            var key = Encoding.ASCII.GetBytes(_tokenSettings.Secret);

            var claims = new[]
            {
                new Claim(ClaimTypes.Sid, userId.ToString()),
                new Claim(ClaimTypes.Name, username)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7), // Token valid for 7 days
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        /// <summary>
        /// Validates a JWT token and retrieves the user ID if valid.
        /// </summary>
        /// <param name="token">The token to validate.</param>
        /// <returns>The user ID if the token is valid, or null if invalid.</returns>
        public int? ValidateToken(string token)
        {
            if (string.IsNullOrEmpty(token)) return null;

            var key = Encoding.ASCII.GetBytes(_tokenSettings.Secret);
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false, // Skip issuer validation
                    ValidateAudience = false, // Skip audience validation
                    ClockSkew = TimeSpan.Zero // No delay in expiration validation
                };

                tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userIdClaim = jwtToken.Claims.First(claim => claim.Type == ClaimTypes.Sid);
                return int.Parse(userIdClaim.Value);
            }
            catch
            {
                return null;
            }
        }
    }
}
