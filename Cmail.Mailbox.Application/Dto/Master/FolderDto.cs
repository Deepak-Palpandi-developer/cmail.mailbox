using Cgmail.Common.Dto;

namespace Cmail.Mailbox.Application.Dto.Master;

public class FolderDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsSystemFolder { get; set; } = false;
    public int DisplayOrder { get; set; }
}
