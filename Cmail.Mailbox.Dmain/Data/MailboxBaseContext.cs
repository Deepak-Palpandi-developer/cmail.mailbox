using Cmail.Mailbox.Dmain.DataSeed;
using Cmail.Mailbox.Dmain.Entities.Attachment;
using Cmail.Mailbox.Dmain.Entities.Emails;
using Cmail.Mailbox.Dmain.Entities.Masters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cmail.Mailbox.Dmain.Data;

public class MailboxBaseContext<T> : DbContext where T : DbContext
{
    public MailboxBaseContext(DbContextOptions<T> options) : base(options) { }

    public DbSet<Email> Emails { get; set; }
    public DbSet<Folder> Folders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigEmailEntity(modelBuilder.Entity<Email>());

        ConfigAttachmentEntity(modelBuilder.Entity<EmailAttachment>());

        ConfigFolderEntity(modelBuilder.Entity<Folder>());
    }

    private static void ConfigEmailEntity(EntityTypeBuilder<Email> entity)
    {
        entity.HasKey(e => e.Id);

        // Properties
        entity.Property(e => e.Subject)
            .IsRequired()
            .HasMaxLength(255);

        entity.Property(e => e.Body)
            .IsRequired();

        entity.Property(e => e.SenderEmail)
            .IsRequired()
            .HasMaxLength(255);

        entity.Property(e => e.RecipientEmail)
            .IsRequired()
            .HasMaxLength(255);

        entity.Property(e => e.SentDate)
            .IsRequired();

        entity.Property(e => e.IsRead)
            .HasDefaultValue(false);

        entity.Property(e => e.FolderId)
            .IsRequired();

        entity.Property(e => e.IsStarred)
            .HasDefaultValue(false);

        entity.Property(e => e.IsDraft)
            .HasDefaultValue(false);

        entity.Property(e => e.Cc)
            .HasMaxLength(500);

        entity.Property(e => e.Bcc)
            .HasMaxLength(500);

        entity.Property(e => e.IsArchived)
            .HasDefaultValue(false);

        // Relationships
        entity.HasMany(e => e.Attachments)
            .WithOne()
            .HasForeignKey("EmailId") // Foreign key in EmailAttachment
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        entity.HasIndex(e => e.SenderEmail);
        entity.HasIndex(e => e.RecipientEmail);
        entity.HasIndex(e => e.SentDate);
    }

    private static void ConfigAttachmentEntity(EntityTypeBuilder<EmailAttachment> entity)
    {
        entity.HasKey(e => e.Id);

        // Properties
        entity.Property(ea => ea.FileName)
            .IsRequired()
            .HasMaxLength(255);

        entity.Property(ea => ea.FileSize)
            .IsRequired();

        entity.Property(ea => ea.MimeType)
            .IsRequired()
            .HasMaxLength(50);

        entity.Property(ea => ea.FilePath)
            .HasMaxLength(500);

        entity.Property(ea => ea.Content)
            .IsRequired();

        // Indexes
        entity.HasIndex(ea => ea.FileName);
    }

    private static void ConfigFolderEntity(EntityTypeBuilder<Folder> entity)
    {
        entity.ToTable("folder_master", "master");
        entity.HasKey(e => e.Id);
        entity.HasData(MailboxDataSeeds.Folders);
    }
}


public class MailboxContext : MailboxBaseContext<MailboxContext>
{
    public MailboxContext(DbContextOptions<MailboxContext> context) : base(context) { }
}