using Cmail.Mailbox.Dmain.Data;
using Cmail.Mailbox.Dmain.Entities.Emails;
using Microsoft.EntityFrameworkCore;

namespace Cmail.Mailbox.Dmain.Repositoy.Mails;

public interface IEmailRepositoy 
{
    Task<List<Email>?> GetAllEmail();
}

public class EmailRepositoy : IEmailRepositoy
{
    private readonly MailboxContext _context;

    public EmailRepositoy(MailboxContext context)
    {
        _context = context;
    }

    public async Task<List<Email>?> GetAllEmail()
    {
        var result = await _context.Emails.ToListAsync();

        return result;
    }
}
