using Microsoft.AspNetCore.Mvc;
using gaadi_ghoda_server.Models;
using gaadi_ghoda_server.Service;
using gaadi_ghoda_server.IService.IBookieService;
using System.Net;

namespace gaadi_ghoda_server.Controllers
{
    [Route("api/{orgId}/bookie/{bookieId}/lorryreceipt")]
    [ApiController]
    public class BookieLorryReceiptController : ControllerBase
    {
        private readonly IBookieLorryReceiptService _lorryReceiptService;
        public BookieLorryReceiptController(IBookieLorryReceiptService lorryReceiptService)
        {
            _lorryReceiptService = lorryReceiptService;
        }

        [HttpGet("get/{lorryReceiptId}")]
        public async Task<IActionResult> getLorryReceipt([FromRoute] Guid orgId, [FromRoute] Guid bookieId, [FromRoute] Guid lorryReceiptId)
        {
            try
            {
                return Ok(await _lorryReceiptService.Get(orgId, bookieId, lorryReceiptId));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet("gets")]
        public async Task<IActionResult> getLorryReceiptList([FromRoute] Guid orgId, [FromRoute] Guid bookieId)
        {
            try
            {
                return Ok(await _lorryReceiptService.Gets(orgId, bookieId));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost("save")]
        public async Task<IActionResult> addLorryReceipt([FromRoute] Guid orgId, [FromRoute] Guid bookieId, [FromBody] LorryReceipt lorryReceipt)
        {
            try
            {
                return Ok(await _lorryReceiptService.Save(orgId, bookieId, lorryReceipt));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost("update")]
        public async Task<IActionResult> updateLorryReceipt([FromRoute] Guid orgId, [FromRoute] Guid bookieId, [FromBody] LorryReceipt lorryReceipt)
        {
            try
            {
                return Ok(await _lorryReceiptService.Update(orgId, bookieId, lorryReceipt));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpDelete("delete/{lorryReceiptId}")]
        public async Task<IActionResult> deleteLorryReceipt([FromRoute] Guid orgId, [FromRoute] Guid bookieId, [FromRoute] Guid lorryReceiptId)
        {
            try
            {
                int result = await _lorryReceiptService.Delete(orgId, bookieId, lorryReceiptId);
                if (result == 1)
                {
                    return Ok("Lorry Receipt Deleted Successfully");
                }
                return NotFound("Lorry Receipt Not Found");
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
