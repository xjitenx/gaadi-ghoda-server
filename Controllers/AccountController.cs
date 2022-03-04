﻿using gaadi_ghoda_server.IService.ICommonService;
using gaadi_ghoda_server.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace gaadi_ghoda_server.Controllers
{
    [Route("api/{orgId}/account")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("get/{accountId}")]
        public async Task<IActionResult> getAccount([FromRoute] Guid orgId, [FromRoute] Guid accountId)
        {
            try
            {
                return Ok(await _accountService.Get(orgId, accountId));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet("gets")]
        public async Task<IActionResult> getAccountList([FromRoute] Guid orgId)
        {
            try
            {
                return Ok(await _accountService.Gets(orgId));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost("save")]
        public async Task<IActionResult> addAccount([FromRoute] Guid orgId, [FromBody] Account account)
        {
            try
            {
                return Ok(await _accountService.Save(orgId, account));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost("update")]
        public async Task<IActionResult> updateAccount([FromRoute] Guid orgId, [FromBody] Account Account)
        {
            try
            {
                return Ok(await _accountService.Update(orgId, Account));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpDelete("delete/{accountId}")]
        public async Task<IActionResult> deleteAccount([FromRoute] Guid orgId, [FromRoute] Guid accountId)
        {
            try
            {
                int result = await _accountService.Delete(orgId, accountId);
                if (result == 1)
                {
                    return Ok("Account Deleted Successfully");
                }
                return NotFound("Account Not Found");
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
