using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalArchive.DataAccess.Migrations
{
    public partial class mig_8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Category",
                newName: "IsDeleted");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Category",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatorUserId",
                table: "Category",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Category",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletorUserId",
                table: "Category",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "Category",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LastModifierUserId",
                table: "Category",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "DeletorUserId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "Category");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Category",
                newName: "IsActive");
        }
    }
}
