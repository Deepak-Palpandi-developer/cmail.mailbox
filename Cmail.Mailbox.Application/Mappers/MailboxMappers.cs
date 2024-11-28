using AutoMapper;
using Cmail.Mailbox.Application.Dto.Attachment;
using Cmail.Mailbox.Application.Dto.Mails;
using Cmail.Mailbox.Application.Dto.Master;
using Cmail.Mailbox.Dmain.Entities.Attachment;
using Cmail.Mailbox.Dmain.Entities.Emails;
using Cmail.Mailbox.Dmain.Entities.Masters;

namespace Cmail.Mailbox.Application.Mappers;

public class MailboxMappers : Profile
{
    public MailboxMappers()
    {
        CreateMap<Email, EmailDto>().ReverseMap();
        CreateMap<EmailAttachment, EmailAttachmentDto>().ReverseMap();
        CreateMap<Folder,FolderDto>().ReverseMap();
    }
}
