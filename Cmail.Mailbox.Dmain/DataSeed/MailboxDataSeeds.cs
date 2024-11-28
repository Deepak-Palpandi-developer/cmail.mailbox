using Cmail.Mailbox.Dmain.Entities.Masters;

namespace Cmail.Mailbox.Dmain.DataSeed;

public static class MailboxDataSeeds
{
    public static List<Folder> Folders { get; set; } = new List<Folder>()
    {
         new Folder
            {
                Id = Guid.NewGuid(),
                Name = "Inbox",
                Description = "Folder for received emails",
                IsSystemFolder = true,
                DisplayOrder = 1
            },
            new Folder
            {
                Id = Guid.NewGuid(),
                Name = "Sent",
                Description = "Folder for sent emails",
                IsSystemFolder = true,
                DisplayOrder = 2
            },
            new Folder
            {
                Id = Guid.NewGuid(),
                Name = "Drafts",
                Description = "Folder for draft emails",
                IsSystemFolder = true,
                DisplayOrder = 3
            },
            new Folder
            {
                Id = Guid.NewGuid(),
                Name = "Trash",
                Description = "Folder for deleted emails",
                IsSystemFolder = true,
                DisplayOrder = 4
            },
            new Folder
            {
                Id = Guid.NewGuid(),
                Name = "Archive",
                Description = "Folder for archived emails",
                IsSystemFolder = true,
                DisplayOrder = 5
            }
    };
}
