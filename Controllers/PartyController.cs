using Microsoft.AspNetCore.Mvc;
using gaadi_ghoda_server.Models;
using gaadi_ghoda_server.Service;
using gaadi_ghoda_server.IService.IBookieService;
using System.Net;
using Microsoft.AspNetCore.Http;
using gaadi_ghoda_server.IService.IBrokerService;

namespace gaadi_ghoda_server.Controllers
{
    [Route("api/{accountType}/{accountId}/party")]
    [ApiController]
    public class PartyController : ControllerBase
    {
        private readonly IBookiePartyService _bookiePartyService;
        private readonly IBrokerPartyService _brokerPartyService;
        public PartyController(IBookiePartyService bookiePartyService, IBrokerPartyService brokerPartyService)
        {
            _bookiePartyService = bookiePartyService;
            _brokerPartyService = brokerPartyService;
        }

        [HttpPost("get")]
        public async Task<IActionResult> getParty([FromBody] Party party, string accountType, string accountId)
        {
            try
            {
                if (accountType.ToLower() == "bookie")
                {
                    return Ok(await _bookiePartyService.Get(party.Id, accountId));
                }
                else
                {
                    return Ok(await _brokerPartyService.Get(party.Id, accountId));
                }

            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet("gets")]
        public async Task<IActionResult> getPartyList(string accountType, string accountId)
        {
            try
            {
                if (accountType.ToLower() == "bookie")
                {
                    return Ok(await _bookiePartyService.Gets(accountId));
                }
                else
                {
                    return Ok(await _brokerPartyService.Gets(accountId));
                }
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost("save")]
        public async Task<IActionResult> addParty([FromBody] Party party, string accountType, string accountId)
        {
            try
            {
                if (accountType.ToLower() == "bookie")
                {
                    return Ok(await _bookiePartyService.Save(party, accountId));
                }
                else
                {
                    return Ok(await _brokerPartyService.Save(party, accountId));
                }
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPatch("update")]
        public async Task<IActionResult> updateParty([FromBody] Party party, string accountType, string accountId)
        {
            try
            {
                if (accountType.ToLower() == "bookie")
                {
                    return Ok(await _bookiePartyService.Save(party, accountId));
                }
                else
                {
                    return Ok(await _brokerPartyService.Save(party, accountId));
                }
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> deleteParty([FromBody] Party party, string accountType, string accountId)
        {
            try
            {
                int result = 0;
                if (accountType.ToLower() == "bookie")
                {
                    result = await _bookiePartyService.Delete(party.Id, accountId);
                }
                else
                {
                    result = await _brokerPartyService.Delete(party.Id, accountId);
                }
                
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
