namespace HealMeAppBackend.API.Authentication.Interfaces.REST.Resources
{
    /// <summary>
    ///     Resource representing an authenticated user.
    /// </summary>
    /// <remarks>
    ///     This class encapsulates the details of an authenticated user, 
    ///     including their username and the authentication token.
    /// </remarks>
    public class AuthenticatedUserResource
    {
        public string Username { get; set; }
        public string Token { get; set; }
    }
}
