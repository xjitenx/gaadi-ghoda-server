using Microsoft.AspNetCore.Mvc;
using gaadi_ghoda_server.Models;
using System.Net;
using gaadi_ghoda_server.IService.ICommonService;

namespace gaadi_ghoda_server.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> loginUser([FromBody] AuthRequest authRequest)
        {
            User _user;
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _user = await _authService.validateUserCredentials(authRequest);
                if (_user == null || _user.OrgId == Guid.Empty || _user.Id == Guid.Empty)
                {
                    return Unauthorized();
                }
                return Ok(_user);
            }
            catch (Exception e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
