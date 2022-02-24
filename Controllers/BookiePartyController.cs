using Microsoft.AspNetCore.Mvc;
using gaadi_ghoda_server.Models;
using gaadi_ghoda_server.Service;
using gaadi_ghoda_server.IService.IBookieService;
using System.Net;
using Microsoft.AspNetCore.Http;
using gaadi_ghoda_server.IService.IBrokerService;

namespace gaadi_ghoda_server.Controllers
{
    [Route("api/{orgId}/bookie/{bookieId}/party")]
    [ApiController]
    public class BookiePartyController : ControllerBase
    {
        private readonly IBookiePartyService _bookiePartyService;
        public BookiePartyController(IBookiePartyService bookiePartyService)
        {
            _bookiePartyService = bookiePartyService;
        }

        [HttpGet("get/{partyId}")]
        public async Task<IActionResult> getParty([FromRoute] Guid orgId, [FromRoute] Guid bookieId, [FromRoute] Guid partyId)
        {
            try
            {
                return Ok(await _bookiePartyService.Get(orgId, bookieId, partyId));

            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet("gets")]
        public async Task<IActionResult> getPartyList([FromRoute] Guid orgId, [FromRoute] Guid bookieId)
        {
            try
            {
                return Ok(await _bookiePartyService.Gets(orgId, bookieId));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost("save")]
        public async Task<IActionResult> addParty([FromRoute] Guid orgId, [FromRoute] Guid bookieId, [FromBody] Party party)
        {
            try
            {
                return Ok(await _bookiePartyService.Save(orgId, bookieId, party));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost("update")]
        public async Task<IActionResult> updateParty([FromRoute] Guid orgId, [FromRoute] Guid bookieId, [FromBody] Party party)
        {
            try
            {
                return Ok(await _bookiePartyService.Update(orgId, bookieId, party));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpDelete("delete/{partyId}")]
        public async Task<IActionResult> deleteParty([FromRoute] Guid orgId, [FromRoute] Guid bookieId, Guid partyId)
        {
            try
            {
                int result = 0;
                result = await _bookiePartyService.Delete(orgId, bookieId, partyId);
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
