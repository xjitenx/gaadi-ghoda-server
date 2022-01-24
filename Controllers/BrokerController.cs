using Microsoft.AspNetCore.Mvc;
using gaadi_ghoda_server.Models;
using gaadi_ghoda_server.Service;
using gaadi_ghoda_server.IService.IBookieService;
using System.Net;

namespace gaadi_ghoda_server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BrokerController : ControllerBase
    {
        private readonly IBookieBrokerService _bookieBrokerService;
        public BrokerController(IBookieBrokerService bookieBrokerService)
        {
            _bookieBrokerService = bookieBrokerService;
        }

        [HttpGet("get")]
        public async Task<IActionResult> getBroker([FromBody] Broker broker)
        {
            try
            {
                return Ok(await _bookieBrokerService.Gets());
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet("gets")]
        public async Task<IActionResult> getBrokerList()
        {
            try
            {
                return Ok(await _bookieBrokerService.Gets());
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost("save")]
        public async Task<IActionResult> addBroker([FromBody] Broker broker)
        {
            try
            {
                return Ok(await _bookieBrokerService.Save(broker));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost("update")]
        public async Task<IActionResult> updateBroker([FromBody] Broker broker)
        {
            try
            {
                return Ok(await _bookieBrokerService.Update(broker));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost("delete")]
        public async Task<IActionResult> deleteBroker([FromBody] Broker broker)
        {
            try
            {
                int result = await _bookieBrokerService.Delete(broker.Id);
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
