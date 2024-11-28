﻿using Cgmail.Common.Exceptions;
using Cmail.Mailbox.Application.Services.Mails;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cmail.Mailbox.Api.Controllers.MailBox;

[Authorize]
[Route("[controller]")]
[ApiController]
public class EmailController : ControllerBase
{
    private readonly ILogger<EmailController> _logger;
    private readonly IEmailService _service;

    public EmailController(IEmailService service, ILogger<EmailController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpPost("get-all-mails")]
    public async Task<IActionResult> GetAllMailsAsycnc()
    {
        try
        {
            var result = await _service.GetAllEmailsAsync();

            return Ok(result);
        }
        catch (BadRequestException brex)
        {
            _logger.LogWarning(brex, brex.Message);
            return BadRequest(new
            {
                brex.Message
            });
        }
        catch (NotFoundException nfx)
        {
            _logger.LogWarning(nfx, nfx.Message);
            return NotFound(new { nfx.Source, nfx.Message });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(417, new { ex.Message });
        }
    }
}