using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kemet.ERP.Api.Migrations
{
    /// <inheritdoc />
    public partial class db437 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleMaster",
                keyColumn: "Id",
                keyValue: "b3c06e9e-f8f2-4f9a-8d53-6fec1b5f09a3");

            migrationBuilder.DeleteData(
                table: "UserRoleMaster",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e2b7287d-e4b1-42ac-beb1-05b584ded9e9", "170de998-db71-4d34-8aba-0ee677919e7b" });

            migrationBuilder.DeleteData(
                table: "RoleMaster",
                keyColumn: "Id",
                keyValue: "e2b7287d-e4b1-42ac-beb1-05b584ded9e9");

            migrationBuilder.DeleteData(
                table: "UserMaster",
                keyColumn: "Id",
                keyValue: "170de998-db71-4d34-8aba-0ee677919e7b");

            migrationBuilder.RenameColumn(
                name: "EnName",
                table: "PageMaster",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ArName",
                table: "PageMaster",
                newName: "Label");

            migrationBuilder.RenameColumn(
                name: "EnName",
                table: "ModuleMaster",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ArName",
                table: "ModuleMaster",
                newName: "Label");

            migrationBuilder.RenameColumn(
                name: "EnName",
                table: "MenuMaster",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ArName",
                table: "MenuMaster",
                newName: "Label");

            migrationBuilder.AddColumn<long>(
                name: "EmployeeId",
                table: "UserMaster",
                type: "bigint",
                nullable: true);

            migrationBuilder.InsertData(
                table: "RoleMaster",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5ba3f06e-fc6d-4717-9918-e6f9edd44f2c", null, "HR Admin", "HR ADMIN" },
                    { "94cfaa3f-86f6-46df-b151-6245a130cda1", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "UserMaster",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeId", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e171b23b-e9f6-4e5e-9077-9f3c43edbd35", 0, "26fcd06b-3d6d-41ec-acac-dfb0f329675f", "info@cyberkemet.com", true, null, "Cyber", "Kemet", false, null, "INFO@CYBERKEMET.COM", "CYBER-KEMET", "AQAAAAIAAYagAAAAEBSNJ5xzYqHfTXxStqKPiAQUTMIwrEGHc8AQSvBA6iHLLSOAzA7lo9RPeS7rnDzdfQ==", "01111257052", true, "cd27208e-1cd8-4850-9890-1a19ca44958f", false, "cyber-kemet" });

            migrationBuilder.InsertData(
                table: "UserRoleMaster",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5ba3f06e-fc6d-4717-9918-e6f9edd44f2c", "e171b23b-e9f6-4e5e-9077-9f3c43edbd35" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleMaster",
                keyColumn: "Id",
                keyValue: "94cfaa3f-86f6-46df-b151-6245a130cda1");

            migrationBuilder.DeleteData(
                table: "UserRoleMaster",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5ba3f06e-fc6d-4717-9918-e6f9edd44f2c", "e171b23b-e9f6-4e5e-9077-9f3c43edbd35" });

            migrationBuilder.DeleteData(
                table: "RoleMaster",
                keyColumn: "Id",
                keyValue: "5ba3f06e-fc6d-4717-9918-e6f9edd44f2c");

            migrationBuilder.DeleteData(
                table: "UserMaster",
                keyColumn: "Id",
                keyValue: "e171b23b-e9f6-4e5e-9077-9f3c43edbd35");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "UserMaster");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "PageMaster",
                newName: "EnName");

            migrationBuilder.RenameColumn(
                name: "Label",
                table: "PageMaster",
                newName: "ArName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ModuleMaster",
                newName: "EnName");

            migrationBuilder.RenameColumn(
                name: "Label",
                table: "ModuleMaster",
                newName: "ArName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "MenuMaster",
                newName: "EnName");

            migrationBuilder.RenameColumn(
                name: "Label",
                table: "MenuMaster",
                newName: "ArName");

            migrationBuilder.InsertData(
                table: "RoleMaster",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b3c06e9e-f8f2-4f9a-8d53-6fec1b5f09a3", null, "User", "USER" },
                    { "e2b7287d-e4b1-42ac-beb1-05b584ded9e9", null, "HR Admin", "HR ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "UserMaster",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "170de998-db71-4d34-8aba-0ee677919e7b", 0, "94039093-fba0-44db-abee-09464d840498", "info@cyberkemet.com", true, "Cyber", "Kemet", false, null, "INFO@CYBERKEMET.COM", "CYBER-KEMET", "AQAAAAIAAYagAAAAEIfEi6ngxPvYPS1IA7LLP7Z7bbf8XB/AKz4+y3HoKvKvjMdwJ6k5yQ5X/53X50OCMQ==", "01111257052", true, "6f35e644-f32b-4df6-bbcd-97bdfec7a3bd", false, "cyber-kemet" });

            migrationBuilder.InsertData(
                table: "UserRoleMaster",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e2b7287d-e4b1-42ac-beb1-05b584ded9e9", "170de998-db71-4d34-8aba-0ee677919e7b" });
        }
    }
}
