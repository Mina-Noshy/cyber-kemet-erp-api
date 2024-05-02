using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kemet.ERP.Api.Migrations
{
    /// <inheritdoc />
    public partial class db436 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleMaster",
                keyColumn: "Id",
                keyValue: "ea6a2d88-7385-4d1a-8be3-541fea496614");

            migrationBuilder.DeleteData(
                table: "UserRoleMaster",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5b5cce6c-eac5-4b83-947d-c5662a7ea016", "932ac849-085b-4ad9-b535-b558068a4999" });

            migrationBuilder.DeleteData(
                table: "RoleMaster",
                keyColumn: "Id",
                keyValue: "5b5cce6c-eac5-4b83-947d-c5662a7ea016");

            migrationBuilder.DeleteData(
                table: "UserMaster",
                keyColumn: "Id",
                keyValue: "932ac849-085b-4ad9-b535-b558068a4999");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "BranchMaster",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "BranchMaster",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "EmployeeDependents",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Relationship = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCoveredByInsurance = table.Column<bool>(type: "bit", nullable: false),
                    IsStudent = table.Column<bool>(type: "bit", nullable: false),
                    SchoolName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDependents", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_BranchMaster_CompanyId",
                table: "BranchMaster",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_BranchMaster_CompanyMaster_CompanyId",
                table: "BranchMaster",
                column: "CompanyId",
                principalTable: "CompanyMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BranchMaster_CompanyMaster_CompanyId",
                table: "BranchMaster");

            migrationBuilder.DropTable(
                name: "EmployeeDependents");

            migrationBuilder.DropIndex(
                name: "IX_BranchMaster_CompanyId",
                table: "BranchMaster");

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

            migrationBuilder.DropColumn(
                name: "City",
                table: "BranchMaster");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "BranchMaster");

            migrationBuilder.InsertData(
                table: "RoleMaster",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5b5cce6c-eac5-4b83-947d-c5662a7ea016", null, "HR Admin", "HR ADMIN" },
                    { "ea6a2d88-7385-4d1a-8be3-541fea496614", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "UserMaster",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "932ac849-085b-4ad9-b535-b558068a4999", 0, "e71c1225-2a8b-45d8-933d-1da0c05935b0", "info@cyberkemet.com", true, "Cyber", "Kemet", false, null, "INFO@CYBERKEMET.COM", "CYBER-KEMET", "AQAAAAIAAYagAAAAEDXChVmLg3scDyWHHxFIYA990FEP9oJwGHbV98zp/6b0Gpga612rHdMvmuIOFrG5NA==", "01111257052", true, "e628cc93-fe96-44e2-a1ec-f2c8b47e571e", false, "cyber-kemet" });

            migrationBuilder.InsertData(
                table: "UserRoleMaster",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5b5cce6c-eac5-4b83-947d-c5662a7ea016", "932ac849-085b-4ad9-b535-b558068a4999" });
        }
    }
}
