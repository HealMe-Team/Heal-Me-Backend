using BCrypt.Net;

using HealMeAppBackend.API.Authentication.Application.OutboundServices;

using Org.BouncyCastle.Crypto.Generators;

namespace HealMeAppBackend.API.Authentication.Infrastructure.Hashing.BCrypt.Services
{
    /// <summary>
    /// Service to handle password hashing and validation.
    /// </summary>
    public class HashingService : IHashingService
    {
        /// <summary>
        /// Hashes a plaintext password.
        /// </summary>
        /// <param name="password">The plaintext password to hash.</param>
        /// <returns>The hashed password.</returns>
        public string HashPassword(string password)
        {
            return global::BCrypt.Net.BCrypt.HashPassword(password);
        }

        /// <summary>
        /// Validates a plaintext password against a hashed password.
        /// </summary>
        /// <param name="password">The plaintext password to validate.</param>
        /// <param name="hashedPassword">The hashed password to compare against.</param>
        /// <returns>True if the password matches the hash, false otherwise.</returns>
        public bool VerifyPassword(string password, string hashedPassword)
        {
            return global::BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
