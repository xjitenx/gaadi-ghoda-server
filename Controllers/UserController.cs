using gaadi_ghoda_server.IService.ICommonService;
using gaadi_ghoda_server.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace gaadi_ghoda_server.Controllers
{
    [Route("api/{orgId}/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("get/{userId}")]
        public async Task<IActionResult> getUser([FromRoute] Guid orgId, [FromRoute] Guid userId)
        {
            try
            {
                return Ok(await _userService.Get(orgId, userId));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet("gets")]
        public async Task<IActionResult> getUserList([FromRoute] Guid orgId)
        {
            try
            {
                return Ok(await _userService.Gets(orgId));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost("save")]
        public async Task<IActionResult> addUser([FromRoute] Guid orgId, [FromBody] User user)
        {
            try
            {
                return Ok(await _userService.Save(orgId, user));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost("update")]
        public async Task<IActionResult> updateUser([FromRoute] Guid orgId, [FromBody] User user)
        {
            try
            {
                return Ok(await _userService.Update(orgId, user));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpDelete("delete/{userId}")]
        public async Task<IActionResult> deleteUser([FromRoute] Guid orgId, [FromRoute] Guid userId)
        {
            try
            {
                int result = await _userService.Delete(orgId, userId);
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
