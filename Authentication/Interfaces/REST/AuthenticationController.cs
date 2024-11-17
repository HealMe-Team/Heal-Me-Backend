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

        // Simulación de una base de datos en memoria para el ejemplo
        private static readonly Dictionary<string, string> Users = new();

        public AuthenticationController(ITokenService tokenService, IHashingService hashingService)
        {
            _tokenService = tokenService;
            _hashingService = hashingService;
        }

        /// <summary>
        /// Endpoint para registrar un nuevo usuario.
        /// </summary>
        /// <param name="resource">Datos del usuario para el registro.</param>
        /// <returns>Respuesta indicando éxito o error.</returns>
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
        /// Endpoint para iniciar sesión.
        /// </summary>
        /// <param name="resource">Credenciales del usuario.</param>
        /// <returns>Token JWT si las credenciales son correctas.</returns>
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
