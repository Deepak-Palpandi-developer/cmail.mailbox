using Cgmail.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmail.Mailbox.Application.Dto.Attachment;

public class EmailAttachmentDto: BaseDto
{
    public string FileName { get; set; } = string.Empty;
    public long FileSize { get; set; }
    public string MimeType { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;
    public byte[] Content { get; set; } = new byte[0];
}
