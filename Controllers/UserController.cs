using gaadi_ghoda_server.IService.ICommonService;
using gaadi_ghoda_server.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace gaadi_ghoda_server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("get")]
        public async Task<IActionResult> getUser([FromBody] User user)
        {
            try
            {
                return Ok(await _userService.Get(user.Id));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet("gets")]
        public async Task<IActionResult> getUserList()
        {
            try
            {
                return Ok(await _userService.Gets());
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost("save")]
        public async Task<IActionResult> addUser([FromBody] User user)
        {
            try
            {
                return Ok(await _userService.Save(user));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPatch("update")]
        public async Task<IActionResult> updateUser([FromBody] User user)
        {
            try
            {
                return Ok(await _userService.Save(user));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> deleteUser([FromBody] User user)
        {
            try
            {
                int result = await _userService.Delete(user.Id);
                if (result == 1)
                {
                    return Ok("User Deleted Successfully");
                }
                return NotFound("User Not Found");
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
