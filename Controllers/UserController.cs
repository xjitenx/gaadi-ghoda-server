using gaadi_ghoda_server.Models;
using gaadi_ghoda_server.Service;
using Microsoft.AspNetCore.Mvc;

namespace gaadi_ghoda_server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost("Profile")]
        public User getUserProfile([FromBody] User user)
        {
            UserService authService = new UserService();
            var userProfile = authService.getUserProfile(user.Id);
            return userProfile;
        }
    }
}
