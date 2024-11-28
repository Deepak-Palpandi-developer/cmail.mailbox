using Cgmail.Common.Exceptions;
using Cmail.Mailbox.Application.Services.Master;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cmail.Mailbox.Api.Controllers.Master;

[Authorize]
[Route("[controller]")]
[ApiController]
public class FolderController : ControllerBase
{
    private readonly ILogger<FolderController> _logger;
    private readonly IFolderService _folderService;

    public FolderController(ILogger<FolderController> logger, IFolderService folderService)
    {
        _logger = logger;
        _folderService = folderService;
    }

    [HttpPost("get-folders")]
    public async Task<IActionResult> GetFoldersAsync()
    {
        try
        {
            var result = await _folderService.GetFoldersAsync();

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
