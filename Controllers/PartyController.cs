using Microsoft.AspNetCore.Mvc;
using gaadi_ghoda_server.Models;
using gaadi_ghoda_server.Service;
using gaadi_ghoda_server.IService.IBookieService;
using System.Net;

namespace gaadi_ghoda_server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PartyController : ControllerBase
    {
        private readonly IBookiePartyService _bookiePartyService;
        public PartyController(IBookiePartyService bookiePartyService)
        {
            _bookiePartyService = bookiePartyService;
        }

        [HttpPost("get")]
        public async Task<IActionResult> getParty([FromBody] Party party)
        {
            try
            {
                return Ok(await _bookiePartyService.Get(party.Id));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet("gets")]
        public async Task<IActionResult> getPartyList()
        {
            try
            {
                return Ok(await _bookiePartyService.Gets());
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost("save")]
        public async Task<IActionResult> addParty([FromBody] Party party)
        {
            try
            {
                return Ok(await _bookiePartyService.Save(party));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPatch("update")]
        public async Task<IActionResult> updateParty([FromBody] Party party)
        {
            try
            {
                return Ok(await _bookiePartyService.Save(party));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> deleteParty([FromBody] Party party)
        {
            try
            {
                int result = await _bookiePartyService.Delete(party.Id);
                if (result == 1)
                {
                    return Ok("Party Deleted Successfully");
                }
                return NotFound("Party Not Found");
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
