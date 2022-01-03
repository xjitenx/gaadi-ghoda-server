using gaadi_ghoda_server.Models;
using gaadi_ghoda_server.Services;
using Microsoft.AspNetCore.Mvc;

namespace gaadi_ghoda_server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("Profile")]
        public User getUserProfile([FromBody] string userId)
        {
            UserService authService = new UserService();
            var userProfile = authService.getUserProfile(userId);
            return userProfile;
        }
    }
}
