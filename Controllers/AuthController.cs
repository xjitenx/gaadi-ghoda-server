using Microsoft.AspNetCore.Mvc;
using gaadi_ghoda_server.Models;
using gaadi_ghoda_server.Services;

namespace gaadi_ghoda_server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("Login")]
        public bool loginUser([FromBody] LoginCredentials loginCredentials)
        {
            AuthService authService = new AuthService();
            var validLogin = authService.loginUser(loginCredentials);
            return validLogin;
        }
    }
}
