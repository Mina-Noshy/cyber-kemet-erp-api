using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kemet.ERP.Api.Migrations
{
    /// <inheritdoc />
    public partial class db323 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserMaster",
                keyColumn: "Id",
                keyValue: "8fd7f2a2-32ae-4024-b745-dc8f4a70f8ab");

            migrationBuilder.DropColumn(
                name: "ArName",
                table: "RegionMaster");

            migrationBuilder.DropColumn(
                name: "ArName",
                table: "CountryMaster");

            migrationBuilder.RenameColumn(
                name: "EnName",
                table: "RegionMaster",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "EnName",
                table: "CountryMaster",
                newName: "Name");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "RolePageMaster",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "RegionMaster",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "PageMaster",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "ModuleMaster",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "MenuMaster",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "CountryMaster",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.InsertData(
                table: "RoleMaster",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "88263aea-27f7-4456-a289-cbf150180c6d", null, "HR Admin", "HR ADMIN" },
                    { "eb8bd01e-c82e-4257-8397-db292c923037", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "UserMaster",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "908f2260-f645-4b24-a928-39401bb99200", 0, "bca4d59a-cd56-4c22-9985-ce4f7af8c776", "info@cyberkemet.com", true, "Cyber", "Kemet", false, null, "INFO@CYBERKEMET.COM", "CYBER-KEMET", "AQAAAAIAAYagAAAAEMAFmjmJE67FrjEoveVRISdgjEIqb9teRfdZkCev34r4L5TUKpDchMbQzr0GZ3EPJw==", "01111257052", true, "51b9f92f-b672-49a7-842a-8223f19858a7", false, "cyber-kemet" });

            migrationBuilder.InsertData(
                table: "UserRoleMaster",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "88263aea-27f7-4456-a289-cbf150180c6d", "908f2260-f645-4b24-a928-39401bb99200" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleMaster",
                keyColumn: "Id",
                keyValue: "eb8bd01e-c82e-4257-8397-db292c923037");

            migrationBuilder.DeleteData(
                table: "UserRoleMaster",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "88263aea-27f7-4456-a289-cbf150180c6d", "908f2260-f645-4b24-a928-39401bb99200" });

            migrationBuilder.DeleteData(
                table: "RoleMaster",
                keyColumn: "Id",
                keyValue: "88263aea-27f7-4456-a289-cbf150180c6d");

            migrationBuilder.DeleteData(
                table: "UserMaster",
                keyColumn: "Id",
                keyValue: "908f2260-f645-4b24-a928-39401bb99200");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "RegionMaster",
                newName: "EnName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "CountryMaster",
                newName: "EnName");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "RolePageMaster",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "RegionMaster",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArName",
                table: "RegionMaster",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "PageMaster",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "ModuleMaster",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "MenuMaster",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "CountryMaster",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArName",
                table: "CountryMaster",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "UserMaster",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8fd7f2a2-32ae-4024-b745-dc8f4a70f8ab", 0, "d784db29-37e2-4445-8c88-5237b7e286d9", "info@cyberkemet.com", true, "Cyber", "Kemet", false, null, "INFO@CYBERKEMET.COM", "CYBER-KEMET", "AQAAAAIAAYagAAAAEBPWjC8a6M0uddHZKvbhCo0wvRO5tqIc9Njh8IRbZClhG0WBURLOEQdzshLCzh7wuA==", "01111257052", true, "8b0d9e5d-0634-4aa5-8b5f-623123bba1d9", false, "cyber-kemet" });
        }
    }
}
