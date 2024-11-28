using Cgmail.Common.Entity;
using Cmail.Mailbox.Dmain.Entities.Attachment;

namespace Cmail.Mailbox.Dmain.Entities.Emails;

public class Email : AuditEntity
{
    public string Subject { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public string SenderEmail { get; set; } = string.Empty;
    public string RecipientEmail { get; set; } = string.Empty;
    public DateTimeOffset SentDate { get; set; }
    public bool IsRead { get; set; } = false;
    public int FolderId { get; set; }
    public bool IsStarred { get; set; } = false;
    public bool IsDraft { get; set; } = false;
    public string Cc { get; set; } = string.Empty;
    public string Bcc { get; set; } = string.Empty;
    public bool IsArchived { get; set; } = false;
    public ICollection<EmailAttachment> Attachments { get; set; } = new List<EmailAttachment>();
}
