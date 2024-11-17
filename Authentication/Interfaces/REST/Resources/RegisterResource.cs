namespace HealMeAppBackend.API.Authentication.Interfaces.REST.Resources
{
    /// <summary>
    ///     Resource representing the registration details of a new user.
    /// </summary>
    /// <remarks>
    ///     This class is used to encapsulate the information required for user registration, 
    ///     including a username and a password.
    /// </remarks>
    public class RegisterResource
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
