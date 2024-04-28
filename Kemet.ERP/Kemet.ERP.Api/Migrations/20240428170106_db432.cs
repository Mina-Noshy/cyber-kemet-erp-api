using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kemet.ERP.Api.Migrations
{
    /// <inheritdoc />
    public partial class db432 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "PhoneCode",
                table: "CountryMaster",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "RoleMaster",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f9cefeee-5e28-4671-a0ea-79455c1c2ac3", null, "HR Admin", "HR ADMIN" },
                    { "fc2811d5-967e-465f-9889-caf1bb89aff5", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "UserMaster",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7d595ffd-0f5a-40c0-900a-0789b1b628e7", 0, "3118fcac-3226-489b-a965-46ab5e94e449", "info@cyberkemet.com", true, "Cyber", "Kemet", false, null, "INFO@CYBERKEMET.COM", "CYBER-KEMET", "AQAAAAIAAYagAAAAEAe5EmnWEQsT7PcOgzQhfM4NAe/KU2h08gri70gC3ZUG47na4J61sMVAfjV2eNuKSA==", "01111257052", true, "e1ba7a25-7046-4734-b4cb-113f4f0a26d3", false, "cyber-kemet" });

            migrationBuilder.InsertData(
                table: "UserRoleMaster",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f9cefeee-5e28-4671-a0ea-79455c1c2ac3", "7d595ffd-0f5a-40c0-900a-0789b1b628e7" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleMaster",
                keyColumn: "Id",
                keyValue: "fc2811d5-967e-465f-9889-caf1bb89aff5");

            migrationBuilder.DeleteData(
                table: "UserRoleMaster",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f9cefeee-5e28-4671-a0ea-79455c1c2ac3", "7d595ffd-0f5a-40c0-900a-0789b1b628e7" });

            migrationBuilder.DeleteData(
                table: "RoleMaster",
                keyColumn: "Id",
                keyValue: "f9cefeee-5e28-4671-a0ea-79455c1c2ac3");

            migrationBuilder.DeleteData(
                table: "UserMaster",
                keyColumn: "Id",
                keyValue: "7d595ffd-0f5a-40c0-900a-0789b1b628e7");

            migrationBuilder.AlterColumn<int>(
                name: "PhoneCode",
                table: "CountryMaster",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
    }
}
