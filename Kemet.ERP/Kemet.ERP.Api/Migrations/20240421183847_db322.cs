using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kemet.ERP.Api.Migrations
{
    /// <inheritdoc />
    public partial class db322 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserMaster",
                keyColumn: "Id",
                keyValue: "e16742f1-e982-4dad-8b24-295cbf858d48");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "RolePageMaster");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "RolePageMaster");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PageMaster");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "PageMaster");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ModuleMaster");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "ModuleMaster");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "MenuMaster");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "MenuMaster");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "RolePageMaster",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "RegionMaster",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PageMaster",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ModuleMaster",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MenuMaster",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CountryMaster",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "UserMaster",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8fd7f2a2-32ae-4024-b745-dc8f4a70f8ab", 0, "d784db29-37e2-4445-8c88-5237b7e286d9", "info@cyberkemet.com", true, "Cyber", "Kemet", false, null, "INFO@CYBERKEMET.COM", "CYBER-KEMET", "AQAAAAIAAYagAAAAEBPWjC8a6M0uddHZKvbhCo0wvRO5tqIc9Njh8IRbZClhG0WBURLOEQdzshLCzh7wuA==", "01111257052", true, "8b0d9e5d-0634-4aa5-8b5f-623123bba1d9", false, "cyber-kemet" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserMaster",
                keyColumn: "Id",
                keyValue: "8fd7f2a2-32ae-4024-b745-dc8f4a70f8ab");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "RolePageMaster");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "RegionMaster");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PageMaster");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ModuleMaster");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MenuMaster");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CountryMaster");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "RolePageMaster",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "RolePageMaster",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "PageMaster",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "PageMaster",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ModuleMaster",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "ModuleMaster",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "MenuMaster",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "MenuMaster",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "UserMaster",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e16742f1-e982-4dad-8b24-295cbf858d48", 0, "d1be02aa-f431-49e8-8ee9-3fbe860db906", "info@cyberkemet.com", true, "Cyber", "Kemet", false, null, "INFO@CYBERKEMET.COM", "CYBER-KEMET", "AQAAAAIAAYagAAAAEHh6w024WqYdVTaCvmdMhi/bgiFgFEAklyof3PL9XjS8gSyvzkIxVL7EmGVb3MGBkw==", "01111257052", true, "e5777fbc-f22b-4277-8b2b-adf064995278", false, "cyber-kemet" });
        }
    }
}
