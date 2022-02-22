using Microsoft.AspNetCore.Mvc;
using gaadi_ghoda_server.Models;
using gaadi_ghoda_server.Service;
using gaadi_ghoda_server.IService.IBookieService;
using System.Net;

namespace gaadi_ghoda_server.Controllers
{
    [Route("api/bookie/{bookieId}/lorryreceipt")]
    [ApiController]
    public class BookieLorryReceiptController : ControllerBase
    {
        private readonly IBookieLorryReceiptService _lorryReceiptService;
        public BookieLorryReceiptController(IBookieLorryReceiptService lorryReceiptService)
        {
            _lorryReceiptService = lorryReceiptService;
        }

        [HttpGet("get")]
        public async Task<IActionResult> getLorryReceipt([FromBody] LorryReceipt lorryReceipt, string bookieId)
        {
            try
            {
                return Ok(await _lorryReceiptService.Get(lorryReceipt.Id, bookieId));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet("gets")]
        public async Task<IActionResult> getLorryReceiptList(string bookieId)
        {
            try
            {
                return Ok(await _lorryReceiptService.Gets(bookieId));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost("save")]
        public async Task<IActionResult> addLorryReceipt([FromBody] LorryReceipt lorryReceipt, string bookieId)
        {
            try
            {
                return Ok(await _lorryReceiptService.Save(lorryReceipt, bookieId));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost("update")]
        public async Task<IActionResult> updateLorryReceipt([FromBody] LorryReceipt lorryReceipt, string bookieId)
        {
            try
            {
                return Ok(await _lorryReceiptService.Update(lorryReceipt, bookieId));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost("delete")]
        public async Task<IActionResult> deleteLorryReceipt([FromBody] LorryReceipt lorryReceipt, string bookieId)
        {
            try
            {
                int result = await _lorryReceiptService.Delete(lorryReceipt.Id, bookieId);
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
