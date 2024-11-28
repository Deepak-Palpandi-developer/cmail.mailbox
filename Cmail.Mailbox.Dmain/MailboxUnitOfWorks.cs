using Cgmail.Common;
using Cmail.Mailbox.Dmain.Data;

namespace Cmail.Mailbox.Dmain;

public interface IMailboxUnitOfWorks : IUnitOfWork { }

public class MailboxUnitOfWorks : UnitOfWork, IMailboxUnitOfWorks
{
    public MailboxUnitOfWorks(MailboxContext context) : base(context) { }
}
