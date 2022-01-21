using Microsoft.AspNetCore.Mvc;
using gaadi_ghoda_server.Models;
using gaadi_ghoda_server.Service;

namespace gaadi_ghoda_server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BrokerController : ControllerBase
    {
        [HttpGet("Broker")]
        public List<Broker> getBroker()
        {
             BrokerService brokerService = new BrokerService();
            var brokerList = brokerService.getBrokerList();
            return brokerList;
        }

        [HttpPost("Broker")]
        public void addBroker([FromBody] Broker broker)
        {
            BrokerService brokerService = new BrokerService();
            brokerService.saveBroker(broker);
        }
    }
}
