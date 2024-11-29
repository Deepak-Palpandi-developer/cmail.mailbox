using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cmail.Mailbox.Api.Migrations
{
    /// <inheritdoc />
    public partial class FolderIdToFolderName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "master",
                table: "folder_master",
                keyColumn: "id",
                keyValue: new Guid("581600ec-111f-4513-989f-2d689297c9fa"));

            migrationBuilder.DeleteData(
                schema: "master",
                table: "folder_master",
                keyColumn: "id",
                keyValue: new Guid("69f2c8dd-fc00-4dc8-a7da-44f6839f008e"));

            migrationBuilder.DeleteData(
                schema: "master",
                table: "folder_master",
                keyColumn: "id",
                keyValue: new Guid("6f830b28-8bb6-413f-9855-48ead8be6740"));

            migrationBuilder.DeleteData(
                schema: "master",
                table: "folder_master",
                keyColumn: "id",
                keyValue: new Guid("7abe732b-602e-4b96-bbe0-0415b1e7d5bd"));

            migrationBuilder.DeleteData(
                schema: "master",
                table: "folder_master",
                keyColumn: "id",
                keyValue: new Guid("a7967be3-6e53-45c4-bceb-4a6871a726a3"));

            migrationBuilder.DropColumn(
                name: "folder_id",
                table: "emails");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "folder_id",
                table: "emails",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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
        }
    }
}
