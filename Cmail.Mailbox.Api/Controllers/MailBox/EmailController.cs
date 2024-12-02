using Cgmail.Common.Exceptions;
using Cgmail.Common.Helpers;
using Cmail.Mailbox.Application.Dto.Mails;
using Cmail.Mailbox.Application.Services.Mails;
using Cmail.Mailbox.Application.ViewModels;
using Cmail.Mailbox.Communication.Hubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

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
            var result = await _service.FetchAllEmailsAsync();

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

    [HttpPost("compose-email")]
    public async Task<IActionResult> ComposeEmail(EmailDto dto)
    {
        try
        {
            string myIP = CommonHelper.GetIPAddress(HttpContext) ?? string.Empty;

            var result = await _service.ComposeEmailAsync(dto, myIP);

            var hubContext = HttpContext.RequestServices.GetService<IHubContext<EmailHub>>();

            await hubContext!.Clients.All.SendAsync("ReceiveEmailNotification", "Email successfully sent to recipients.");

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

    [HttpPost("inbox-emails")]
    public async Task<IActionResult> InboxMail(UserEmail userEmail)
    {
        try
        {
            var result = await _service.FetchInboxMails(userEmail.Email);

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

    [HttpPost("sender-emails")]
    public async Task<IActionResult> SenderMails(UserEmail userEmail)
    {
        try
        {
            var result = await _service.FetchSenderMails(userEmail.Email);

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
