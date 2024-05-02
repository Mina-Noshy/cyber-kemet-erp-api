using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kemet.ERP.Api.Migrations
{
    /// <inheritdoc />
    public partial class db435 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegionMaster_CountryMaster_CountryId",
                table: "RegionMaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegionMaster",
                table: "RegionMaster");

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

            migrationBuilder.RenameTable(
                name: "RegionMaster",
                newName: "CityMaster");

            migrationBuilder.RenameIndex(
                name: "IX_RegionMaster_CountryId",
                table: "CityMaster",
                newName: "IX_CityMaster_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CityMaster",
                table: "CityMaster",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BankMaster",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoutingNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Branch = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SwiftCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BranchMaster",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaxNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manager = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Established = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployeeCount = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyMaster",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Industry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaxNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CEO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Founded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployeeCount = table.Column<int>(type: "int", nullable: true),
                    Headquarters = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IndustryType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyMaster",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentMaster",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeBankAccounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    BankId = table.Column<long>(type: "bigint", nullable: false),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankAccountIBAN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeBankAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeContactInformations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    ContactType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeContactInformations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeEmergencyContacts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Relationship = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeEmergencyContacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeMaster",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: false),
                    JobTitleId = table.Column<long>(type: "bigint", nullable: false),
                    ManagerId = table.Column<long>(type: "bigint", nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfHire = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApartmentSuite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePersonalInformations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SocialSecurityNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dependents = table.Column<int>(type: "int", nullable: false),
                    Ethnicity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabilities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguagesSpoken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePersonalInformations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTaxProfiles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxableIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTaxProfiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmploymentHistories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    EmployerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Responsibilities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReasonForLeaving = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmploymentStatuses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    StatusId = table.Column<long>(type: "bigint", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReasonForChange = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmploymentStatusMaster",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentStatusMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmploymentTypeMaster",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentTypeMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmploymentTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GenderMaster",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenderMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobTitleMaster",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalaryRange = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Qualifications = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTitleMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaritalStatusMaster",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaritalStatusMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NationalityMaster",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NationalityMaster", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CurrencyMaster",
                columns: new[] { "Id", "Code", "Country", "ExchangeRate", "IsActive", "IsDeleted", "Name", "Symbol" },
                values: new object[,]
                {
                    { 1L, "EGP", "Egypt", 1m, true, false, "Egyptian Pound", "£" },
                    { 2L, "SAR", "Saudi Arabia", 1m, true, false, "Saudi Riyal", "ر.س" },
                    { 3L, "AED", "United Arab Emirates", 1m, true, false, "United Arab Emirates Dirham", "د.إ" },
                    { 4L, "QAR", "Qatar", 1m, true, false, "Qatari Riyal", "ر.ق" },
                    { 5L, "BHD", "Bahrain", 1m, true, false, "Bahraini Dinar", "د.ب" },
                    { 6L, "OMR", "Oman", 1m, true, false, "Omani Rial", "ر.ع" },
                    { 7L, "KWD", "Kuwait", 1m, true, false, "Kuwaiti Dinar", "د.ك" },
                    { 8L, "BGN", "Bulgaria", 1m, true, false, "Bulgarian Lev", "лв" },
                    { 9L, "HRK", "Croatia", 1m, true, false, "Croatian Kuna", "kn" },
                    { 10L, "CZK", "Czech Republic", 1m, true, false, "Czech Koruna", "Kč" },
                    { 11L, "DKK", "Denmark", 1m, true, false, "Danish Krone", "kr" },
                    { 12L, "EUR", "European Union", 1m, true, false, "Euro", "€" },
                    { 13L, "GBP", "United Kingdom", 1m, true, false, "Pound Sterling", "£" },
                    { 14L, "HUF", "Hungary", 1m, true, false, "Hungarian Forint", "Ft" },
                    { 15L, "ISK", "Iceland", 1m, true, false, "Icelandic Króna", "kr" },
                    { 16L, "JPY", "Japan", 1m, true, false, "Japanese Yen", "¥" },
                    { 17L, "NOK", "Norway", 1m, true, false, "Norwegian Krone", "kr" },
                    { 18L, "PLN", "Poland", 1m, true, false, "Polish Złoty", "zł" },
                    { 19L, "RON", "Romania", 1m, true, false, "Romanian Leu", "lei" },
                    { 20L, "SEK", "Sweden", 1m, true, false, "Swedish Krona", "kr" },
                    { 21L, "USD", "United States", 1m, true, false, "United States Dollar", "$" }
                });

            migrationBuilder.InsertData(
                table: "GenderMaster",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1L, false, "Male" },
                    { 2L, false, "Female" },
                    { 3L, false, "Other" }
                });

            migrationBuilder.InsertData(
                table: "MaritalStatusMaster",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1L, false, "Single" },
                    { 2L, false, "Engaged" },
                    { 3L, false, "Married" },
                    { 4L, false, "Divorced" },
                    { 5L, false, "Widowed" }
                });

            migrationBuilder.InsertData(
                table: "NationalityMaster",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1L, false, "Egyptian" },
                    { 2L, false, "Iranian" },
                    { 3L, false, "Turkish" },
                    { 4L, false, "Lebanese" },
                    { 5L, false, "Syrian" },
                    { 6L, false, "Jordanian" },
                    { 7L, false, "Palestinian" },
                    { 8L, false, "Iraqi" },
                    { 9L, false, "Saudi" },
                    { 10L, false, "Yemeni" },
                    { 11L, false, "Emirati" },
                    { 12L, false, "Qatari" },
                    { 13L, false, "Kuwaiti" },
                    { 14L, false, "Bahraini" },
                    { 15L, false, "Omani" },
                    { 16L, false, "Moroccan" },
                    { 17L, false, "Tunisian" },
                    { 18L, false, "Algerian" },
                    { 19L, false, "Libyan" }
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_CityMaster_CountryMaster_CountryId",
                table: "CityMaster",
                column: "CountryId",
                principalTable: "CountryMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CityMaster_CountryMaster_CountryId",
                table: "CityMaster");

            migrationBuilder.DropTable(
                name: "BankMaster");

            migrationBuilder.DropTable(
                name: "BranchMaster");

            migrationBuilder.DropTable(
                name: "CompanyMaster");

            migrationBuilder.DropTable(
                name: "CurrencyMaster");

            migrationBuilder.DropTable(
                name: "DepartmentMaster");

            migrationBuilder.DropTable(
                name: "EmployeeBankAccounts");

            migrationBuilder.DropTable(
                name: "EmployeeContactInformations");

            migrationBuilder.DropTable(
                name: "EmployeeEmergencyContacts");

            migrationBuilder.DropTable(
                name: "EmployeeMaster");

            migrationBuilder.DropTable(
                name: "EmployeePersonalInformations");

            migrationBuilder.DropTable(
                name: "EmployeeTaxProfiles");

            migrationBuilder.DropTable(
                name: "EmploymentHistories");

            migrationBuilder.DropTable(
                name: "EmploymentStatuses");

            migrationBuilder.DropTable(
                name: "EmploymentStatusMaster");

            migrationBuilder.DropTable(
                name: "EmploymentTypeMaster");

            migrationBuilder.DropTable(
                name: "EmploymentTypes");

            migrationBuilder.DropTable(
                name: "GenderMaster");

            migrationBuilder.DropTable(
                name: "JobTitleMaster");

            migrationBuilder.DropTable(
                name: "MaritalStatusMaster");

            migrationBuilder.DropTable(
                name: "NationalityMaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CityMaster",
                table: "CityMaster");

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

            migrationBuilder.RenameTable(
                name: "CityMaster",
                newName: "RegionMaster");

            migrationBuilder.RenameIndex(
                name: "IX_CityMaster_CountryId",
                table: "RegionMaster",
                newName: "IX_RegionMaster_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegionMaster",
                table: "RegionMaster",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_RegionMaster_CountryMaster_CountryId",
                table: "RegionMaster",
                column: "CountryId",
                principalTable: "CountryMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
