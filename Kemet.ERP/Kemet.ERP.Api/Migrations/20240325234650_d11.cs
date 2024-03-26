using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kemet.ERP.Api.Migrations
{
    /// <inheritdoc />
    public partial class d11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RefreshToken",
                table: "RefreshToken");

            migrationBuilder.DeleteData(
                table: "UserMaster",
                keyColumn: "Id",
                keyValue: "d70d2362-ee2e-415c-abd4-61c995e1b41f");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "RefreshToken",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefreshToken",
                table: "RefreshToken",
                column: "Id");

            migrationBuilder.InsertData(
                table: "UserMaster",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1a2bdfec-6639-4e2c-93ee-301b796e1a3d", 0, "e71b66a1-3998-4fa0-96b6-55c8c1c48253", "info@cyberkemet.com", true, "Cyber", "Kemet", false, null, "INFO@CYBERKEMET.COM", "CYBER-KEMET", "AQAAAAIAAYagAAAAEEg2r41HRZtx77sD0vxH53uQm15+XGpQwdr0ZxmFGUBfybceyMNIYTV0Q/4by8XJSw==", "01111257052", true, "f7d2c894-ac9e-4b52-9422-4cfe9a982df6", false, "cyber-kemet" });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_AppUserId",
                table: "RefreshToken",
                column: "AppUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RefreshToken",
                table: "RefreshToken");

            migrationBuilder.DropIndex(
                name: "IX_RefreshToken_AppUserId",
                table: "RefreshToken");

            migrationBuilder.DeleteData(
                table: "UserMaster",
                keyColumn: "Id",
                keyValue: "1a2bdfec-6639-4e2c-93ee-301b796e1a3d");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "RefreshToken",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefreshToken",
                table: "RefreshToken",
                columns: new[] { "AppUserId", "Id" });

            migrationBuilder.InsertData(
                table: "UserMaster",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d70d2362-ee2e-415c-abd4-61c995e1b41f", 0, "61fe779a-564e-4c02-ad23-835192d9141c", "info@cyberkemet.com", true, "Cyber", "Kemet", false, null, "INFO@CYBERKEMET.COM", "CYBER-KEMET", "AQAAAAIAAYagAAAAED9qeLpbY1gtp6PRgq5aDuwFQxmq5QLRRCNb0GYBSzLbpPtf0Wqdhci7uYNns6rdLg==", "01111257052", true, "e6954a54-9a10-4b26-81f6-8fdf1531956a", false, "cyber-kemet" });
        }
    }
}
