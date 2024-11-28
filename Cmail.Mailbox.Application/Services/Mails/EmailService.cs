using AutoMapper;
using Cmail.Mailbox.Application.Dto.Mails;
using Cmail.Mailbox.Dmain.Repositoy.Mails;
using Microsoft.Extensions.Configuration;

namespace Cmail.Mailbox.Application.Services.Mails;

public interface IEmailService
{
    Task<List<EmailDto>?> GetAllEmailsAsync();
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

    public async Task<List<EmailDto>?> GetAllEmailsAsync()
    {
        var data = await _emailRepositoy.GetAllEmail();

        if (data != null && data.Any())
        {
            return _mapper.Map<List<EmailDto>>(data);
        }
        return null;
    }
}
