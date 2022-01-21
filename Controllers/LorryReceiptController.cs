using Microsoft.AspNetCore.Mvc;
using gaadi_ghoda_server.Models;
using gaadi_ghoda_server.Service;

namespace gaadi_ghoda_server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LorryReceiptController : ControllerBase
    {
        [HttpGet("LorryReceipt")]
        public List<LorryReceipt> getLorryReceipt()
        {
            LorryReceiptService lorryReceiptService = new LorryReceiptService();
            return lorryReceiptService.getLorryReceiptList();
        }

        [HttpPost("LorryReceipt")]
        public void addLorryReceipt([FromBody] LorryReceipt lorryReceipt)
        {
            LorryReceiptService lorryReceiptService = new LorryReceiptService();
            lorryReceiptService.saveLorryReceipt(lorryReceipt);
        }
    }
}
