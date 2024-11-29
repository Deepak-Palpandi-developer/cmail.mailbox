using Cmail.Mailbox.Dmain.Data;
using Cmail.Mailbox.Dmain.Entities.Emails;
using Microsoft.EntityFrameworkCore;

namespace Cmail.Mailbox.Dmain.Repositoy.Mails;

public interface IEmailRepositoy
{
    Task<List<Email>?> GetAllEmail();
    Task<List<Email>?> GetInboxEmails(string recipientEmail);
    Task<List<Email>?> GetSenderEmails(string senderEmail);
    Task SaveComposeEmail(Email email);
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

    public async Task<List<Email>?> GetInboxEmails(string recipientEmail)
    {
        return await _context.Emails.
                                Include(x => x.Attachments).
                                Where(x =>
                                string.Equals(x.RecipientEmail, recipientEmail)).
                                ToListAsync();
    }

    public async Task<List<Email>?> GetSenderEmails(string senderEmail)
    {
        return await _context.Emails.
                                Include(x => x.Attachments).
                                Where(x =>
                                string.Equals(x.SenderEmail, senderEmail)).
                                ToListAsync();
    }

    public async Task SaveComposeEmail(Email email)
    {
        _context.Emails.Add(email);

        await _context.SaveChangesAsync();
    }
}
