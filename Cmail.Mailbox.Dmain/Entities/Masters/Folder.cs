using Cgmail.Common.Entity;

namespace Cmail.Mailbox.Dmain.Entities.Masters;

public class Folder : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsSystemFolder { get; set; } = false;
    public int DisplayOrder { get; set; }
}
