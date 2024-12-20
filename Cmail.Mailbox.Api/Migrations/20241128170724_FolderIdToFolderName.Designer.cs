﻿// <auto-generated />
using System;
using Cmail.Mailbox.Dmain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Cmail.Mailbox.Api.Migrations
{
    [DbContext(typeof(MailboxContext))]
    [Migration("20241128170724_FolderIdToFolderName")]
    partial class FolderIdToFolderName
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Cmail.Mailbox.Dmain.Entities.Attachment.EmailAttachment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    b.Property<byte[]>("Content")
                        .IsRequired()
                        .HasColumnType("bytea")
                        .HasColumnName("content");

                    b.Property<Guid?>("EmailId")
                        .HasColumnType("uuid")
                        .HasColumnName("email_id");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("file_name");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("file_path");

                    b.Property<long>("FileSize")
                        .HasColumnType("bigint")
                        .HasColumnName("file_size");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active")
                        .HasColumnOrder(100);

                    b.Property<string>("MimeType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("mime_type");

                    b.HasKey("Id")
                        .HasName("pk_email_attachment");

                    b.HasIndex("EmailId")
                        .HasDatabaseName("ix_email_attachment_email_id");

                    b.HasIndex("FileName")
                        .HasDatabaseName("ix_email_attachment_file_name");

                    b.ToTable("email_attachment", (string)null);
                });

            modelBuilder.Entity("Cmail.Mailbox.Dmain.Entities.Emails.Email", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    b.Property<string>("Bcc")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("bcc");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("body");

                    b.Property<string>("Cc")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("cc");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasColumnOrder(103);

                    b.Property<string>("CreatedIp")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("created_ip")
                        .HasColumnOrder(104);

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at")
                        .HasColumnOrder(109);

                    b.Property<string>("DeletedIp")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("deleted_ip")
                        .HasColumnOrder(110);

                    b.Property<string>("FolderName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("folder_name");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active")
                        .HasColumnOrder(100);

                    b.Property<bool>("IsArchived")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("is_archived");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted")
                        .HasColumnOrder(101);

                    b.Property<bool>("IsDraft")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("is_draft");

                    b.Property<bool>("IsRead")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("is_read");

                    b.Property<bool>("IsStarred")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("is_starred");

                    b.Property<string>("RecipientEmail")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("recipient_email");

                    b.Property<string>("SenderEmail")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("sender_email");

                    b.Property<DateTimeOffset>("SentDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("sent_date");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("subject");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at")
                        .HasColumnOrder(106);

                    b.Property<string>("UpdatedIp")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("updated_ip")
                        .HasColumnOrder(107);

                    b.HasKey("Id")
                        .HasName("pk_emails");

                    b.HasIndex("RecipientEmail")
                        .HasDatabaseName("ix_emails_recipient_email");

                    b.HasIndex("SenderEmail")
                        .HasDatabaseName("ix_emails_sender_email");

                    b.HasIndex("SentDate")
                        .HasDatabaseName("ix_emails_sent_date");

                    b.ToTable("emails", (string)null);
                });

            modelBuilder.Entity("Cmail.Mailbox.Dmain.Entities.Masters.Folder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("integer")
                        .HasColumnName("display_order");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active")
                        .HasColumnOrder(100);

                    b.Property<bool>("IsSystemFolder")
                        .HasColumnType("boolean")
                        .HasColumnName("is_system_folder");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_folder_master");

                    b.ToTable("folder_master", "master");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d4db7ec0-7a48-492d-bebe-6688c8eba285"),
                            Description = "Folder for received emails",
                            DisplayOrder = 1,
                            IsActive = true,
                            IsSystemFolder = true,
                            Name = "Inbox"
                        },
                        new
                        {
                            Id = new Guid("5672767b-1012-4ba2-ba41-41bf8067761a"),
                            Description = "Folder for sent emails",
                            DisplayOrder = 2,
                            IsActive = true,
                            IsSystemFolder = true,
                            Name = "Sent"
                        },
                        new
                        {
                            Id = new Guid("054b3eb4-08b0-4254-8654-42eed3c913d9"),
                            Description = "Folder for draft emails",
                            DisplayOrder = 3,
                            IsActive = true,
                            IsSystemFolder = true,
                            Name = "Drafts"
                        },
                        new
                        {
                            Id = new Guid("a4726ac4-893a-4a19-b0e3-bca2b41d1120"),
                            Description = "Folder for deleted emails",
                            DisplayOrder = 4,
                            IsActive = true,
                            IsSystemFolder = true,
                            Name = "Trash"
                        },
                        new
                        {
                            Id = new Guid("4e7248be-4bb3-422d-82e7-f9b9c2d3a774"),
                            Description = "Folder for archived emails",
                            DisplayOrder = 5,
                            IsActive = true,
                            IsSystemFolder = true,
                            Name = "Archive"
                        });
                });

            modelBuilder.Entity("Cmail.Mailbox.Dmain.Entities.Attachment.EmailAttachment", b =>
                {
                    b.HasOne("Cmail.Mailbox.Dmain.Entities.Emails.Email", null)
                        .WithMany("Attachments")
                        .HasForeignKey("EmailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("fk_email_attachment_emails_email_id");
                });

            modelBuilder.Entity("Cmail.Mailbox.Dmain.Entities.Emails.Email", b =>
                {
                    b.Navigation("Attachments");
                });
#pragma warning restore 612, 618
        }
    }
}
