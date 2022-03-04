using gaadi_ghoda_server.IService.ICommonService;
using gaadi_ghoda_server.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace gaadi_ghoda_server.Controllers
{
    [Route("api/{orgId}/role")]
    [ApiController]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("get/{roleId}")]
        public async Task<IActionResult> getRole([FromRoute] Guid orgId, [FromRoute] Guid roleId)
        {
            try
            {
                return Ok(await _roleService.Get(orgId, roleId));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet("gets")]
        public async Task<IActionResult> getRoleList([FromRoute] Guid orgId)
        {
            try
            {
                return Ok(await _roleService.Gets(orgId));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost("save")]
        public async Task<IActionResult> addRole([FromRoute] Guid orgId, [FromBody] Role role)
        {
            try
            {
                return Ok(await _roleService.Save(orgId, role));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost("update")]
        public async Task<IActionResult> updateRole([FromRoute] Guid orgId, [FromBody] Role role)
        {
            try
            {
                return Ok(await _roleService.Update(orgId, role));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpDelete("delete/{roleId}")]
        public async Task<IActionResult> deleteRole([FromRoute] Guid orgId, [FromRoute] Guid roleId)
        {
            try
            {
                int result = await _roleService.Delete(orgId, roleId);
                if (result == 1)
                {
                    return Ok("Role Deleted Successfully");
                }
                return NotFound("Role Not Found");
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
