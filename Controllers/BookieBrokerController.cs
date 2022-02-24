using Microsoft.AspNetCore.Mvc;
using gaadi_ghoda_server.Models;
using gaadi_ghoda_server.Service;
using gaadi_ghoda_server.IService.IBookieService;
using System.Net;

namespace gaadi_ghoda_server.Controllers
{
    [Route("api/{orgId}/bookie/{bookieId}/broker")]
    [ApiController]
    public class BookieBrokerController : ControllerBase
    {
        private readonly IBookieBrokerService _bookieBrokerService;
        public BookieBrokerController(IBookieBrokerService bookieBrokerService)
        {
            _bookieBrokerService = bookieBrokerService;
        }

        [HttpGet("get/{brokerId}")]
        public async Task<IActionResult> getBroker([FromRoute] Guid orgId, [FromRoute] Guid bookieId, [FromRoute] Guid brokerId)
        {
            try
            {
                return Ok(await _bookieBrokerService.Get(orgId, bookieId, brokerId));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet("gets")]
        public async Task<IActionResult> getBrokerList([FromRoute] Guid orgId, [FromRoute] Guid bookieId)
        {
            try
            {
                return Ok(await _bookieBrokerService.Gets(orgId, bookieId));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost("save")]
        public async Task<IActionResult> addBroker([FromRoute] Guid orgId, [FromRoute] Guid bookieId, [FromBody] Broker broker)
        {
            try
            {
                return Ok(await _bookieBrokerService.Save(orgId, bookieId, broker));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost("update")]
        public async Task<IActionResult> updateBroker([FromRoute] Guid orgId, [FromRoute] Guid bookieId, [FromBody] Broker broker)
        {
            try
            {
                return Ok(await _bookieBrokerService.Update(orgId, bookieId, broker));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpDelete("delete/{brokerId}")]
        public async Task<IActionResult> deleteBroker([FromRoute] Guid orgId, [FromRoute] Guid bookieId, [FromRoute] Guid brokerId)
        {
            try
            {
                int result = await _bookieBrokerService.Delete(orgId, bookieId, brokerId);
                if (result == 1)
                {
                    return Ok("Broker Deleted Successfully");
                }
                return NotFound("Broker Not Found");
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
