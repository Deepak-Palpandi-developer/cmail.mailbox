using Cmail.Mailbox.Dmain.Data;
using Cmail.Mailbox.Dmain.Entities.Masters;
using Microsoft.EntityFrameworkCore;

namespace Cmail.Mailbox.Dmain.Repositoy.Master;

public interface IFolderRepository
{
    Task<List<Folder>?> GetFoldersAsync();
}

public class FolderRepository : IFolderRepository
{
    private readonly MailboxContext _context;

    public FolderRepository(MailboxContext context)
    {
        _context = context;
    }

    public async Task<List<Folder>?> GetFoldersAsync()
    {
        return await _context.Folders.ToListAsync();
    }
}
