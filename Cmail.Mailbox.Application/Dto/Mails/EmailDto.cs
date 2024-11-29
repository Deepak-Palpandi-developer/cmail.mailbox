using Cgmail.Common.Dto;
using Cmail.Mailbox.Application.Dto.Attachment;

namespace Cmail.Mailbox.Application.Dto.Mails;

public class EmailDto : BaseDto
{
    public string Subject { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public string SenderEmail { get; set; } = string.Empty;
    public string RecipientEmail { get; set; } = string.Empty;
    public DateTimeOffset SentDate { get; set; }
    public bool IsRead { get; set; } = false;
    public bool IsStarred { get; set; } = false;
    public bool IsDraft { get; set; } = false;
    public string Cc { get; set; } = string.Empty;
    public string Bcc { get; set; } = string.Empty;
    public bool IsArchived { get; set; } = false;
    public DateTimeOffset? UpdatedAt { get; set; }
    public string? UpdatedIp { get; set; } = string.Empty;
    public ICollection<EmailAttachmentDto> Attachments { get; set; } = new List<EmailAttachmentDto>();
}
