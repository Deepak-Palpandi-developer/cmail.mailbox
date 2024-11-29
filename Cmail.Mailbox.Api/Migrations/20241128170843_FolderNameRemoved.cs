using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cmail.Mailbox.Api.Migrations
{
    /// <inheritdoc />
    public partial class FolderNameRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "master",
                table: "folder_master",
                keyColumn: "id",
                keyValue: new Guid("054b3eb4-08b0-4254-8654-42eed3c913d9"));

            migrationBuilder.DeleteData(
                schema: "master",
                table: "folder_master",
                keyColumn: "id",
                keyValue: new Guid("4e7248be-4bb3-422d-82e7-f9b9c2d3a774"));

            migrationBuilder.DeleteData(
                schema: "master",
                table: "folder_master",
                keyColumn: "id",
                keyValue: new Guid("5672767b-1012-4ba2-ba41-41bf8067761a"));

            migrationBuilder.DeleteData(
                schema: "master",
                table: "folder_master",
                keyColumn: "id",
                keyValue: new Guid("a4726ac4-893a-4a19-b0e3-bca2b41d1120"));

            migrationBuilder.DeleteData(
                schema: "master",
                table: "folder_master",
                keyColumn: "id",
                keyValue: new Guid("d4db7ec0-7a48-492d-bebe-6688c8eba285"));

            migrationBuilder.DropColumn(
                name: "folder_name",
                table: "emails");

            migrationBuilder.InsertData(
                schema: "master",
                table: "folder_master",
                columns: new[] { "id", "description", "display_order", "is_active", "is_system_folder", "name" },
                values: new object[,]
                {
                    { new Guid("0fcf6ae0-e704-4e89-8d11-56e019f1efa6"), "Folder for sent emails", 2, true, true, "Sent" },
                    { new Guid("78df5801-c780-4ea6-a868-d82b92771715"), "Folder for draft emails", 3, true, true, "Drafts" },
                    { new Guid("d3832585-2b19-46d3-bd98-057895cbd093"), "Folder for deleted emails", 4, true, true, "Trash" },
                    { new Guid("d59c0872-c8c8-4bd8-bcfa-8091b8628ad1"), "Folder for archived emails", 5, true, true, "Archive" },
                    { new Guid("d930bb17-99b5-4f93-b1c8-b1a8a520563a"), "Folder for received emails", 1, true, true, "Inbox" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "master",
                table: "folder_master",
                keyColumn: "id",
                keyValue: new Guid("0fcf6ae0-e704-4e89-8d11-56e019f1efa6"));

            migrationBuilder.DeleteData(
                schema: "master",
                table: "folder_master",
                keyColumn: "id",
                keyValue: new Guid("78df5801-c780-4ea6-a868-d82b92771715"));

            migrationBuilder.DeleteData(
                schema: "master",
                table: "folder_master",
                keyColumn: "id",
                keyValue: new Guid("d3832585-2b19-46d3-bd98-057895cbd093"));

            migrationBuilder.DeleteData(
                schema: "master",
                table: "folder_master",
                keyColumn: "id",
                keyValue: new Guid("d59c0872-c8c8-4bd8-bcfa-8091b8628ad1"));

            migrationBuilder.DeleteData(
                schema: "master",
                table: "folder_master",
                keyColumn: "id",
                keyValue: new Guid("d930bb17-99b5-4f93-b1c8-b1a8a520563a"));

            migrationBuilder.AddColumn<string>(
                name: "folder_name",
                table: "emails",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                schema: "master",
                table: "folder_master",
                columns: new[] { "id", "description", "display_order", "is_active", "is_system_folder", "name" },
                values: new object[,]
                {
                    { new Guid("054b3eb4-08b0-4254-8654-42eed3c913d9"), "Folder for draft emails", 3, true, true, "Drafts" },
                    { new Guid("4e7248be-4bb3-422d-82e7-f9b9c2d3a774"), "Folder for archived emails", 5, true, true, "Archive" },
                    { new Guid("5672767b-1012-4ba2-ba41-41bf8067761a"), "Folder for sent emails", 2, true, true, "Sent" },
                    { new Guid("a4726ac4-893a-4a19-b0e3-bca2b41d1120"), "Folder for deleted emails", 4, true, true, "Trash" },
                    { new Guid("d4db7ec0-7a48-492d-bebe-6688c8eba285"), "Folder for received emails", 1, true, true, "Inbox" }
                });
        }
    }
}
