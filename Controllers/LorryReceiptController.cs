using Microsoft.AspNetCore.Mvc;
using gaadi_ghoda_server.Models;
using gaadi_ghoda_server.Service;
using gaadi_ghoda_server.IService.IBookieService;
using System.Net;

namespace gaadi_ghoda_server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LorryReceiptController : ControllerBase
    {
        private readonly IBookieLorryReceiptService _lorryReceiptService;
        public LorryReceiptController(IBookieLorryReceiptService lorryReceiptService)
        {
            _lorryReceiptService = lorryReceiptService;
        }

        [HttpGet("get")]
        public async Task<IActionResult> getLorryReceipt([FromBody] LorryReceipt lorryReceipt)
        {
            try
            {
                return Ok(await _lorryReceiptService.Get(lorryReceipt.Id));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet("gets")]
        public async Task<IActionResult> getLorryReceiptList()
        {
            try
            {
                return Ok(await _lorryReceiptService.Gets());
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost("save")]
        public async Task<IActionResult> addLorryReceipt([FromBody] LorryReceipt lorryReceipt)
        {
            try
            {
                return Ok(await _lorryReceiptService.Save(lorryReceipt));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost("update")]
        public async Task<IActionResult> updateLorryReceipt([FromBody] LorryReceipt lorryReceipt)
        {
            try
            {
                return Ok(await _lorryReceiptService.Update(lorryReceipt));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost("delete")]
        public async Task<IActionResult> deleteLorryReceipt([FromBody] LorryReceipt lorryReceipt)
        {
            try
            {
                int result = await _lorryReceiptService.Delete(lorryReceipt.Id);
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
