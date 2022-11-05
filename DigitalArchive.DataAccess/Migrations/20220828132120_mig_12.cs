using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalArchive.DataAccess.Migrations
{
    public partial class mig_12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "UserDocument");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "UserDocument");

            migrationBuilder.RenameColumn(
                name: "UpdatorUserId",
                table: "UserDocument",
                newName: "DocumentId");

            migrationBuilder.RenameColumn(
                name: "DeleterUserId",
                table: "UserDocument",
                newName: "CategoryId");

            migrationBuilder.AlterColumn<int>(
                name: "CreatorUserId",
                table: "UserDocument",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "UserDocument",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletorUserId",
                table: "UserDocument",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "UserDocument",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LastModifierUserId",
                table: "UserDocument",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CategoryType",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatorUserId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifierUserId = table.Column<int>(type: "int", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletorUserId = table.Column<int>(type: "int", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "UserDocument");

            migrationBuilder.DropColumn(
                name: "DeletorUserId",
                table: "UserDocument");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "UserDocument");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "UserDocument");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "CategoryType");

            migrationBuilder.RenameColumn(
                name: "DocumentId",
                table: "UserDocument",
                newName: "UpdatorUserId");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "UserDocument",
                newName: "DeleterUserId");

            migrationBuilder.AlterColumn<int>(
                name: "CreatorUserId",
                table: "UserDocument",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "UserDocument",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "UserDocument",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
