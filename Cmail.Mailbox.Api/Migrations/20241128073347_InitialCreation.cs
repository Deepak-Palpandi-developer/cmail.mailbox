using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cmail.Mailbox.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "master");

            migrationBuilder.CreateTable(
                name: "emails",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_ip = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    updated_ip = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_ip = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    subject = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    body = table.Column<string>(type: "text", nullable: false),
                    sender_email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    recipient_email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    sent_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    is_read = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    folder_id = table.Column<int>(type: "integer", nullable: false),
                    is_starred = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    is_draft = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    cc = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    bcc = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    is_archived = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_emails", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "folder_master",
                schema: "master",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    is_system_folder = table.Column<bool>(type: "boolean", nullable: false),
                    display_order = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_folder_master", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "email_attachment",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    file_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    file_size = table.Column<long>(type: "bigint", nullable: false),
                    mime_type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    file_path = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    content = table.Column<byte[]>(type: "bytea", nullable: false),
                    email_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_email_attachment", x => x.id);
                    table.ForeignKey(
                        name: "fk_email_attachment_emails_email_id",
                        column: x => x.email_id,
                        principalTable: "emails",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "master",
                table: "folder_master",
                columns: new[] { "id", "description", "display_order", "is_active", "is_system_folder", "name" },
                values: new object[,]
                {
                    { new Guid("581600ec-111f-4513-989f-2d689297c9fa"), "Folder for deleted emails", 4, true, true, "Trash" },
                    { new Guid("69f2c8dd-fc00-4dc8-a7da-44f6839f008e"), "Folder for received emails", 1, true, true, "Inbox" },
                    { new Guid("6f830b28-8bb6-413f-9855-48ead8be6740"), "Folder for sent emails", 2, true, true, "Sent" },
                    { new Guid("7abe732b-602e-4b96-bbe0-0415b1e7d5bd"), "Folder for draft emails", 3, true, true, "Drafts" },
                    { new Guid("a7967be3-6e53-45c4-bceb-4a6871a726a3"), "Folder for archived emails", 5, true, true, "Archive" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_email_attachment_email_id",
                table: "email_attachment",
                column: "email_id");

            migrationBuilder.CreateIndex(
                name: "ix_email_attachment_file_name",
                table: "email_attachment",
                column: "file_name");

            migrationBuilder.CreateIndex(
                name: "ix_emails_recipient_email",
                table: "emails",
                column: "recipient_email");

            migrationBuilder.CreateIndex(
                name: "ix_emails_sender_email",
                table: "emails",
                column: "sender_email");

            migrationBuilder.CreateIndex(
                name: "ix_emails_sent_date",
                table: "emails",
                column: "sent_date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "email_attachment");

            migrationBuilder.DropTable(
                name: "folder_master",
                schema: "master");

            migrationBuilder.DropTable(
                name: "emails");
        }
    }
}
