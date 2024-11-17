namespace HealMeAppBackend.API.Authentication.Interfaces.REST.Resources
{
    /// <summary>
    ///     Resource representing the login credentials of a user.
    /// </summary>
    /// <remarks>
    ///     This class is used to encapsulate the username and password 
    ///     provided by the user during the authentication process.
    /// </remarks>
    public class LoginResource
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
