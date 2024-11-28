using Cgmail.Common.Entity;

namespace Cmail.Mailbox.Dmain.Entities.Attachment;

public class EmailAttachment : BaseEntity
{
    public string FileName { get; set; } = string.Empty;
    public long FileSize { get; set; }
    public string MimeType { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;
    public byte[] Content { get; set; } = new byte[0];
}
