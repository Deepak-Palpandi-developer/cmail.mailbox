using AutoMapper;
using Cgmail.Common.Model;
using Cmail.Mailbox.Application.Dto.Mails;
using Cmail.Mailbox.Dmain.Entities.Emails;
using Cmail.Mailbox.Dmain.Repositoy.Mails;
using Microsoft.Extensions.Configuration;

namespace Cmail.Mailbox.Application.Services.Mails;

public interface IEmailService
{
    Task<Response<List<EmailDto>?>> FetchAllEmailsAsync();
    Task<Response<EmailDto?>> ComposeEmailAsync(EmailDto? dto, string myIP);
    Task<Response<List<EmailDto>?>> FetchInboxMails(string recipientEmail);
    Task<Response<List<EmailDto>?>> FetchSenderMails(string senderMail);
}

public class EmailService : IEmailService
{
    private readonly IEmailRepositoy _emailRepositoy;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;

    public EmailService(IEmailRepositoy emailRepositoy, IConfiguration configuration, IMapper mapper)
    {
        _emailRepositoy = emailRepositoy;
        _configuration = configuration;
        _mapper = mapper;
    }

    public async Task<Response<List<EmailDto>?>> FetchAllEmailsAsync()
    {
        var data = await _emailRepositoy.GetAllEmail();

        return new Response<List<EmailDto>?>
        {
            IsSuccess = true,
            Message = "Data Fetched Success",
            Data = _mapper.Map<List<EmailDto>>(data)
        };
    }

    public async Task<Response<EmailDto?>> ComposeEmailAsync(EmailDto? dto, string myIP)
    {
        if (dto == null)
        {
            return new Response<EmailDto?>
            {
                IsSuccess = false,
                Message = "Error composing email"
            };
        }
        else
        {
            var entity = _mapper.Map<Email>(dto);

            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            entity.CreatedIp = myIP;
            entity.UpdatedIp = myIP;
            entity.SentDate = DateTime.UtcNow;

            await _emailRepositoy.SaveComposeEmail(entity);

            return new Response<EmailDto?>
            {
                IsSuccess = true,
                Message = "Email send successfully",
                Data = _mapper.Map<EmailDto>(entity)
            };
        }
    }

    public async Task<Response<List<EmailDto>?>> FetchInboxMails(string recipientEmail)
    {
        if (string.IsNullOrEmpty(recipientEmail))
        {
            return new Response<List<EmailDto>?>()
            {
                IsSuccess = false,
                Message = "Invalid Recipient Email"
            };
        }
        else
        {
            var entity = await _emailRepositoy.GetInboxEmails(recipientEmail);
            return new Response<List<EmailDto>?>
            {
                IsSuccess = true,
                Data = _mapper.Map<List<EmailDto>?>(entity),
                Message = "Data Fetched"
            };

        }

    }

    public async Task<Response<List<EmailDto>?>> FetchSenderMails(string senderMail)
    {
        if (string.IsNullOrEmpty(senderMail))
        {
            return new Response<List<EmailDto>?>()
            {
                IsSuccess = false,
                Message = "Invalid Recipient Email"
            };
        }
        else
        {
            var entity = await _emailRepositoy.GetSenderEmails(senderMail);

            return new Response<List<EmailDto>?>
            {
                IsSuccess = true,
                Data = _mapper.Map<List<EmailDto>?>(entity),
                Message = "Data Fetched"
            };
        }

    }

    #region Private Methods
    #endregion
}
