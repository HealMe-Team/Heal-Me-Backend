using HealMeAppBackend.API.Authentication.Application.OutboundServices;
using HealMeAppBackend.API.Authentication.Interfaces.REST.Resources;
using Microsoft.AspNetCore.Mvc;

namespace HealMeAppBackend.API.Authentication.Interfaces.REST
{
    [ApiController]
    [Route("api/auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IHashingService _hashingService;

        //Simulation of an in-memory database for example
        private static readonly Dictionary<string, string> Users = new();

        public AuthenticationController(ITokenService tokenService, IHashingService hashingService)
        {
            _tokenService = tokenService;
            _hashingService = hashingService;
        }

        /// <summary>
        /// Endpoint to register a new user.
        /// </summary>
        /// <param name="resource">User data for registration.</param>
        /// <returns>Response indicating success or error.</returns>
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterResource resource)
        {
            if (Users.ContainsKey(resource.Username))
                return BadRequest(new { message = "Username already exists" });

            var hashedPassword = _hashingService.HashPassword(resource.Password);
            Users[resource.Username] = hashedPassword;

            return Ok(new { message = "User registered successfully" });
        }

        /// <summary>
        ///  Endpoint to log in.
        /// </summary>
        /// <param name="resource">User credentials.</param>
        /// <returns>JWT token if the credentials are correct.</returns>
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginResource resource)
        {
            if (!Users.ContainsKey(resource.Username))
                return Unauthorized(new { message = "Invalid username or password" });

            var hashedPassword = Users[resource.Username];
            var isValidPassword = _hashingService.VerifyPassword(resource.Password, hashedPassword);

            if (!isValidPassword)
                return Unauthorized(new { message = "Invalid username or password" });

            var token = _tokenService.GenerateToken(1, resource.Username); // ID ficticio
            return Ok(new AuthenticatedUserResource
            {
                Username = resource.Username,
                Token = token
            });
        }
    }
}
