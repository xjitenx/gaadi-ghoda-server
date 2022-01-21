using Microsoft.AspNetCore.Mvc;
using gaadi_ghoda_server.Models;
using gaadi_ghoda_server.Service;

namespace gaadi_ghoda_server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PartyController : ControllerBase
    {
        [HttpGet("Party")]
        public List<Party> getParty()
        {
            PartyService partyService = new PartyService();
            var partyList = partyService.getPartyList();
            return partyList;
        }

        [HttpPost("Party")]
        public void addParty([FromBody] Party party)
        {
            PartyService partyService = new PartyService();
            partyService.saveParty(party);
        }
    }
}
