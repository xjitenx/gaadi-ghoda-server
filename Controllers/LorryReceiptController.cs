using Microsoft.AspNetCore.Mvc;
using gaadi_ghoda_server.Models;
using gaadi_ghoda_server.Services;

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
            var lorryReceiptList = lorryReceiptService.getLorryReceiptList();
            return lorryReceiptList;
        }

        [HttpPost("LorryReceipt")]
        public int addLorryReceipt([FromBody] List<LorryReceipt> lorryReceiptList)
        {
            LorryReceiptService lorryReceiptService = new LorryReceiptService();
            if (lorryReceiptList.Count > 0)
            {
                return lorryReceiptService.saveLorryReceipt(lorryReceiptList);
            }
            return 0;
        }
    }
}
