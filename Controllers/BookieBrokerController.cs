using Microsoft.AspNetCore.Mvc;
using gaadi_ghoda_server.Models;
using gaadi_ghoda_server.Service;
using gaadi_ghoda_server.IService.IBookieService;
using System.Net;

namespace gaadi_ghoda_server.Controllers
{
    [Route("api/bookie/{bookieId}/broker")]
    [ApiController]
    public class BookieBrokerController : ControllerBase
    {
        private readonly IBookieBrokerService _bookieBrokerService;
        public BookieBrokerController(IBookieBrokerService bookieBrokerService)
        {
            _bookieBrokerService = bookieBrokerService;
        }

        [HttpGet("{brokerId}")]
        public async Task<IActionResult> getBroker(string bookieId, string brokerId)
        {
            try
            {
                return Ok(await _bookieBrokerService.Get(brokerId, bookieId));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet("gets")]
        public async Task<IActionResult> getBrokerList(string bookieId)
        {
            try
            {
                return Ok(await _bookieBrokerService.Gets(bookieId));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost("save")]
        public async Task<IActionResult> addBroker([FromBody] Broker broker, string bookieId)
        {
            try
            {
                return Ok(await _bookieBrokerService.Save(broker, bookieId));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost("update")]
        public async Task<IActionResult> updateBroker([FromBody] Broker broker, string bookieId)
        {
            try
            {
                return Ok(await _bookieBrokerService.Update(broker, bookieId));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost("delete")]
        public async Task<IActionResult> deleteBroker([FromBody] Broker broker, string bookieId)
        {
            try
            {
                int result = await _bookieBrokerService.Delete(broker.Id, bookieId);
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
