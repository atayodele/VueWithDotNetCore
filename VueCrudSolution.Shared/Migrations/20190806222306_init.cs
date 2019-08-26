using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VueCrudSolution.Shared.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.UniqueConstraint("AK_UserLogins_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserAddress",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy_Id = table.Column<Guid>(nullable: false),
                    ModifiedBy_Id = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Region_Id = table.Column<Guid>(nullable: true),
                    Country_Id = table.Column<Guid>(nullable: true),
                    City_Id = table.Column<Guid>(nullable: true),
                    Login_Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    LastLoginDate = table.Column<DateTime>(nullable: true),
                    Activated = table.Column<bool>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Address_Id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserAddress_Address_Id",
                        column: x => x.Address_Id,
                        principalTable: "UserAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy_Id = table.Column<Guid>(nullable: false),
                    ModifiedBy_Id = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NameAscii = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    GeonameId = table.Column<int>(nullable: false),
                    AlternateNames = table.Column<string>(nullable: true),
                    Code2 = table.Column<string>(nullable: true),
                    Code3 = table.Column<string>(nullable: true),
                    Continent = table.Column<string>(nullable: true),
                    Tld = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Currency = table.Column<string>(nullable: true),
                    CurrencyCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Country_Users_CreatedBy_Id",
                        column: x => x.CreatedBy_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Country_Users_ModifiedBy_Id",
                        column: x => x.ModifiedBy_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Idea",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy_Id = table.Column<Guid>(nullable: false),
                    ModifiedBy_Id = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
                    Description = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    IsRead = table.Column<bool>(nullable: false),
                    FilePath = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Login_Id = table.Column<Guid>(nullable: false),
                    ApplicationIdentityUserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idea", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Idea_Users_ApplicationIdentityUserId",
                        column: x => x.ApplicationIdentityUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Idea_Users_CreatedBy_Id",
                        column: x => x.CreatedBy_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Idea_Users_Login_Id",
                        column: x => x.Login_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Idea_Users_ModifiedBy_Id",
                        column: x => x.ModifiedBy_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy_Id = table.Column<Guid>(nullable: false),
                    ModifiedBy_Id = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Url = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    IsMain = table.Column<bool>(nullable: false),
                    Login_Id = table.Column<Guid>(nullable: false),
                    ApplicationIdentityUserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photo_Users_ApplicationIdentityUserId",
                        column: x => x.ApplicationIdentityUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Photo_Users_CreatedBy_Id",
                        column: x => x.CreatedBy_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Photo_Users_Login_Id",
                        column: x => x.Login_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Photo_Users_ModifiedBy_Id",
                        column: x => x.ModifiedBy_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy_Id = table.Column<Guid>(nullable: false),
                    ModifiedBy_Id = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NameAscii = table.Column<string>(nullable: true),
                    GeonameId = table.Column<int>(nullable: false),
                    AlternativeNames = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    GeonameCode = table.Column<string>(nullable: true),
                    Country_Id = table.Column<Guid>(nullable: false),
                    Slug = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Region_Country_Country_Id",
                        column: x => x.Country_Id,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Region_Users_CreatedBy_Id",
                        column: x => x.CreatedBy_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Region_Users_ModifiedBy_Id",
                        column: x => x.ModifiedBy_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy_Id = table.Column<Guid>(nullable: false),
                    ModifiedBy_Id = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NameAscii = table.Column<string>(nullable: true),
                    GeonameId = table.Column<int>(nullable: false),
                    AlternativeNames = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    GeonameCode = table.Column<string>(nullable: true),
                    Region_Id = table.Column<Guid>(nullable: false),
                    Slug = table.Column<string>(nullable: true),
                    Latitude = table.Column<decimal>(nullable: false),
                    Longitude = table.Column<decimal>(nullable: false),
                    Population = table.Column<string>(nullable: true),
                    FeatureCode = table.Column<string>(nullable: true),
                    SearchNames = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Users_CreatedBy_Id",
                        column: x => x.CreatedBy_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_City_Users_ModifiedBy_Id",
                        column: x => x.ModifiedBy_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_City_Region_Region_Id",
                        column: x => x.Region_Id,
                        principalTable: "Region",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("a1b6b6b0-0825-4975-a93d-df3dc86f8cc7"), "cc4d7a72c22a4bc7940a212b64927ccd", "SYS_ADMIN", "SYS_ADMIN" },
                    { new Guid("0718ddef-4067-4f29-aaa1-98c1548c1807"), "78fbd0d0eb4043ef96e4ca6eecf254f4", "SUPER_ADMIN", "SUPER_ADMIN" },
                    { new Guid("5869ab93-81da-419b-b5ad-41a7bc82cae8"), "d5800887f58d4db5a1217858e7e3eefd", "ADMIN", "ADMIN" },
                    { new Guid("e4410972-f20a-4d07-afdb-c61550e3dd44"), "4f228f4898424b36831080843accecaf", "POWER_USER", "POWER_USER" },
                    { new Guid("c6072997-237f-4ec2-a2b9-8c4084553d76"), "d42ca34192db447f903ad3fefcee8d88", "MANAGER", "MANAGER" },
                    { new Guid("d5bc65ff-6bbf-4e95-a00c-03485e5952cf"), "66278db6850a4dc6beb5356d1067695c", "USERS", "USERS" }
                });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 14, "BU_03", "403", new Guid("3ed1c86f-9a0b-4289-9a2c-c3736f142fa0") },
                    { 13, "BU_02", "402", new Guid("3ed1c86f-9a0b-4289-9a2c-c3736f142fa0") },
                    { 12, "BU_01", "401", new Guid("3ed1c86f-9a0b-4289-9a2c-c3736f142fa0") },
                    { 11, "PU_06", "306", new Guid("193a9488-ad75-41d6-a3e0-db3f10b6468f") },
                    { 10, "PU_05", "305", new Guid("193a9488-ad75-41d6-a3e0-db3f10b6468f") },
                    { 9, "PU_04", "304", new Guid("193a9488-ad75-41d6-a3e0-db3f10b6468f") },
                    { 8, "PU_03", "303", new Guid("193a9488-ad75-41d6-a3e0-db3f10b6468f") },
                    { 7, "PU_02", "302", new Guid("193a9488-ad75-41d6-a3e0-db3f10b6468f") },
                    { 6, "PU_01", "301", new Guid("193a9488-ad75-41d6-a3e0-db3f10b6468f") },
                    { 5, "AU_05", "205", new Guid("129712e3-9214-4dd3-9c03-cfc4eb9ba979") },
                    { 4, "AU_04", "204", new Guid("129712e3-9214-4dd3-9c03-cfc4eb9ba979") },
                    { 3, "AU_03", "203", new Guid("129712e3-9214-4dd3-9c03-cfc4eb9ba979") },
                    { 2, "AU_02", "202", new Guid("129712e3-9214-4dd3-9c03-cfc4eb9ba979") },
                    { 1, "AU_01", "201", new Guid("129712e3-9214-4dd3-9c03-cfc4eb9ba979") }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new Guid("a1b6b6b0-0825-4975-a93d-df3dc86f8cc7") },
                    { new Guid("3fb897c8-c25d-4328-9813-cb1544369fba"), new Guid("0718ddef-4067-4f29-aaa1-98c1548c1807") },
                    { new Guid("129712e3-9214-4dd3-9c03-cfc4eb9ba979"), new Guid("5869ab93-81da-419b-b5ad-41a7bc82cae8") },
                    { new Guid("193a9488-ad75-41d6-a3e0-db3f10b6468f"), new Guid("e4410972-f20a-4d07-afdb-c61550e3dd44") },
                    { new Guid("3ed1c86f-9a0b-4289-9a2c-c3736f142fa0"), new Guid("c6072997-237f-4ec2-a2b9-8c4084553d76") },
                    { new Guid("24de2be9-2e75-44c3-a1da-0d6109e40fbb"), new Guid("d5bc65ff-6bbf-4e95-a00c-03485e5952cf") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Activated", "Address_Id", "ConcurrencyStamp", "CreatedOnUtc", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "FullName", "Gender", "LastLoginDate", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("3ed1c86f-9a0b-4289-9a2c-c3736f142fa0"), 0, true, null, "f75ad400-2fbb-484f-a034-8fce713c425e", new DateTime(2019, 8, 6, 23, 23, 5, 702, DateTimeKind.Local).AddTicks(4470), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "manager@gmail.com", true, "Ayeni", "Ayeni Ayodele", null, new DateTime(2019, 8, 6, 23, 23, 5, 702, DateTimeKind.Local).AddTicks(4475), "Ayodele", false, null, "MANAGER@GMAIL.COM", "MANAGER@GMAIL.COM", "AQAAAAEAACcQAAAAEMtS/Dkt7x/EN1IOE3Ngv65DUfLXit4qTvk4JwkOtBOgzPaE/CYRHx/9EDq9QWeuHw==", "07032369246", true, "bd5db7e5-b870-48cf-839b-5862d0b86614", false, "manager@gmail.com" },
                    { new Guid("193a9488-ad75-41d6-a3e0-db3f10b6468f"), 0, true, null, "bb878f8d-8d81-4002-b59b-ad6fe6367729", new DateTime(2019, 8, 6, 23, 23, 5, 693, DateTimeKind.Local).AddTicks(6586), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "poweruser@gmail.com", true, "Ayeni", "Ayeni Ayodele", null, new DateTime(2019, 8, 6, 23, 23, 5, 693, DateTimeKind.Local).AddTicks(6596), "Ayodele", false, null, "POWERUSER@GMAIL.COM", "POWERUSER@GMAIL.COM", "AQAAAAEAACcQAAAAEGDwI9/+xTprn3PSFMeiogAWvin9ftxCmn/aVRNKEJnf2EICMfDi0oF/O1Vwihxvtg==", "07032369246", true, "9c41c8cc-b489-40c6-bbcf-12edee681919", false, "poweruser@gmail.com" },
                    { new Guid("129712e3-9214-4dd3-9c03-cfc4eb9ba979"), 0, true, null, "55712cbb-4cf9-4c7e-bc32-64407e968a10", new DateTime(2019, 8, 6, 23, 23, 5, 684, DateTimeKind.Local).AddTicks(8431), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@gmail.com", true, "Ayeni", "Ayeni Ayodele", null, new DateTime(2019, 8, 6, 23, 23, 5, 684, DateTimeKind.Local).AddTicks(8436), "Ayodele", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEPnZMKsqqSoBrn4ZoYgd7/X75/Y4Ez0RWnwyS3/61OcJWpIe5ouxogUCsvhE4ONTrQ==", "07032369246", true, "953d3fd1-99e3-4fe7-a20d-3598baa96099", false, "admin@gmail.com" },
                    { new Guid("3fb897c8-c25d-4328-9813-cb1544369fba"), 0, true, null, "a77de2a6-d96a-41ec-ba58-4e3270225e82", new DateTime(2019, 8, 6, 23, 23, 5, 675, DateTimeKind.Local).AddTicks(9957), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "superadmin@gmail.com", true, "Meyo", "Meyo Solutions", null, new DateTime(2019, 8, 6, 23, 23, 5, 675, DateTimeKind.Local).AddTicks(9967), "Solutions", false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEPxJVoRIpIoUWuIqoqwChA9Bi98B25QuERmjhDnc6/itGnhXO+hlVi0UCVEwhssOUw==", "07032369246", true, "016020e3-5c50-40b4-9e66-bba56c9f5bf2", false, "superadmin@gmail.com" },
                    { new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), 0, false, null, "df6da8e2-8b0a-4582-ae06-9cbd0a5e01a0", new DateTime(2019, 8, 6, 23, 23, 5, 662, DateTimeKind.Local).AddTicks(5397), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "system@gmail.com", false, "Meyo", "Meyo Solutions", null, new DateTime(2019, 8, 6, 23, 23, 5, 662, DateTimeKind.Local).AddTicks(8559), "Solutions", false, null, "SYSTEM@GMAIL.COM", "SYSTEM@GMAIL.COM", "AQAAAAEAACcQAAAAEKxu+3pcJiBrz4pVVxwSt3JPMNVk0lILieaMCLL12T84DXgeRoY+s7JiJsg7AnaBjA==", "07032369246", false, "99ae0c45-d682-4542-9ba7-1281e471916b", false, "system@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "AlternateNames", "Code2", "Code3", "Continent", "CreatedBy_Id", "CreatedOn", "Currency", "CurrencyCode", "GeonameId", "IsDeleted", "ModifiedBy_Id", "ModifiedOn", "Name", "NameAscii", "Phone", "Slug", "Tld" },
                values: new object[] { new Guid("1a0f0f6c-e60a-467a-9fb6-1f6f2e9a8413"), "", "NG", "NGA", "AF", new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 806, DateTimeKind.Utc).AddTicks(2081), null, null, 2328926, false, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 806, DateTimeKind.Utc).AddTicks(2081), "Nigeria", "Nigeria", "234", "nigeria", "ng" });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "AlternativeNames", "Country_Id", "CreatedBy_Id", "CreatedOn", "DisplayName", "GeonameCode", "GeonameId", "IsDeleted", "ModifiedBy_Id", "ModifiedOn", "Name", "NameAscii", "Slug" },
                values: new object[,]
                {
                    { new Guid("25c42834-7c89-4fda-aef0-c27742378868"), null, new Guid("1a0f0f6c-e60a-467a-9fb6-1f6f2e9a8413"), new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 807, DateTimeKind.Utc).AddTicks(6535), "Sokoto, Nigeria", "51", 2322907, false, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), null, "Sokoto", "Sokoto", "sokoto" },
                    { new Guid("04c075c9-90f3-4715-b35f-fd28f5861146"), null, new Guid("1a0f0f6c-e60a-467a-9fb6-1f6f2e9a8413"), new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4286), "Abia, Nigeria", "45", 2565340, false, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), null, "Abia", "Abia", "abia" },
                    { new Guid("cb946de4-da80-4ccb-9b3d-89eec72c51f0"), null, new Guid("1a0f0f6c-e60a-467a-9fb6-1f6f2e9a8413"), new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4353), "Delta, Nigeria", "36", 2565341, false, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), null, "Delta", "Delta", "delta" },
                    { new Guid("297154ee-9790-480d-bbd6-e34c82c17078"), null, new Guid("1a0f0f6c-e60a-467a-9fb6-1f6f2e9a8413"), new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4404), "Adamawa, Nigeria", "35", 2565342, false, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), null, "Adamawa", "Adamawa", "adamawa" },
                    { new Guid("71946e96-1943-4499-a92a-745cde65b50b"), null, new Guid("1a0f0f6c-e60a-467a-9fb6-1f6f2e9a8413"), new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4440), "Edo, Nigeria", "37", 2565343, false, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), null, "Edo", "Edo", "edo" },
                    { new Guid("efe20337-7cfc-4058-aa4a-e3e1b75d0d3a"), null, new Guid("1a0f0f6c-e60a-467a-9fb6-1f6f2e9a8413"), new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4548), "Enugu, Nigeria", "47", 2565344, false, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), null, "Enugu", "Enugu", "enugu" },
                    { new Guid("55503554-9c1b-43b7-bbc2-32cc627429ab"), null, new Guid("1a0f0f6c-e60a-467a-9fb6-1f6f2e9a8413"), new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4584), "Jigawa, Nigeria", "39", 2565345, false, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), null, "Jigawa", "Jigawa", "jigawa" },
                    { new Guid("69c477cf-4675-464d-82e6-b24ce3426e63"), null, new Guid("1a0f0f6c-e60a-467a-9fb6-1f6f2e9a8413"), new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4625), "Bayelsa, Nigeria", "52", 2595344, false, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), null, "Bayelsa", "Bayelsa", "bayelsa" },
                    { new Guid("1f8c8e8a-9cfd-45cf-a6a6-23c84c3266b7"), null, new Guid("1a0f0f6c-e60a-467a-9fb6-1f6f2e9a8413"), new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4636), "Ebonyi, Nigeria", "53", 2595345, false, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), null, "Ebonyi", "Ebonyi", "ebonyi" },
                    { new Guid("67cdd3df-6dd2-452c-989d-2d55d3985fb0"), null, new Guid("1a0f0f6c-e60a-467a-9fb6-1f6f2e9a8413"), new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4672), "Ekiti, Nigeria", "54", 2595346, false, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), null, "Ekiti", "Ekiti", "ekiti" },
                    { new Guid("cc1730f9-2764-4533-aa07-2917142784b6"), null, new Guid("1a0f0f6c-e60a-467a-9fb6-1f6f2e9a8413"), new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4764), "Gombe, Nigeria", "55", 2595347, false, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), null, "Gombe", "Gombe", "gombe" },
                    { new Guid("beb2f024-3c49-403e-a263-6b79cdceb62d"), null, new Guid("1a0f0f6c-e60a-467a-9fb6-1f6f2e9a8413"), new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4816), "Nassarawa, Nigeria", "56", 2595348, false, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), null, "Nassarawa", "Nassarawa", "nassarawa" },
                    { new Guid("4c745d27-df1d-40c0-b531-aa6659e15f33"), null, new Guid("1a0f0f6c-e60a-467a-9fb6-1f6f2e9a8413"), new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4852), "Zamfara, Nigeria", "57", 2595349, false, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), null, "Zamfara", "Zamfara", "zamfara" },
                    { new Guid("c84f31d9-b3c7-45a1-bd77-f5230193a318"), null, new Guid("1a0f0f6c-e60a-467a-9fb6-1f6f2e9a8413"), new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4918), "Kebbi, Nigeria", "40", 2597363, false, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), null, "Kebbi", "Kebbi", "kebbi" },
                    { new Guid("d34d4180-6438-4982-84c5-7fbf953234b7"), null, new Guid("1a0f0f6c-e60a-467a-9fb6-1f6f2e9a8413"), new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4954), "Kogi, Nigeria", "41", 2597364, false, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), null, "Kogi", "Kogi", "kogi" },
                    { new Guid("5b95c24a-71e9-4e70-a3cc-99f87fcad7da"), null, new Guid("1a0f0f6c-e60a-467a-9fb6-1f6f2e9a8413"), new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5001), "Osun, Nigeria", "42", 2597365, false, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), null, "Osun", "Osun", "osun" },
                    { new Guid("3e578df6-0388-499b-b8e6-2d8b302e8c0a"), null, new Guid("1a0f0f6c-e60a-467a-9fb6-1f6f2e9a8413"), new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4271), "Abuja Federal Capital Territory, Nigeria", "11", 2352776, false, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), null, "Abuja Federal Capital Territory", "Abuja Federal Capital Territory", "abuja-federal-capital-territory" },
                    { new Guid("50c0c9cb-cfcb-4589-9bf6-115705c2e72f"), null, new Guid("1a0f0f6c-e60a-467a-9fb6-1f6f2e9a8413"), new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5145), "Taraba, Nigeria", "43", 2597366, false, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), null, "Taraba", "Taraba", "taraba" },
                    { new Guid("142fbdf9-fa82-4de4-a495-d1f37d39ff0b"), null, new Guid("1a0f0f6c-e60a-467a-9fb6-1f6f2e9a8413"), new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4240), "Akwa Ibom, Nigeria", "21", 2350813, false, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), null, "Akwa Ibom", "Akwa Ibom", "akwa-ibom" },
                    { new Guid("d4278b26-e02a-4bb1-ba84-131f2d318e29"), null, new Guid("1a0f0f6c-e60a-467a-9fb6-1f6f2e9a8413"), new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4106), "Bauchi, Nigeria", "46", 2347468, false, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), null, "Bauchi", "Bauchi", "bauchi" },
                    { new Guid("a7b2a7ad-4a36-48e1-afd1-21e9167e6b4c"), null, new Guid("1a0f0f6c-e60a-467a-9fb6-1f6f2e9a8413"), new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3284), "Rivers, Nigeria", "50", 2324433, false, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), null, "Rivers", "Rivers", "rivers" },
                    { new Guid("ed51291a-e5a1-4faf-a087-d8c3d5a8ec45"), null, new Guid("1a0f0f6c-e60a-467a-9fb6-1f6f2e9a8413"), new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3340), "Plateau, Nigeria", "49", 2324828, false, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), null, "Plateau", "Plateau", "plateau" },
                    { new Guid("8f99b569-a2c2-474f-9776-eadb40fe9012"), null, new Guid("1a0f0f6c-e60a-467a-9fb6-1f6f2e9a8413"), new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3361), "Oyo, Nigeria", "32", 2325190, false, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), null, "Oyo", "Oyo", "oyo" },
                    { new Guid("e0daf433-f8e5-4630-9ac5-4363cbd1d3c5"), null, new Guid("1a0f0f6c-e60a-467a-9fb6-1f6f2e9a8413"), new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3469), "Ondo, Nigeria", "48", 2326168, false, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), null, "Ondo", "Ondo", "ondo" },
                    { new Guid("4e3cb3b1-2bb1-4535-bf39-172520cdbc3f"), null, new Guid("1a0f0f6c-e60a-467a-9fb6-1f6f2e9a8413"), new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3505), "Ogun, Nigeria", "16", 2327546, false, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), null, "Ogun", "Ogun", "ogun" },
                    { new Guid("aecf4ca6-7558-40c2-bf35-f962032bf85e"), null, new Guid("1a0f0f6c-e60a-467a-9fb6-1f6f2e9a8413"), new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3561), "Niger, Nigeria", "31", 2328925, false, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), null, "Niger", "Niger", "niger" },
                    { new Guid("c5abe7ab-1d93-41b9-ad36-b1d195d0b88b"), null, new Guid("1a0f0f6c-e60a-467a-9fb6-1f6f2e9a8413"), new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3669), "Lagos, Nigeria", "05", 2332453, false, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), null, "Lagos", "Lagos", "lagos" },
                    { new Guid("9216cdb7-87a0-4485-90d7-dabbf68544b7"), null, new Guid("1a0f0f6c-e60a-467a-9fb6-1f6f2e9a8413"), new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3700), "Kwara, Nigeria", "30", 2332785, false, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), null, "Kwara", "Kwara", "kwara" },
                    { new Guid("014fd2f0-9a06-42cd-b119-43198725732d"), null, new Guid("1a0f0f6c-e60a-467a-9fb6-1f6f2e9a8413"), new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3757), "Katsina, Nigeria", "24", 2334797, false, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), null, "Katsina", "Katsina", "katsina" },
                    { new Guid("f52c744e-8254-46a8-a89e-47745f3cd5b6"), null, new Guid("1a0f0f6c-e60a-467a-9fb6-1f6f2e9a8413"), new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3818), "Kano, Nigeria", "29", 2335196, false, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), null, "Kano", "Kano", "kano" },
                    { new Guid("813e2e6d-6386-4f96-a1eb-53bde23e836d"), null, new Guid("1a0f0f6c-e60a-467a-9fb6-1f6f2e9a8413"), new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3849), "Kaduna, Nigeria", "23", 2335722, false, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), null, "Kaduna", "Kaduna", "kaduna" },
                    { new Guid("070819e9-1afc-45ce-bff0-e7830dc435ef"), null, new Guid("1a0f0f6c-e60a-467a-9fb6-1f6f2e9a8413"), new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3911), "Imo, Nigeria", "28", 2337542, false, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), null, "Imo", "Imo", "imo" },
                    { new Guid("30982108-afab-492c-b987-bd4c770498c5"), null, new Guid("1a0f0f6c-e60a-467a-9fb6-1f6f2e9a8413"), new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3937), "Cross River, Nigeria", "22", 2345891, false, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), null, "Cross River", "Cross River", "cross-river" },
                    { new Guid("4d4496af-ca7a-4fee-b9f0-71439d9e710f"), null, new Guid("1a0f0f6c-e60a-467a-9fb6-1f6f2e9a8413"), new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4003), "Borno, Nigeria", "27", 2346794, false, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), null, "Borno", "Borno", "borno" },
                    { new Guid("ce1f63d1-e4f2-4397-8150-ed8dfdc0c7c8"), null, new Guid("1a0f0f6c-e60a-467a-9fb6-1f6f2e9a8413"), new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4070), "Benue, Nigeria", "26", 2347266, false, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), null, "Benue", "Benue", "benue" },
                    { new Guid("23fa487e-e6e3-4c6c-84f3-78b651653809"), null, new Guid("1a0f0f6c-e60a-467a-9fb6-1f6f2e9a8413"), new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4178), "Anambra, Nigeria", "25", 2349961, false, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), null, "Anambra", "Anambra", "anambra" },
                    { new Guid("bd860af9-1ce9-4e42-b8a7-2144c6d1c3f5"), null, new Guid("1a0f0f6c-e60a-467a-9fb6-1f6f2e9a8413"), new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5175), "Yobe, Nigeria", "44", 2597367, false, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), null, "Yobe", "Yobe", "yobe" }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "AlternativeNames", "CreatedBy_Id", "CreatedOn", "DisplayName", "FeatureCode", "GeonameCode", "GeonameId", "IsDeleted", "Latitude", "Longitude", "ModifiedBy_Id", "ModifiedOn", "Name", "NameAscii", "Population", "Region_Id", "SearchNames", "Slug" },
                values: new object[,]
                {
                    { new Guid("5a13397b-bb6f-4a42-ad77-32aae9120a7d"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(2456), "Tambuwal, Sokoto, Nigeria", "PPLA2", null, 2322495, false, 12.0m, 5.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(2456), "Tambuwal", "Tambuwal", "20932", new Guid("25c42834-7c89-4fda-aef0-c27742378868"), "tambuwalnigeria tambuwalsokotonigeria", "tambuwal" },
                    { new Guid("edea623e-437f-424e-a8de-1a57fb09b8ad"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4559), "Awgu, Enugu, Nigeria", "PPLA2", null, 2348783, false, 6.0m, 7.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4559), "Awgu", "Awgu", "23175", new Guid("efe20337-7cfc-4058-aa4a-e3e1b75d0d3a"), "awguenugunigeria awgunigeria", "awgu" },
                    { new Guid("430929c4-ca01-41f6-84ad-8dcfe0709812"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4564), "Aku, Enugu, Nigeria", "PPL", null, 2350886, false, 7.0m, 7.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4564), "Aku", "Aku", "73742", new Guid("efe20337-7cfc-4058-aa4a-e3e1b75d0d3a"), "akuenugunigeria akunigeria", "aku" },
                    { new Guid("0bc7aa87-60b8-4381-ba38-1b3be7d85709"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4569), "Eha Amufu, Enugu, Nigeria", "PPL", null, 2343822, false, 7.0m, 8.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4569), "Eha Amufu", "Eha Amufu", "70779", new Guid("efe20337-7cfc-4058-aa4a-e3e1b75d0d3a"), "ehaamufuenugunigeria ehaamufunigeria", "eha-amufu" },
                    { new Guid("fac62e35-e74f-42c5-9fbf-b9a15b3c3654"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4579), "Enugu-Ezike, Enugu, Nigeria", "PPLA2", null, 2343273, false, 7.0m, 7.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4579), "Enugu-Ezike", "Enugu-Ezike", "18989", new Guid("efe20337-7cfc-4058-aa4a-e3e1b75d0d3a"), "enuguezikeenugunigeria enuguezikenigeria", "enugu-ezike" },
                    { new Guid("55f390d1-ff21-48cc-b495-a4a949d126bf"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4579), "Enugu, Enugu, Nigeria", "PPLA", null, 2343279, false, 6.0m, 7.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4579), "Enugu", "Enugu", "688862", new Guid("efe20337-7cfc-4058-aa4a-e3e1b75d0d3a"), "enuguenugunigeria enugunigeria", "enugu" },
                    { new Guid("9665bb36-a677-4336-bcd0-6da337570d0d"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4595), "Birnin Kudu, Jigawa, Nigeria", "PPLA2", null, 2347057, false, 11.0m, 9.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4595), "Birnin Kudu", "Birnin Kudu", "26565", new Guid("55503554-9c1b-43b7-bbc2-32cc627429ab"), "birninkudujigawanigeria birninkudunigeria", "birnin-kudu" },
                    { new Guid("dad70793-f46e-4942-8ca6-236aef83359f"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4600), "Dutse, Jigawa, Nigeria", "PPLA", null, 2344245, false, 12.0m, 9.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4600), "Dutse", "Dutse", "17129", new Guid("55503554-9c1b-43b7-bbc2-32cc627429ab"), "dutsejigawanigeria dutsenigeria", "dutse" },
                    { new Guid("dcb16fff-1c6d-4fdc-b62e-b26394b2fbc1"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4605), "Gumel, Jigawa, Nigeria", "PPLA2", null, 2340091, false, 13.0m, 9.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4605), "Gumel", "Gumel", "42742", new Guid("55503554-9c1b-43b7-bbc2-32cc627429ab"), "gumeljigawanigeria gumelnigeria", "gumel" },
                    { new Guid("6ec383f4-3618-483d-b0b6-21bb68904a28"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4610), "Gwaram, Jigawa, Nigeria", "PPLA2", null, 2339786, false, 11.0m, 10.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4610), "Gwaram", "Gwaram", "15806", new Guid("55503554-9c1b-43b7-bbc2-32cc627429ab"), "gwaramjigawanigeria gwaramnigeria", "gwaram" },
                    { new Guid("361d9c70-c5cf-4d9e-bc14-966002a2bccf"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4615), "Hadejia, Jigawa, Nigeria", "PPLA2", null, 2339631, false, 12.0m, 10.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4615), "Hadejia", "Hadejia", "110753", new Guid("55503554-9c1b-43b7-bbc2-32cc627429ab"), "hadejiajigawanigeria hadejianigeria", "hadejia" },
                    { new Guid("49938a8c-6c16-463e-8ddb-d55c3cdce36b"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4620), "Kiyawa, Jigawa, Nigeria", "PPLA2", null, 2334306, false, 12.0m, 10.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4620), "Kiyawa", "Kiyawa", "17704", new Guid("55503554-9c1b-43b7-bbc2-32cc627429ab"), "kiyawajigawanigeria kiyawanigeria", "kiyawa" },
                    { new Guid("a92836c3-8e3d-4178-b74d-53411a8c6cdf"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4631), "Yenagoa, Bayelsa, Nigeria", "PPLA", null, 2318123, false, 5.0m, 6.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4631), "Yenagoa", "Yenagoa", "24335", new Guid("69c477cf-4675-464d-82e6-b24ce3426e63"), "yenagoabayelsanigeria yenagoanigeria", "yenagoa" },
                    { new Guid("bb7ac6ac-409d-4778-8d54-05a95838cc1a"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4553), "Nsukka, Enugu, Nigeria", "PPL", null, 2328684, false, 7.0m, 7.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4553), "Nsukka", "Nsukka", "111017", new Guid("efe20337-7cfc-4058-aa4a-e3e1b75d0d3a"), "nsukkaenugunigeria nsukkanigeria", "nsukka" },
                    { new Guid("55126952-45ed-4507-9730-152dde936c87"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4641), "Isieke, Ebonyi, Nigeria", "PPL", null, 2337148, false, 6.0m, 8.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4641), "Isieke", "Isieke", "89990", new Guid("1f8c8e8a-9cfd-45cf-a6a6-23c84c3266b7"), "isiekeebonyinigeria isiekenigeria", "isieke" },
                    { new Guid("91620b79-91b3-4b5a-9034-a2737831e402"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4651), "Ezza-Ohu, Ebonyi, Nigeria", "PPL", null, 2342883, false, 6.0m, 8.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4651), "Ezza-Ohu", "Ezza-Ohu", "67414", new Guid("1f8c8e8a-9cfd-45cf-a6a6-23c84c3266b7"), "ezzaohuebonyinigeria ezzaohunigeria", "ezza-ohu" },
                    { new Guid("648dbd8f-4bb8-40e0-a12b-a669c497b9fe"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4656), "Afikpo, Ebonyi, Nigeria", "PPLA2", null, 2352250, false, 6.0m, 8.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4656), "Afikpo", "Afikpo", "71866", new Guid("1f8c8e8a-9cfd-45cf-a6a6-23c84c3266b7"), "afikpoebonyinigeria afikponigeria", "afikpo" },
                    { new Guid("7f081552-c7d0-4611-a062-f119e7d416e4"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4661), "Abakaliki, Ebonyi, Nigeria", "PPLA", null, 2353099, false, 6.0m, 8.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4661), "Abakaliki", "Abakaliki", "134102", new Guid("1f8c8e8a-9cfd-45cf-a6a6-23c84c3266b7"), "abakalikiebonyinigeria abakalikinigeria", "abakaliki" },
                    { new Guid("44ca7f66-c7ba-49e0-8851-5b4c9ae87439"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4672), "Ado-Ekiti, Ekiti, Nigeria", "PPLA", null, 2352379, false, 8.0m, 5.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4672), "Ado-Ekiti", "Ado-Ekiti", "424340", new Guid("67cdd3df-6dd2-452c-989d-2d55d3985fb0"), "adoekitiekitinigeria adoekitinigeria", "ado-ekiti" },
                    { new Guid("56a4bf7b-8c9f-463d-819d-efcc9c684fe9"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4677), "Aramoko-Ekiti, Ekiti, Nigeria", "PPLA2", null, 2349529, false, 8.0m, 5.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4677), "Aramoko-Ekiti", "Aramoko-Ekiti", "74491", new Guid("67cdd3df-6dd2-452c-989d-2d55d3985fb0"), "aramokoekitiekitinigeria aramokoekitinigeria", "aramoko-ekiti" },
                    { new Guid("d5a6363c-b193-4566-8c28-316723825a95"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4723), "Emure-Ekiti, Ekiti, Nigeria", "PPLA2", null, 2343299, false, 7.0m, 5.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4723), "Emure-Ekiti", "Emure-Ekiti", "90645", new Guid("67cdd3df-6dd2-452c-989d-2d55d3985fb0"), "emureekitiekitinigeria emureekitinigeria", "emure-ekiti" },
                    { new Guid("4f26a2ce-ec6a-4403-bc30-cc389798f79c"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4728), "Ise-Ekiti, Ekiti, Nigeria", "PPLA2", null, 2337207, false, 7.0m, 5.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4728), "Ise-Ekiti", "Ise-Ekiti", "190063", new Guid("67cdd3df-6dd2-452c-989d-2d55d3985fb0"), "iseekitiekitinigeria iseekitinigeria", "ise-ekiti" },
                    { new Guid("51d60e7b-884d-4c34-bf94-f0fdc278320c"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4728), "Ikere-Ekiti, Ekiti, Nigeria", "PPLA2", null, 2338287, false, 7.0m, 5.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4728), "Ikere-Ekiti", "Ikere-Ekiti", "103054", new Guid("67cdd3df-6dd2-452c-989d-2d55d3985fb0"), "ikereekitiekitinigeria ikereekitinigeria", "ikere-ekiti" },
                    { new Guid("c7593f8a-b929-45c0-894f-eeb0cda332c4"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4738), "Ipoti, Ekiti, Nigeria", "PPL", null, 2337352, false, 8.0m, 5.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4738), "Ipoti", "Ipoti", "82113", new Guid("67cdd3df-6dd2-452c-989d-2d55d3985fb0"), "ipotiekitinigeria ipotinigeria", "ipoti" },
                    { new Guid("5d1a7dde-cc90-473e-8f8d-914a27bb75c1"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4744), "Igede-Ekiti, Ekiti, Nigeria", "PPLA2", null, 2338630, false, 8.0m, 5.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4744), "Igede-Ekiti", "Igede-Ekiti", "87282", new Guid("67cdd3df-6dd2-452c-989d-2d55d3985fb0"), "igedeekitiekitinigeria igedeekitinigeria", "igede-ekiti" },
                    { new Guid("bd4195aa-e2e0-4313-8024-591aff86ab85"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4749), "Ijero-Ekiti, Ekiti, Nigeria", "PPLA2", null, 2338385, false, 8.0m, 5.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4749), "Ijero-Ekiti", "Ijero-Ekiti", "167632", new Guid("67cdd3df-6dd2-452c-989d-2d55d3985fb0"), "ijeroekitiekitinigeria ijeroekitinigeria", "ijero-ekiti" },
                    { new Guid("64f5a709-f2ca-4ebe-a2e6-0ec86fbb4813"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4754), "Igbara-Odo, Ekiti, Nigeria", "PPL", null, 2338810, false, 8.0m, 5.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4754), "Igbara-Odo", "Igbara-Odo", "74121", new Guid("67cdd3df-6dd2-452c-989d-2d55d3985fb0"), "igbaraodoekitinigeria igbaraodonigeria", "igbara-odo" },
                    { new Guid("4a161d6e-a0d3-48ed-bbfa-57ef54caffe0"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4646), "Effium, Ebonyi, Nigeria", "PPL", null, 2343985, false, 7.0m, 8.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4646), "Effium", "Effium", "86945", new Guid("1f8c8e8a-9cfd-45cf-a6a6-23c84c3266b7"), "effiumebonyinigeria effiumnigeria", "effium" },
                    { new Guid("48aa4112-a747-4a7b-9140-6ea4a23be51d"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4759), "Oke Ila, Ekiti, Nigeria", "PPL", null, 2327233, false, 8.0m, 5.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4759), "Oke Ila", "Oke Ila", "35000", new Guid("67cdd3df-6dd2-452c-989d-2d55d3985fb0"), "okeilaekitinigeria okeilanigeria", "oke-ila" },
                    { new Guid("11de31c8-bd02-487f-a307-50ac624bbe06"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4543), "Ubiaja, Edo, Nigeria", "PPLA2", null, 2321031, false, 7.0m, 6.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4543), "Ubiaja", "Ubiaja", "21782", new Guid("71946e96-1943-4499-a92a-745cde65b50b"), "ubiajaedonigeria ubiajanigeria", "ubiaja" },
                    { new Guid("db46689a-58d0-44db-b3a0-42273d55b314"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4456), "Benin City, Edo, Nigeria", "PPLA", null, 2347283, false, 6.0m, 6.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4456), "Benin City", "Benin City", "1125058", new Guid("71946e96-1943-4499-a92a-745cde65b50b"), "benincityedonigeria benincitynigeria", "benin-city" },
                    { new Guid("e034abfb-94a3-418e-a374-697daf22f762"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4255), "Ikot Ekpene, Akwa Ibom, Nigeria", "PPLA2", null, 2338106, false, 5.0m, 8.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4255), "Ikot Ekpene", "Ikot Ekpene", "254806", new Guid("142fbdf9-fa82-4de4-a495-d1f37d39ff0b"), "ikotekpeneakwaibomnigeria ikotekpenenigeria", "ikot-ekpene" },
                    { new Guid("b3c3fbaa-a40b-41a2-b941-cf85aa57267d"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4260), "Esuk Oron, Akwa Ibom, Nigeria", "PPL", null, 2343093, false, 5.0m, 8.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4260), "Esuk Oron", "Esuk Oron", "112033", new Guid("142fbdf9-fa82-4de4-a495-d1f37d39ff0b"), "esukoronakwaibomnigeria esukoronnigeria", "esuk-oron" },
                    { new Guid("a079d77e-5450-4821-b814-bcdd14b72b24"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4266), "Eket, Akwa Ibom, Nigeria", "PPLA2", null, 2343720, false, 5.0m, 8.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4266), "Eket", "Eket", "25569", new Guid("142fbdf9-fa82-4de4-a495-d1f37d39ff0b"), "eketakwaibomnigeria eketnigeria", "eket" },
                    { new Guid("7b1853d8-3a6d-478b-9b24-44f269fb06a3"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4276), "Kuje, Abuja Federal Capital Territory, Nigeria", "PPLA2", null, 2333604, false, 9.0m, 7.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4276), "Kuje", "Kuje", "97367", new Guid("3e578df6-0388-499b-b8e6-2d8b302e8c0a"), "kujeabujafederalcapitalterritorynigeria kujenigeria", "kuje" },
                    { new Guid("0b20d4e5-1fa0-4909-a0f3-5e9dda72e3c7"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4281), "Abuja, Abuja Federal Capital Territory, Nigeria", "PPLC", null, 2352778, false, 9.0m, 7.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4281), "Abuja", "Abuja", "590400", new Guid("3e578df6-0388-499b-b8e6-2d8b302e8c0a"), "abujaabujafederalcapitalterritorynigeria abujanigeria", "abuja" },
                    { new Guid("ac358849-2f49-4084-bc89-4a794a2b45ca"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4291), "Aba, Abia, Nigeria", "PPLA2", null, 2353151, false, 5.0m, 7.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4291), "Aba", "Aba", "897560", new Guid("04c075c9-90f3-4715-b35f-fd28f5861146"), "abaabianigeria abanigeria", "aba" },
                    { new Guid("b77719ec-9545-4a5b-9517-463ab1bca645"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4296), "Ohafia-Ifigh, Abia, Nigeria", "PPL", null, 2327494, false, 6.0m, 8.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4296), "Ohafia-Ifigh", "Ohafia-Ifigh", "73355", new Guid("04c075c9-90f3-4715-b35f-fd28f5861146"), "ohafiaifighabianigeria ohafiaifighnigeria", "ohafia-ifigh" },
                    { new Guid("2c433baa-2a03-4bde-a268-d93f8a7fc230"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4338), "Umuahia, Abia, Nigeria", "PPLA", null, 2320576, false, 6.0m, 7.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4338), "Umuahia", "Umuahia", "264662", new Guid("04c075c9-90f3-4715-b35f-fd28f5861146"), "umuahiaabianigeria umuahianigeria", "umuahia" },
                    { new Guid("dce13681-ea76-4ccc-9bcd-5f9d4fe25018"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4343), "Amaigbo, Abia, Nigeria", "PPL", null, 2350249, false, 6.0m, 8.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4343), "Amaigbo", "Amaigbo", "127300", new Guid("04c075c9-90f3-4715-b35f-fd28f5861146"), "amaigboabianigeria amaigbonigeria", "amaigbo" },
                    { new Guid("b2f14a24-27fa-4211-8555-c764d87bc660"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4348), "Bende, Abia, Nigeria", "PPLA2", null, 2347303, false, 6.0m, 8.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4348), "Bende", "Bende", "79618", new Guid("04c075c9-90f3-4715-b35f-fd28f5861146"), "bendeabianigeria bendenigeria", "bende" },
                    { new Guid("bfd02270-3d0c-412f-a19d-67ea7988f740"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4358), "Burutu, Delta, Nigeria", "PPLA2", null, 2346317, false, 5.0m, 6.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4358), "Burutu", "Burutu", "16410", new Guid("cb946de4-da80-4ccb-9b3d-89eec72c51f0"), "burutudeltanigeria burutunigeria", "burutu" },
                    { new Guid("299c67e6-7f7d-4aa1-bb1a-b6c9bb94bdc5"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4363), "Asaba, Delta, Nigeria", "PPLA", null, 2349276, false, 6.0m, 7.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4363), "Asaba", "Asaba", "73374", new Guid("cb946de4-da80-4ccb-9b3d-89eec72c51f0"), "asabadeltanigeria asabanigeria", "asaba" },
                    { new Guid("a2dc075e-a6d3-4241-afba-8511ffd373e8"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4461), "Uromi, Edo, Nigeria", "PPL", null, 2319668, false, 7.0m, 6.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4461), "Uromi", "Uromi", "108608", new Guid("71946e96-1943-4499-a92a-745cde65b50b"), "uromiedonigeria urominigeria", "uromi" },
                    { new Guid("71f9f5ef-68df-4ede-a270-7df40f5c2989"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4368), "Agbor, Delta, Nigeria", "PPLA2", null, 2351979, false, 6.0m, 6.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4368), "Agbor", "Agbor", "67610", new Guid("cb946de4-da80-4ccb-9b3d-89eec72c51f0"), "agbordeltanigeria agbornigeria", "agbor" },
                    { new Guid("662e6b11-bb13-468e-998f-b5a12d7a28cc"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4384), "Warri, Delta, Nigeria", "PPLA2", null, 2319133, false, 6.0m, 6.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4384), "Warri", "Warri", "536023", new Guid("cb946de4-da80-4ccb-9b3d-89eec72c51f0"), "warrideltanigeria warrinigeria", "warri" },
                    { new Guid("b87b0435-2530-4afd-8b7f-2a9383816fab"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4389), "Ogwashi-Uku, Delta, Nigeria", "PPLA2", null, 2327513, false, 6.0m, 7.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4389), "Ogwashi-Uku", "Ogwashi-Uku", "26137", new Guid("cb946de4-da80-4ccb-9b3d-89eec72c51f0"), "ogwashiukudeltanigeria ogwashiukunigeria", "ogwashi-uku" },
                    { new Guid("306ad7cd-e308-4603-8deb-47aa44bf6089"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4394), "Sapele, Delta, Nigeria", "PPLA2", null, 2323675, false, 6.0m, 6.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4394), "Sapele", "Sapele", "161686", new Guid("cb946de4-da80-4ccb-9b3d-89eec72c51f0"), "sapeledeltanigeria sapelenigeria", "sapele" },
                    { new Guid("3285e999-203e-41a9-a370-23925195235c"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4399), "Kwale, Delta, Nigeria", "PPLA2", null, 2332871, false, 6.0m, 6.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4399), "Kwale", "Kwale", "20226", new Guid("cb946de4-da80-4ccb-9b3d-89eec72c51f0"), "kwaledeltanigeria kwalenigeria", "kwale" },
                    { new Guid("a4fc3731-cdfe-469d-b93b-253a0f0e0855"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4410), "Numan, Adamawa, Nigeria", "PPLA2", null, 2328617, false, 9.0m, 12.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4410), "Numan", "Numan", "77617", new Guid("297154ee-9790-480d-bbd6-e34c82c17078"), "numanadamawanigeria numannigeria", "numan" },
                    { new Guid("cfc22c5d-a9bc-407a-aef5-b470d6e2667a"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4415), "Mubi, Adamawa, Nigeria", "PPLA2", null, 2329821, false, 10.0m, 13.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4415), "Mubi", "Mubi", "225705", new Guid("297154ee-9790-480d-bbd6-e34c82c17078"), "mubiadamawanigeria mubinigeria", "mubi" },
                    { new Guid("641e6edf-b653-4df6-b7b6-1d1605f10930"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4420), "Yola, Adamawa, Nigeria", "PPLA", null, 2318044, false, 9.0m, 12.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4420), "Yola", "Yola", "96006", new Guid("297154ee-9790-480d-bbd6-e34c82c17078"), "yolaadamawanigeria yolanigeria", "yola" },
                    { new Guid("194563b7-ca5b-43ac-9cab-4a3455e516ac"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4425), "Ganye, Adamawa, Nigeria", "PPLA2", null, 2341955, false, 8.0m, 12.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4425), "Ganye", "Ganye", "15178", new Guid("297154ee-9790-480d-bbd6-e34c82c17078"), "ganyeadamawanigeria ganyenigeria", "ganye" },
                    { new Guid("ba615b74-e10f-4771-a6c2-8eeccc6be4be"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4430), "Jimeta, Adamawa, Nigeria", "PPLA2", null, 2336056, false, 9.0m, 12.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4430), "Jimeta", "Jimeta", "248148", new Guid("297154ee-9790-480d-bbd6-e34c82c17078"), "jimetaadamawanigeria jimetanigeria", "jimeta" },
                    { new Guid("d214f8a0-c2d4-49ec-b80f-1346bc09080b"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4435), "Gombi, Adamawa, Nigeria", "PPLA2", null, 2340446, false, 10.0m, 13.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4435), "Gombi", "Gombi", "19616", new Guid("297154ee-9790-480d-bbd6-e34c82c17078"), "gombiadamawanigeria gombinigeria", "gombi" },
                    { new Guid("35f2f5ed-aada-4c54-9eca-2b233576afe8"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4445), "Ekpoma, Edo, Nigeria", "PPLA2", null, 2343641, false, 7.0m, 6.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4445), "Ekpoma", "Ekpoma", "59618", new Guid("71946e96-1943-4499-a92a-745cde65b50b"), "ekpomaedonigeria ekpomanigeria", "ekpoma" },
                    { new Guid("6e055fc4-46ba-406a-8d68-e55fefa410a2"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4451), "Auchi, Edo, Nigeria", "PPLA2", null, 2348892, false, 7.0m, 6.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4451), "Auchi", "Auchi", "62907", new Guid("71946e96-1943-4499-a92a-745cde65b50b"), "auchiedonigeria auchinigeria", "auchi" },
                    { new Guid("fb858654-e59a-4401-ad9c-49d348a0fde2"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4374), "Ughelli, Delta, Nigeria", "PPLA2", null, 2320829, false, 5.0m, 6.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4374), "Ughelli", "Ughelli", "79986", new Guid("cb946de4-da80-4ccb-9b3d-89eec72c51f0"), "ughellideltanigeria ughellinigeria", "ughelli" },
                    { new Guid("16ec3255-b465-49e9-a693-16f39a5483bc"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4769), "Pindiga, Gombe, Nigeria", "PPL", null, 2324857, false, 10.0m, 11.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4769), "Pindiga", "Pindiga", "106322", new Guid("cc1730f9-2764-4533-aa07-2917142784b6"), "pindigagombenigeria pindiganigeria", "pindiga" },
                    { new Guid("0e39a46e-7662-446e-8d7b-ac79ef254201"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4774), "Kumo, Gombe, Nigeria", "PPLA2", null, 2333451, false, 10.0m, 11.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4774), "Kumo", "Kumo", "35712", new Guid("cc1730f9-2764-4533-aa07-2917142784b6"), "kumogombenigeria kumonigeria", "kumo" },
                    { new Guid("b17c7374-d377-4ddb-9688-a39728cc72a9"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4780), "Nafada, Gombe, Nigeria", "PPLA2", null, 2329562, false, 11.0m, 11.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4780), "Nafada", "Nafada", "22920", new Guid("cc1730f9-2764-4533-aa07-2917142784b6"), "nafadagombenigeria nafadanigeria", "nafada" },
                    { new Guid("f3045324-b3c0-4449-96fa-08786beeabb4"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5021), "Iwo, Osun, Nigeria", "PPLA2", null, 2336905, false, 8.0m, 4.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5021), "Iwo", "Iwo", "250443", new Guid("5b95c24a-71e9-4e70-a3cc-99f87fcad7da"), "iwonigeria iwoosunnigeria", "iwo" },
                    { new Guid("17a34120-18af-45ae-a5c5-2e6a298b556c"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5026), "Ilobu, Osun, Nigeria", "PPLA2", null, 2337659, false, 8.0m, 4.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5026), "Ilobu", "Ilobu", "118089", new Guid("5b95c24a-71e9-4e70-a3cc-99f87fcad7da"), "ilobunigeria ilobuosunnigeria", "ilobu" },
                    { new Guid("8b1dbc51-b233-49a7-8a1a-551f9998242f"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5032), "Inisa, Osun, Nigeria", "PPL", null, 2337490, false, 8.0m, 4.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5032), "Inisa", "Inisa", "164161", new Guid("5b95c24a-71e9-4e70-a3cc-99f87fcad7da"), "inisanigeria inisaosunnigeria", "inisa" },
                    { new Guid("388b0d60-1875-4f9f-bd5a-568af44bde65"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5037), "Ikirun, Osun, Nigeria", "PPLA2", null, 2338269, false, 8.0m, 5.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5037), "Ikirun", "Ikirun", "134240", new Guid("5b95c24a-71e9-4e70-a3cc-99f87fcad7da"), "ikirunnigeria ikirunosunnigeria", "ikirun" },
                    { new Guid("34a99c6c-e7a0-49fa-8a9f-f171c34fca09"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5042), "Ikire, Osun, Nigeria", "PPLA2", null, 2338273, false, 7.0m, 4.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5042), "Ikire", "Ikire", "222160", new Guid("5b95c24a-71e9-4e70-a3cc-99f87fcad7da"), "ikirenigeria ikireosunnigeria", "ikire" },
                    { new Guid("34a04268-bc33-47bb-873b-de138778d48b"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5083), "Ila Orangun, Osun, Nigeria", "PPLA2", null, 2337765, false, 8.0m, 5.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5083), "Ila Orangun", "Ila Orangun", "179192", new Guid("5b95c24a-71e9-4e70-a3cc-99f87fcad7da"), "ilaorangunnigeria ilaorangunosunnigeria", "ila-orangun" },
                    { new Guid("0c32365c-a851-45cc-8f91-0df68998d3f1"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5088), "Ilesa, Osun, Nigeria", "PPLA2", null, 2337704, false, 8.0m, 5.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5088), "Ilesa", "Ilesa", "277904", new Guid("5b95c24a-71e9-4e70-a3cc-99f87fcad7da"), "ilesanigeria ilesaosunnigeria", "ilesa" },
                    { new Guid("bbedb94c-679f-4071-a0a4-82a0327dc4b6"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5093), "Effon Alaiye, Osun, Nigeria", "PPL", null, 2343983, false, 8.0m, 5.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5093), "Effon Alaiye", "Effon Alaiye", "279319", new Guid("5b95c24a-71e9-4e70-a3cc-99f87fcad7da"), "effonalaiyenigeria effonalaiyeosunnigeria", "effon-alaiye" },
                    { new Guid("050c5310-3955-4421-b0b2-5ba9a74418a4"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5098), "Ejigbo, Osun, Nigeria", "PPLA2", null, 2343784, false, 8.0m, 4.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5098), "Ejigbo", "Ejigbo", "138357", new Guid("5b95c24a-71e9-4e70-a3cc-99f87fcad7da"), "ejigbonigeria ejigboosunnigeria", "ejigbo" },
                    { new Guid("70f432f7-d7ee-4ce4-8aed-7ffc4509ee09"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5103), "Apomu, Osun, Nigeria", "PPLA2", null, 2349558, false, 7.0m, 4.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5103), "Apomu", "Apomu", "71656", new Guid("5b95c24a-71e9-4e70-a3cc-99f87fcad7da"), "apomunigeria apomuosunnigeria", "apomu" },
                    { new Guid("acb9581a-8a70-41c9-ac16-2f4b4daf4d4f"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5109), "Oke Mesi, Osun, Nigeria", "PPL", null, 2327223, false, 8.0m, 5.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5109), "Oke Mesi", "Oke Mesi", "79563", new Guid("5b95c24a-71e9-4e70-a3cc-99f87fcad7da"), "okemesinigeria okemesiosunnigeria", "oke-mesi" },
                    { new Guid("49c034a1-01c9-46dc-9f5c-78a611f8c057"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5114), "Olupona, Osun, Nigeria", "PPL", null, 2326302, false, 8.0m, 4.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5114), "Olupona", "Olupona", "95002", new Guid("5b95c24a-71e9-4e70-a3cc-99f87fcad7da"), "oluponanigeria oluponaosunnigeria", "olupona" },
                    { new Guid("13808d64-8b0a-4cb6-a36c-7fe83cbe1132"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5016), "Gbongan, Osun, Nigeria", "PPLA2", null, 2341355, false, 7.0m, 4.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5016), "Gbongan", "Gbongan", "139485", new Guid("5b95c24a-71e9-4e70-a3cc-99f87fcad7da"), "gbongannigeria gbonganosunnigeria", "gbongan" },
                    { new Guid("ffe7b7e8-ecd1-480e-ab6a-e89ff365b7cd"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5119), "Oyan, Osun, Nigeria", "PPL", null, 2325249, false, 8.0m, 5.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5119), "Oyan", "Oyan", "73622", new Guid("5b95c24a-71e9-4e70-a3cc-99f87fcad7da"), "oyannigeria oyanosunnigeria", "oyan" },
                    { new Guid("65d1fcd0-2e5d-45e4-a732-04d6e38d826c"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5129), "Osogbo, Osun, Nigeria", "PPLA", null, 2325590, false, 8.0m, 5.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5129), "Osogbo", "Osogbo", "156694", new Guid("5b95c24a-71e9-4e70-a3cc-99f87fcad7da"), "osogbonigeria osogboosunnigeria", "osogbo" },
                    { new Guid("af86fb22-691e-4c89-8dea-5ecf961e3571"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5139), "Modakeke, Osun, Nigeria", "PPL", null, 2330028, false, 7.0m, 4.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5139), "Modakeke", "Modakeke", "119529", new Guid("5b95c24a-71e9-4e70-a3cc-99f87fcad7da"), "modakekenigeria modakekeosunnigeria", "modakeke" },
                    { new Guid("ff4dd0bb-5d9e-4575-9830-f65061090a04"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5145), "Wukari, Taraba, Nigeria", "PPLA2", null, 2318921, false, 8.0m, 10.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5145), "Wukari", "Wukari", "92933", new Guid("50c0c9cb-cfcb-4589-9bf6-115705c2e72f"), "wukarinigeria wukaritarabanigeria", "wukari" },
                    { new Guid("3347d596-6bdc-4cd7-9a4b-3cce0f5f2236"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5155), "Beli, Taraba, Nigeria", "PPL", null, 2347330, false, 8.0m, 11.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5155), "Beli", "Beli", "17467", new Guid("50c0c9cb-cfcb-4589-9bf6-115705c2e72f"), "belinigeria belitarabanigeria", "beli" },
                    { new Guid("505f7124-8017-48f7-a295-4af3ce9ca1ef"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5160), "Jalingo, Taraba, Nigeria", "PPLA", null, 2336589, false, 9.0m, 11.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5160), "Jalingo", "Jalingo", "117757", new Guid("50c0c9cb-cfcb-4589-9bf6-115705c2e72f"), "jalingonigeria jalingotarabanigeria", "jalingo" },
                    { new Guid("f556203c-49c4-4a73-92d7-17f74e5154df"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5165), "Gembu, Taraba, Nigeria", "PPL", null, 2341275, false, 7.0m, 11.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5165), "Gembu", "Gembu", "19881", new Guid("50c0c9cb-cfcb-4589-9bf6-115705c2e72f"), "gembunigeria gembutarabanigeria", "gembu" },
                    { new Guid("dc2e1d06-23f8-4dac-a3da-61b74032ac0e"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5170), "Ibi, Taraba, Nigeria", "PPLA2", null, 2339287, false, 8.0m, 10.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5170), "Ibi", "Ibi", "22757", new Guid("50c0c9cb-cfcb-4589-9bf6-115705c2e72f"), "ibinigeria ibitarabanigeria", "ibi" },
                    { new Guid("24b8e7b5-89f3-4730-8f97-8a224252fbcb"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5181), "Geidam, Yobe, Nigeria", "PPLA2", null, 2341294, false, 13.0m, 12.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5181), "Geidam", "Geidam", "41367", new Guid("bd860af9-1ce9-4e42-b8a7-2144c6d1c3f5"), "geidamnigeria geidamyobenigeria", "geidam" },
                    { new Guid("c8574b1d-ec0e-4774-b688-4042e172f446"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5186), "Gashua, Yobe, Nigeria", "PPLA2", null, 2341656, false, 13.0m, 11.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5186), "Gashua", "Gashua", "125817", new Guid("bd860af9-1ce9-4e42-b8a7-2144c6d1c3f5"), "gashuanigeria gashuayobenigeria", "gashua" },
                    { new Guid("e6dc1060-2c35-4f9d-8cea-882c6a9a6fe2"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5191), "Damaturu, Yobe, Nigeria", "PPLA", null, 2345521, false, 12.0m, 12.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5191), "Damaturu", "Damaturu", "46000", new Guid("bd860af9-1ce9-4e42-b8a7-2144c6d1c3f5"), "damaturunigeria damaturuyobenigeria", "damaturu" },
                    { new Guid("b7d7538c-418c-4ced-97cb-5686b16cd68c"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5196), "Daura, Yobe, Nigeria", "PPL", null, 2345096, false, 12.0m, 11.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5196), "Daura", "Daura", "78277", new Guid("bd860af9-1ce9-4e42-b8a7-2144c6d1c3f5"), "dauranigeria daurayobenigeria", "daura" },
                    { new Guid("fe947a84-703c-4fd4-8b4f-b31ed1f1f271"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5201), "Nguru, Yobe, Nigeria", "PPLA2", null, 2328952, false, 13.0m, 10.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5201), "Nguru", "Nguru", "111014", new Guid("bd860af9-1ce9-4e42-b8a7-2144c6d1c3f5"), "ngurunigeria nguruyobenigeria", "nguru" },
                    { new Guid("9ca133a9-7a98-4d58-a9e1-d2869f1a1ea4"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5124), "Otan Ayegbaju, Osun, Nigeria", "PPLA2", null, 2325506, false, 8.0m, 5.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5124), "Otan Ayegbaju", "Otan Ayegbaju", "37783", new Guid("5b95c24a-71e9-4e70-a3cc-99f87fcad7da"), "otanayegbajunigeria otanayegbajuosunnigeria", "otan-ayegbaju" },
                    { new Guid("adf54abd-f1ec-4071-895a-9d25a69843b9"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5006), "Ijebu-Jesa, Osun, Nigeria", "PPLA2", null, 2338401, false, 8.0m, 5.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5006), "Ijebu-Jesa", "Ijebu-Jesa", "51730", new Guid("5b95c24a-71e9-4e70-a3cc-99f87fcad7da"), "ijebujesanigeria ijebujesaosunnigeria", "ijebu-jesa" },
                    { new Guid("6d257005-9808-4922-8e57-a3916b59ea16"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5001), "Idah, Kogi, Nigeria", "PPLA2", null, 2339156, false, 7.0m, 7.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5001), "Idah", "Idah", "68703", new Guid("d34d4180-6438-4982-84c5-7fbf953234b7"), "idahkoginigeria idahnigeria", "idah" },
                    { new Guid("5a29c5e9-8bca-43ea-b1b6-2043aa8a8a14"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4990), "Kabba, Kogi, Nigeria", "PPLA2", null, 2335843, false, 8.0m, 6.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4990), "Kabba", "Kabba", "49869", new Guid("d34d4180-6438-4982-84c5-7fbf953234b7"), "kabbakoginigeria kabbanigeria", "kabba" },
                    { new Guid("f2ed6707-aa42-439e-be2d-ff800b60b4e6"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4785), "Gombe, Gombe, Nigeria", "PPLA", null, 2340451, false, 10.0m, 11.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4785), "Gombe", "Gombe", "250258", new Guid("cc1730f9-2764-4533-aa07-2917142784b6"), "gombegombenigeria gombenigeria", "gombe" },
                    { new Guid("0cecc56e-5043-4dd3-96fb-18457ce4c4dd"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4795), "Garko, Gombe, Nigeria", "PPL", null, 2341758, false, 10.0m, 11.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4795), "Garko", "Garko", "21141", new Guid("cc1730f9-2764-4533-aa07-2917142784b6"), "garkogombenigeria garkonigeria", "garko" },
                    { new Guid("c0d80957-f919-4c92-9675-7808c0206a25"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4800), "Dukku, Gombe, Nigeria", "PPLA2", null, 2344418, false, 11.0m, 11.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4800), "Dukku", "Dukku", "16961", new Guid("cc1730f9-2764-4533-aa07-2917142784b6"), "dukkugombenigeria dukkunigeria", "dukku" },
                    { new Guid("17a39da3-5066-46a4-91b0-bbef3bf461d7"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4805), "Deba, Gombe, Nigeria", "PPLA2", null, 2345029, false, 10.0m, 11.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4805), "Deba", "Deba", "17671", new Guid("cc1730f9-2764-4533-aa07-2917142784b6"), "debagombenigeria debanigeria", "deba" },
                    { new Guid("72758097-e776-493a-ba2d-329b98752351"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4810), "Billiri, Gombe, Nigeria", "PPL", null, 2347155, false, 10.0m, 11.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4810), "Billiri", "Billiri", "15976", new Guid("cc1730f9-2764-4533-aa07-2917142784b6"), "billirigombenigeria billirinigeria", "billiri" },
                    { new Guid("00e1282c-c7f9-4156-a96b-575749f439b7"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4821), "Akwanga, Nassarawa, Nigeria", "PPLA2", null, 2350806, false, 9.0m, 8.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4821), "Akwanga", "Akwanga", "15985", new Guid("beb2f024-3c49-403e-a263-6b79cdceb62d"), "akwanganassarawanigeria akwanganigeria", "akwanga" },
                    { new Guid("4f3469e3-8603-4afe-a7c6-d2617e24d7f3"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4826), "Doma, Nassarawa, Nigeria", "PPLA2", null, 2344600, false, 8.0m, 8.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4826), "Doma", "Doma", "15097", new Guid("beb2f024-3c49-403e-a263-6b79cdceb62d"), "domanassarawanigeria domanigeria", "doma" },
                    { new Guid("b2adb363-3c31-428e-b752-10b26849ed99"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4831), "Nasarawa, Nassarawa, Nigeria", "PPLA2", null, 2329451, false, 9.0m, 8.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4831), "Nasarawa", "Nasarawa", "30949", new Guid("beb2f024-3c49-403e-a263-6b79cdceb62d"), "nasarawanassarawanigeria nasarawanigeria", "nasarawa" },
                    { new Guid("a6853d91-2be8-4af5-9cff-44f9460c3bf1"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4836), "Keffi, Nassarawa, Nigeria", "PPLA2", null, 2334652, false, 9.0m, 8.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4836), "Keffi", "Keffi", "85911", new Guid("beb2f024-3c49-403e-a263-6b79cdceb62d"), "keffinassarawanigeria keffinigeria", "keffi" },
                    { new Guid("0fcc79bc-7d8d-4edf-851c-42a1b3841493"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4841), "Lafia, Nassarawa, Nigeria", "PPLA", null, 2332515, false, 8.0m, 9.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4841), "Lafia", "Lafia", "127236", new Guid("beb2f024-3c49-403e-a263-6b79cdceb62d"), "lafianassarawanigeria lafianigeria", "lafia" },
                    { new Guid("3c6b27c1-9488-49f8-b312-18017b5b3d2e"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4846), "Wamba, Nassarawa, Nigeria", "PPLA2", null, 2319257, false, 9.0m, 9.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4846), "Wamba", "Wamba", "27137", new Guid("beb2f024-3c49-403e-a263-6b79cdceb62d"), "wambanassarawanigeria wambanigeria", "wamba" },
                    { new Guid("55d27eb6-10bd-4a23-9955-23c4a405c548"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4857), "Talata Mafara, Zamfara, Nigeria", "PPLA2", null, 2322529, false, 13.0m, 6.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4857), "Talata Mafara", "Talata Mafara", "39045", new Guid("4c745d27-df1d-40c0-b531-aa6659e15f33"), "talatamafaranigeria talatamafarazamfaranigeria", "talata-mafara" },
                    { new Guid("2d519c1c-fa5b-43b2-840d-57f22d40d1ca"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4862), "Kaura Namoda, Zamfara, Nigeria", "PPLA2", null, 2334756, false, 13.0m, 7.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4862), "Kaura Namoda", "Kaura Namoda", "69725", new Guid("4c745d27-df1d-40c0-b531-aa6659e15f33"), "kauranamodanigeria kauranamodazamfaranigeria", "kaura-namoda" },
                    { new Guid("7cd404e7-8081-46a2-814d-9f4ffd59a56b"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4867), "Moriki, Zamfara, Nigeria", "PPL", null, 2329920, false, 13.0m, 6.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4867), "Moriki", "Moriki", "28735", new Guid("4c745d27-df1d-40c0-b531-aa6659e15f33"), "morikinigeria morikizamfaranigeria", "moriki" },
                    { new Guid("c251a26f-de85-4b11-9a25-25db57350d2f"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4908), "Gusau, Zamfara, Nigeria", "PPLA", null, 2339937, false, 12.0m, 7.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4908), "Gusau", "Gusau", "226857", new Guid("4c745d27-df1d-40c0-b531-aa6659e15f33"), "gusaunigeria gusauzamfaranigeria", "gusau" },
                    { new Guid("6a52cad4-fa2e-48b7-9bca-ba0d27e99aea"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4913), "Gummi, Zamfara, Nigeria", "PPLA2", null, 2340086, false, 12.0m, 5.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4913), "Gummi", "Gummi", "38744", new Guid("4c745d27-df1d-40c0-b531-aa6659e15f33"), "gumminigeria gummizamfaranigeria", "gummi" },
                    { new Guid("00417987-1e3e-40f0-8f87-016c0ddcac04"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4929), "Jega, Kebbi, Nigeria", "PPLA2", null, 2336237, false, 12.0m, 4.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4929), "Jega", "Jega", "73495", new Guid("c84f31d9-b3c7-45a1-bd77-f5230193a318"), "jegakebbinigeria jeganigeria", "jega" },
                    { new Guid("28fbf01f-32c5-458a-9fee-208df284ea02"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4934), "Kamba, Kebbi, Nigeria", "PPLA2", null, 2335333, false, 12.0m, 4.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4934), "Kamba", "Kamba", "25568", new Guid("c84f31d9-b3c7-45a1-bd77-f5230193a318"), "kambakebbinigeria kambanigeria", "kamba" },
                    { new Guid("4f2358ce-4f6a-466d-a4d4-6c1ab8f15858"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4939), "Birnin Kebbi, Kebbi, Nigeria", "PPLA", null, 2347059, false, 12.0m, 4.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4939), "Birnin Kebbi", "Birnin Kebbi", "108164", new Guid("c84f31d9-b3c7-45a1-bd77-f5230193a318"), "birninkebbikebbinigeria birninkebbinigeria", "birnin-kebbi" }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "AlternativeNames", "CreatedBy_Id", "CreatedOn", "DisplayName", "FeatureCode", "GeonameCode", "GeonameId", "IsDeleted", "Latitude", "Longitude", "ModifiedBy_Id", "ModifiedOn", "Name", "NameAscii", "Population", "Region_Id", "SearchNames", "Slug" },
                values: new object[,]
                {
                    { new Guid("46bdd9d8-b190-4626-97da-6c8c46139539"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4944), "Argungu, Kebbi, Nigeria", "PPLA2", null, 2349431, false, 13.0m, 5.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4944), "Argungu", "Argungu", "45584", new Guid("c84f31d9-b3c7-45a1-bd77-f5230193a318"), "argungukebbinigeria argungunigeria", "argungu" },
                    { new Guid("a4d894f9-4904-458c-b7e5-11f806a9e80c"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4949), "Zuru, Kebbi, Nigeria", "PPLA2", null, 2317548, false, 11.0m, 5.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4949), "Zuru", "Zuru", "24338", new Guid("c84f31d9-b3c7-45a1-bd77-f5230193a318"), "zurukebbinigeria zurunigeria", "zuru" },
                    { new Guid("ee8bf654-130b-40ae-b76f-227d246db3c0"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4960), "Lokoja, Kogi, Nigeria", "PPLA", null, 2331939, false, 8.0m, 7.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4960), "Lokoja", "Lokoja", "60579", new Guid("d34d4180-6438-4982-84c5-7fbf953234b7"), "lokojakoginigeria lokojanigeria", "lokoja" },
                    { new Guid("91c6ac23-8cb9-43ec-b60d-369908ed52b2"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4965), "Ogaminana, Kogi, Nigeria", "PPLA2", null, 2327827, false, 8.0m, 6.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4965), "Ogaminana", "Ogaminana", "84373", new Guid("d34d4180-6438-4982-84c5-7fbf953234b7"), "ogaminanakoginigeria ogaminananigeria", "ogaminana" },
                    { new Guid("3a183b56-e697-4277-8b43-a1e2ad5a2f99"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4970), "Okene, Kogi, Nigeria", "PPLA2", null, 2327220, false, 8.0m, 6.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4970), "Okene", "Okene", "479178", new Guid("d34d4180-6438-4982-84c5-7fbf953234b7"), "okenekoginigeria okenenigeria", "okene" },
                    { new Guid("6d5eb7f0-b602-4496-9f75-76184956e785"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4975), "Ajaokuta, Kogi, Nigeria", "PPL", null, 2351470, false, 8.0m, 7.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4975), "Ajaokuta", "Ajaokuta", "15144", new Guid("d34d4180-6438-4982-84c5-7fbf953234b7"), "ajaokutakoginigeria ajaokutanigeria", "ajaokuta" },
                    { new Guid("bb1b9481-911e-4708-b9d8-0c339b827d16"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4980), "Egbe, Kogi, Nigeria", "PPL", null, 2343943, false, 8.0m, 6.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4980), "Egbe", "Egbe", "17612", new Guid("d34d4180-6438-4982-84c5-7fbf953234b7"), "egbekoginigeria egbenigeria", "egbe" },
                    { new Guid("8a73bc21-b217-4779-8727-383fd92bf1db"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4985), "Isanlu-Itedoijowa, Kogi, Nigeria", "PPL", null, 2337235, false, 8.0m, 6.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4985), "Isanlu-Itedoijowa", "Isanlu-Itedoijowa", "15087", new Guid("d34d4180-6438-4982-84c5-7fbf953234b7"), "isanluitedoijowakoginigeria isanluitedoijowanigeria", "isanlu-itedoijowa" },
                    { new Guid("dd977187-3dee-4b81-82b6-ef558b8000a5"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4250), "Itu, Akwa Ibom, Nigeria", "PPLA2", null, 2336985, false, 5.0m, 8.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4250), "Itu", "Itu", "36358", new Guid("142fbdf9-fa82-4de4-a495-d1f37d39ff0b"), "ituakwaibomnigeria itunigeria", "itu" },
                    { new Guid("faf1a706-4fc9-4640-a90d-7992115f8659"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5206), "Kumagunnam, Yobe, Nigeria", "PPL", null, 2333490, false, 13.0m, 11.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5206), "Kumagunnam", "Kumagunnam", "16557", new Guid("bd860af9-1ce9-4e42-b8a7-2144c6d1c3f5"), "kumagunnamnigeria kumagunnamyobenigeria", "kumagunnam" },
                    { new Guid("1fdcc6fd-b5d2-4c8f-b7ba-8d2531dc5229"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4245), "Uyo, Akwa Ibom, Nigeria", "PPLA", null, 2319480, false, 5.0m, 8.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4245), "Uyo", "Uyo", "436606", new Guid("142fbdf9-fa82-4de4-a495-d1f37d39ff0b"), "uyoakwaibomnigeria uyonigeria", "uyo" },
                    { new Guid("a34ba26e-bd60-448f-8853-4efa39b92516"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4224), "Nkpor, Anambra, Nigeria", "PPL", null, 2328811, false, 6.0m, 7.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4224), "Nkpor", "Nkpor", "103733", new Guid("23fa487e-e6e3-4c6c-84f3-78b651653809"), "nkporanambranigeria nkpornigeria", "nkpor" },
                    { new Guid("e8407c29-3818-4229-8b71-b05f011e447d"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3525), "Ijebu-Igbo, Ogun, Nigeria", "PPLA2", null, 2338403, false, 7.0m, 4.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3525), "Ijebu-Igbo", "Ijebu-Igbo", "109261", new Guid("4e3cb3b1-2bb1-4535-bf39-172520cdbc3f"), "ijebuigbonigeria ijebuigboogunnigeria", "ijebu-igbo" },
                    { new Guid("14f8d04b-f697-46da-8636-7d2a4d938418"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3530), "Ilaro, Ogun, Nigeria", "PPLA2", null, 2337759, false, 7.0m, 3.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3530), "Ilaro", "Ilaro", "46999", new Guid("4e3cb3b1-2bb1-4535-bf39-172520cdbc3f"), "ilaronigeria ilaroogunnigeria", "ilaro" },
                    { new Guid("081d78cb-54d8-4d1b-ada2-5af5ae74af4d"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3541), "Iperu, Ogun, Nigeria", "PPL", null, 2337379, false, 7.0m, 4.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3541), "Iperu", "Iperu", "15935", new Guid("4e3cb3b1-2bb1-4535-bf39-172520cdbc3f"), "iperunigeria iperuogunnigeria", "iperu" },
                    { new Guid("139629b8-cf65-4e18-ba19-a69d03f782d1"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3546), "Ado Odo, Ogun, Nigeria", "PPL", null, 2352356, false, 7.0m, 3.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3546), "Ado Odo", "Ado Odo", "15442", new Guid("4e3cb3b1-2bb1-4535-bf39-172520cdbc3f"), "adoodonigeria adoodoogunnigeria", "ado-odo" },
                    { new Guid("25ac7593-4a50-4348-8a7b-ba6f0e412c50"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3551), "Abeokuta, Ogun, Nigeria", "PPLA", null, 2352947, false, 7.0m, 3.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3551), "Abeokuta", "Abeokuta", "593100", new Guid("4e3cb3b1-2bb1-4535-bf39-172520cdbc3f"), "abeokutanigeria abeokutaogunnigeria", "abeokuta" },
                    { new Guid("0603efb5-fe1a-443a-8cd3-a660cae6953e"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3556), "Shagamu, Ogun, Nigeria", "PPLA2", null, 2323411, false, 7.0m, 4.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3556), "Shagamu", "Shagamu", "214558", new Guid("4e3cb3b1-2bb1-4535-bf39-172520cdbc3f"), "shagamunigeria shagamuogunnigeria", "shagamu" },
                    { new Guid("be483fdb-524c-4d93-bce0-d2de2c775e0e"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3566), "Rijau, Niger, Nigeria", "PPLA2", null, 2324504, false, 11.0m, 5.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3566), "Rijau", "Rijau", "16613", new Guid("aecf4ca6-7558-40c2-bf35-f962032bf85e"), "rijaunigeria rijaunigernigeria", "rijau" },
                    { new Guid("b14177fb-4671-46b7-8e6a-e0c0ec83cc72"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3572), "Suleja, Niger, Nigeria", "PPLA2", null, 2322794, false, 9.0m, 7.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3572), "Suleja", "Suleja", "162135", new Guid("aecf4ca6-7558-40c2-bf35-f962032bf85e"), "sulejanigeria sulejanigernigeria", "suleja" },
                    { new Guid("5729d1d5-2080-4067-991c-edc283224f45"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3577), "Kontagora, Niger, Nigeria", "PPLA2", null, 2334008, false, 10.0m, 5.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3577), "Kontagora", "Kontagora", "98754", new Guid("aecf4ca6-7558-40c2-bf35-f962032bf85e"), "kontagoranigeria kontagoranigernigeria", "kontagora" },
                    { new Guid("e8ee170b-8d3a-4fb8-9892-02974d265f5f"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3582), "Mokwa, Niger, Nigeria", "PPLA2", null, 2329981, false, 9.0m, 5.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3582), "Mokwa", "Mokwa", "21128", new Guid("aecf4ca6-7558-40c2-bf35-f962032bf85e"), "mokwanigeria mokwanigernigeria", "mokwa" },
                    { new Guid("15f4b579-ca87-4791-b29e-0a3323154cfe"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3587), "Minna, Niger, Nigeria", "PPLA", null, 2330100, false, 10.0m, 7.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3587), "Minna", "Minna", "291905", new Guid("aecf4ca6-7558-40c2-bf35-f962032bf85e"), "minnanigeria minnanigernigeria", "minna" },
                    { new Guid("c8aa4029-e807-4dfd-bb7b-98e6d5554bd6"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3592), "Tegina, Niger, Nigeria", "PPL", null, 2322263, false, 10.0m, 6.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3592), "Tegina", "Tegina", "24037", new Guid("aecf4ca6-7558-40c2-bf35-f962032bf85e"), "teginanigeria teginanigernigeria", "tegina" },
                    { new Guid("4a7d771b-2cc2-4b87-a2cf-58d983842bbf"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3520), "Ijebu-Ode, Ogun, Nigeria", "PPLA2", null, 2338400, false, 7.0m, 4.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3520), "Ijebu-Ode", "Ijebu-Ode", "209175", new Guid("4e3cb3b1-2bb1-4535-bf39-172520cdbc3f"), "ijebuodenigeria ijebuodeogunnigeria", "ijebu-ode" },
                    { new Guid("0f6f9661-0ec5-47b0-b622-9a122cc02831"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3597), "Zungeru, Niger, Nigeria", "PPL", null, 2317569, false, 10.0m, 6.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3597), "Zungeru", "Zungeru", "24447", new Guid("aecf4ca6-7558-40c2-bf35-f962032bf85e"), "zungerunigeria zungerunigernigeria", "zungeru" },
                    { new Guid("b3bff09b-cb31-4b71-acb3-fe21d33f637b"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3649), "Babana, Niger, Nigeria", "PPL", null, 2348507, false, 10.0m, 4.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3649), "Babana", "Babana", "17617", new Guid("aecf4ca6-7558-40c2-bf35-f962032bf85e"), "babananigeria babananigernigeria", "babana" },
                    { new Guid("11370397-0527-4cbe-8627-9fd965ba5ecf"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3654), "Bida, Niger, Nigeria", "PPLA2", null, 2347209, false, 9.0m, 6.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3654), "Bida", "Bida", "171656", new Guid("aecf4ca6-7558-40c2-bf35-f962032bf85e"), "bidanigeria bidanigernigeria", "bida" },
                    { new Guid("17bfa062-2faf-4fdf-a44d-fbe573e8b4a7"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3659), "Lapai, Niger, Nigeria", "PPLA2", null, 2332249, false, 9.0m, 7.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3659), "Lapai", "Lapai", "16442", new Guid("aecf4ca6-7558-40c2-bf35-f962032bf85e"), "lapainigeria lapainigernigeria", "lapai" },
                    { new Guid("1f2e3dad-75a9-4559-ba22-a3739fe022a9"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3664), "Ibeto, Niger, Nigeria", "PPL", null, 2339293, false, 10.0m, 5.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3664), "Ibeto", "Ibeto", "15565", new Guid("aecf4ca6-7558-40c2-bf35-f962032bf85e"), "ibetonigeria ibetonigernigeria", "ibeto" },
                    { new Guid("4bb62cae-a7d7-4695-b2fa-896a912f81af"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3674), "Ikeja, Lagos, Nigeria", "PPLA", null, 2338313, false, 7.0m, 3.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3674), "Ikeja", "Ikeja", "313196", new Guid("c5abe7ab-1d93-41b9-ad36-b1d195d0b88b"), "ikejalagosnigeria ikejanigeria", "ikeja" },
                    { new Guid("0c2c0e4f-5af1-4b29-9871-f46060b0dbc5"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3680), "Badagry, Lagos, Nigeria", "PPLA2", null, 2348395, false, 6.0m, 3.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3680), "Badagry", "Badagry", "26383", new Guid("c5abe7ab-1d93-41b9-ad36-b1d195d0b88b"), "badagrylagosnigeria badagrynigeria", "badagry" },
                    { new Guid("198a73a6-b385-4179-a04b-10f769b15e26"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3685), "Epe, Lagos, Nigeria", "PPL", null, 2343252, false, 7.0m, 4.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3685), "Epe", "Epe", "84711", new Guid("c5abe7ab-1d93-41b9-ad36-b1d195d0b88b"), "epelagosnigeria epenigeria", "epe" },
                    { new Guid("85cdf61e-9528-4655-aa73-cc217a9ddb45"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3690), "Ebute Ikorodu, Lagos, Nigeria", "PPL", null, 2344082, false, 7.0m, 3.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3690), "Ebute Ikorodu", "Ebute Ikorodu", "535619", new Guid("c5abe7ab-1d93-41b9-ad36-b1d195d0b88b"), "ebuteikorodulagosnigeria ebuteikorodunigeria", "ebute-ikorodu" },
                    { new Guid("45bcf60b-5cfa-433e-8db8-64b967907a09"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3700), "Lagos, Lagos, Nigeria", "PPLA2", null, 2332459, false, 6.0m, 3.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3700), "Lagos", "Lagos", "9000000", new Guid("c5abe7ab-1d93-41b9-ad36-b1d195d0b88b"), "lagoslagosnigeria lagosnigeria", "lagos" },
                    { new Guid("8dafbdd8-f69a-445c-9bc6-9b7e8bde9475"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3710), "Lafiagi, Kwara, Nigeria", "PPLA2", null, 2332504, false, 9.0m, 5.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3710), "Lafiagi", "Lafiagi", "102779", new Guid("9216cdb7-87a0-4485-90d7-dabbf68544b7"), "lafiagikwaranigeria lafiaginigeria", "lafiagi" },
                    { new Guid("1e613ad5-3606-4a36-b6ac-07e7d16a5cb6"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3716), "Offa, Kwara, Nigeria", "PPLA2", null, 2327879, false, 8.0m, 5.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3716), "Offa", "Offa", "113830", new Guid("9216cdb7-87a0-4485-90d7-dabbf68544b7"), "offakwaranigeria offanigeria", "offa" },
                    { new Guid("50ff1f94-1b9b-43d8-a2ac-d35de14a03a6"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3721), "Patigi, Kwara, Nigeria", "PPLA2", null, 2324960, false, 9.0m, 6.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3721), "Patigi", "Patigi", "28285", new Guid("9216cdb7-87a0-4485-90d7-dabbf68544b7"), "patigikwaranigeria patiginigeria", "patigi" },
                    { new Guid("8c29c3cf-ac35-4a51-810d-22c20f9ce02f"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3644), "Baro, Niger, Nigeria", "PPL", null, 2347592, false, 9.0m, 6.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3644), "Baro", "Baro", "26821", new Guid("aecf4ca6-7558-40c2-bf35-f962032bf85e"), "baronigeria baronigernigeria", "baro" },
                    { new Guid("ff94aaad-5d87-4330-9fdf-761f9a2207ae"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3726), "Okuta, Kwara, Nigeria", "PPL", null, 2326811, false, 9.0m, 3.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3726), "Okuta", "Okuta", "26589", new Guid("9216cdb7-87a0-4485-90d7-dabbf68544b7"), "okutakwaranigeria okutanigeria", "okuta" },
                    { new Guid("ce0770e0-f18c-4f8b-8c17-fe2d622cadad"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3515), "Ifo, Ogun, Nigeria", "PPLA2", null, 2338876, false, 7.0m, 3.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3515), "Ifo", "Ifo", "88272", new Guid("4e3cb3b1-2bb1-4535-bf39-172520cdbc3f"), "ifonigeria ifoogunnigeria", "ifo" },
                    { new Guid("12a37714-2e08-45bc-88f2-9be80efd7a29"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3500), "Akure, Ondo, Nigeria", "PPLA", null, 2350841, false, 7.0m, 5.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3500), "Akure", "Akure", "420594", new Guid("e0daf433-f8e5-4630-9ac5-4363cbd1d3c5"), "akurenigeria akureondonigeria", "akure" },
                    { new Guid("6debff08-ec34-453c-b63b-470b8f707e0d"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3150), "Sokoto, Sokoto, Nigeria", "PPLA", null, 2322911, false, 13.0m, 5.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3150), "Sokoto", "Sokoto", "563861", new Guid("25c42834-7c89-4fda-aef0-c27742378868"), "sokotonigeria sokotosokotonigeria", "sokoto" },
                    { new Guid("8b00d426-7b9f-4463-85a7-b76cdf49e7bf"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3160), "Illela, Sokoto, Nigeria", "PPLA2", null, 2337680, false, 14.0m, 5.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3160), "Illela", "Illela", "17461", new Guid("25c42834-7c89-4fda-aef0-c27742378868"), "illelanigeria illelasokotonigeria", "illela" },
                    { new Guid("7724bbc6-7b64-456b-8764-01f26cb7353a"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3171), "Gwadabawa, Sokoto, Nigeria", "PPLA2", null, 2339892, false, 13.0m, 5.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3171), "Gwadabawa", "Gwadabawa", "17486", new Guid("25c42834-7c89-4fda-aef0-c27742378868"), "gwadabawanigeria gwadabawasokotonigeria", "gwadabawa" },
                    { new Guid("1fe6ea5d-a056-4966-b7c9-c98193b0938d"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3289), "Elele, Rivers, Nigeria", "PPL", null, 2343512, false, 5.0m, 7.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3289), "Elele", "Elele", "20620", new Guid("a7b2a7ad-4a36-48e1-afd1-21e9167e6b4c"), "elelenigeria eleleriversnigeria", "elele" },
                    { new Guid("c2fa466a-625c-4cdd-bd27-662fd1b46c6f"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3304), "Buguma, Rivers, Nigeria", "PPLA2", null, 2346615, false, 5.0m, 7.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3304), "Buguma", "Buguma", "135404", new Guid("a7b2a7ad-4a36-48e1-afd1-21e9167e6b4c"), "bugumanigeria bugumariversnigeria", "buguma" },
                    { new Guid("79955078-0096-40d1-9e1e-fbd244fc9a6f"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3309), "Bonny, Rivers, Nigeria", "PPLA2", null, 2346812, false, 4.0m, 7.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3309), "Bonny", "Bonny", "16868", new Guid("a7b2a7ad-4a36-48e1-afd1-21e9167e6b4c"), "bonnynigeria bonnyriversnigeria", "bonny" },
                    { new Guid("1ee89d7d-2754-4340-beee-0f59a08067e9"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3315), "Port Harcourt, Rivers, Nigeria", "PPLA", null, 2324774, false, 5.0m, 7.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3315), "Port Harcourt", "Port Harcourt", "1148665", new Guid("a7b2a7ad-4a36-48e1-afd1-21e9167e6b4c"), "portharcourtnigeria portharcourtriversnigeria", "port-harcourt" },
                    { new Guid("f8640cd1-7309-4c6d-b661-1b114d4708f8"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3320), "Okrika, Rivers, Nigeria", "PPLA2", null, 2326899, false, 5.0m, 7.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3320), "Okrika", "Okrika", "133271", new Guid("a7b2a7ad-4a36-48e1-afd1-21e9167e6b4c"), "okrikanigeria okrikariversnigeria", "okrika" },
                    { new Guid("c28faa74-f5ad-4658-a498-e1a31822b085"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3325), "Obonoma, Rivers, Nigeria", "PPL", null, 2328185, false, 5.0m, 7.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3325), "Obonoma", "Obonoma", "68584", new Guid("a7b2a7ad-4a36-48e1-afd1-21e9167e6b4c"), "obonomanigeria obonomariversnigeria", "obonoma" },
                    { new Guid("0659b385-af5e-4566-aad2-15853316a4aa"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3335), "Degema Hulk, Rivers, Nigeria", "PPL", null, 2591159, false, 5.0m, 7.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3335), "Degema Hulk", "Degema Hulk", "19223", new Guid("a7b2a7ad-4a36-48e1-afd1-21e9167e6b4c"), "degemahulknigeria degemahulkriversnigeria", "degema-hulk" },
                    { new Guid("a7bec0fa-2841-4d51-9f72-cbe1f0b1a397"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3345), "Pankshin, Plateau, Nigeria", "PPLA2", null, 2325060, false, 9.0m, 9.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3345), "Pankshin", "Pankshin", "31516", new Guid("ed51291a-e5a1-4faf-a087-d8c3d5a8ec45"), "pankshinnigeria pankshinplateaunigeria", "pankshin" },
                    { new Guid("c0efb97a-70d6-4479-a52d-145f78cb2eea"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3356), "Bukuru, Plateau, Nigeria", "PPLA2", null, 2346561, false, 10.0m, 9.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3356), "Bukuru", "Bukuru", "15540", new Guid("ed51291a-e5a1-4faf-a087-d8c3d5a8ec45"), "bukurunigeria bukuruplateaunigeria", "bukuru" },
                    { new Guid("1563dc48-4c56-4060-a604-cfb1200839dc"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3505), "Idanre, Ondo, Nigeria", "PPL", null, 2339150, false, 7.0m, 5.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3505), "Idanre", "Idanre", "86468", new Guid("e0daf433-f8e5-4630-9ac5-4363cbd1d3c5"), "idanrenigeria idanreondonigeria", "idanre" },
                    { new Guid("ce7e1747-e7c8-4790-a452-0b307b0cce3d"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3361), "Jos, Plateau, Nigeria", "PPLA", null, 2335953, false, 10.0m, 9.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3361), "Jos", "Jos", "816824", new Guid("ed51291a-e5a1-4faf-a087-d8c3d5a8ec45"), "josnigeria josplateaunigeria", "jos" },
                    { new Guid("d9f38681-9430-439f-8e24-d7462c9c9b02"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3376), "Igbo-Ora, Oyo, Nigeria", "PPLA2", null, 2338669, false, 7.0m, 3.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3376), "Igbo-Ora", "Igbo-Ora", "92719", new Guid("8f99b569-a2c2-474f-9776-eadb40fe9012"), "igbooranigeria igbooraoyonigeria", "igbo-ora" },
                    { new Guid("b09e0d5c-076b-4a38-83f7-a4bffcf76037"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3376), "Igboho, Oyo, Nigeria", "PPLA2", null, 2338711, false, 9.0m, 4.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3376), "Igboho", "Igboho", "136764", new Guid("8f99b569-a2c2-474f-9776-eadb40fe9012"), "igbohonigeria igbohooyonigeria", "igboho" },
                    { new Guid("b5f26fc1-da2c-487d-9db0-fe21dd7c6379"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3387), "Igbeti, Oyo, Nigeria", "PPLA2", null, 2338772, false, 9.0m, 4.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3387), "Igbeti", "Igbeti", "24690", new Guid("8f99b569-a2c2-474f-9776-eadb40fe9012"), "igbetinigeria igbetioyonigeria", "igbeti" },
                    { new Guid("6b2dbb60-a506-427d-9917-b53690f5bf2e"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3392), "Fiditi, Oyo, Nigeria", "PPL", null, 2342628, false, 8.0m, 4.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3392), "Fiditi", "Fiditi", "71461", new Guid("8f99b569-a2c2-474f-9776-eadb40fe9012"), "fiditinigeria fiditioyonigeria", "fiditi" },
                    { new Guid("e96e1a84-3a5b-44fe-8cdd-d667d7770c89"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3397), "Oyo, Oyo, Nigeria", "PPLA2", null, 2325200, false, 8.0m, 4.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3397), "Oyo", "Oyo", "736072", new Guid("8f99b569-a2c2-474f-9776-eadb40fe9012"), "oyonigeria oyooyonigeria", "oyo" },
                    { new Guid("25d785a9-d4aa-4bcc-90b3-d35263d750cf"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3407), "Saki, Oyo, Nigeria", "PPLA2", null, 2323390, false, 9.0m, 3.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3407), "Saki", "Saki", "178677", new Guid("8f99b569-a2c2-474f-9776-eadb40fe9012"), "sakinigeria sakioyonigeria", "saki" },
                    { new Guid("8521d543-5223-4973-a73f-02ef693de9b8"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3412), "Orita Eruwa, Oyo, Nigeria", "PPL", null, 2325733, false, 8.0m, 3.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3412), "Orita Eruwa", "Orita Eruwa", "71027", new Guid("8f99b569-a2c2-474f-9776-eadb40fe9012"), "oritaeruwanigeria oritaeruwaoyonigeria", "orita-eruwa" },
                    { new Guid("d04e5bea-acc4-470a-a6e9-81c6deae0a8e"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3464), "Lalupon, Oyo, Nigeria", "PPL", null, 2332357, false, 7.0m, 4.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3464), "Lalupon", "Lalupon", "81130", new Guid("8f99b569-a2c2-474f-9776-eadb40fe9012"), "laluponnigeria laluponoyonigeria", "lalupon" },
                    { new Guid("7e656a04-cb54-40e3-a22b-88793dc1c8a4"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3469), "Kisi, Oyo, Nigeria", "PPLA2", null, 2334327, false, 9.0m, 4.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3469), "Kisi", "Kisi", "155510", new Guid("8f99b569-a2c2-474f-9776-eadb40fe9012"), "kisinigeria kisioyonigeria", "kisi" },
                    { new Guid("efad9c96-260a-4f71-93fc-4a17e4fa61b3"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3479), "Ondo, Ondo, Nigeria", "PPLA2", null, 2326171, false, 7.0m, 5.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3479), "Ondo", "Ondo", "257005", new Guid("e0daf433-f8e5-4630-9ac5-4363cbd1d3c5"), "ondonigeria ondoondonigeria", "ondo" },
                    { new Guid("675994fe-72ca-4d12-bec0-ea1af9bb7d88"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3484), "Ode, Ondo, Nigeria", "PPL", null, 2328090, false, 8.0m, 6.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3484), "Ode", "Ode", "75463", new Guid("e0daf433-f8e5-4630-9ac5-4363cbd1d3c5"), "odenigeria odeondonigeria", "ode" },
                    { new Guid("6c697eb5-fbc6-439c-8059-11109d68032d"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3489), "Owo, Ondo, Nigeria", "PPLA2", null, 2325314, false, 7.0m, 6.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3489), "Owo", "Owo", "276574", new Guid("e0daf433-f8e5-4630-9ac5-4363cbd1d3c5"), "owonigeria owoondonigeria", "owo" },
                    { new Guid("54ffc4d3-7266-45a3-bd42-3507b776cada"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3371), "Ibadan, Oyo, Nigeria", "PPLA", null, 2339354, false, 7.0m, 4.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3371), "Ibadan", "Ibadan", "3565108", new Guid("8f99b569-a2c2-474f-9776-eadb40fe9012"), "ibadannigeria ibadanoyonigeria", "ibadan" },
                    { new Guid("b358a68f-c56c-4e11-bfa4-c586ef4176cb"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3731), "Bode Saadu, Kwara, Nigeria", "PPLA2", null, 2346951, false, 9.0m, 5.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3731), "Bode Saadu", "Bode Saadu", "16619", new Guid("9216cdb7-87a0-4485-90d7-dabbf68544b7"), "bodesaadukwaranigeria bodesaadunigeria", "bode-saadu" },
                    { new Guid("88371911-9114-4bce-8c60-51eb60ca331f"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3741), "Kaiama, Kwara, Nigeria", "PPLA2", null, 2335596, false, 10.0m, 4.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3741), "Kaiama", "Kaiama", "21897", new Guid("9216cdb7-87a0-4485-90d7-dabbf68544b7"), "kaiamakwaranigeria kaiamanigeria", "kaiama" },
                    { new Guid("ba71b9fb-ded9-44cc-8ec8-b920bba6bd2e"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3741), "Ilorin, Kwara, Nigeria", "PPLA", null, 2337639, false, 8.0m, 5.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3741), "Ilorin", "Ilorin", "814192", new Guid("9216cdb7-87a0-4485-90d7-dabbf68544b7"), "ilorinkwaranigeria ilorinnigeria", "ilorin" },
                    { new Guid("207b0c50-a8d4-4f87-806b-e86e5f4d19a6"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4024), "Dikwa, Borno, Nigeria", "PPLA2", null, 2344854, false, 12.0m, 14.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4024), "Dikwa", "Dikwa", "29026", new Guid("4d4496af-ca7a-4fee-b9f0-71439d9e710f"), "dikwabornonigeria dikwanigeria", "dikwa" },
                    { new Guid("f83d7e67-ca53-44e3-9505-5cbdd48f14ae"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4029), "Biu, Borno, Nigeria", "PPLA2", null, 2346995, false, 11.0m, 12.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4029), "Biu", "Biu", "95005", new Guid("4d4496af-ca7a-4fee-b9f0-71439d9e710f"), "biubornonigeria biunigeria", "biu" },
                    { new Guid("d5635959-b7c8-4e4c-b47e-94b0f49b052d"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4034), "Damboa, Borno, Nigeria", "PPLA2", null, 2345498, false, 11.0m, 13.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4034), "Damboa", "Damboa", "21571", new Guid("4d4496af-ca7a-4fee-b9f0-71439d9e710f"), "damboabornonigeria damboanigeria", "damboa" },
                    { new Guid("94e28d84-882e-45d6-9588-2b8c2b00ec21"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4039), "Gamboru, Borno, Nigeria", "PPLA2", null, 2342192, false, 12.0m, 14.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4039), "Gamboru", "Gamboru", "84672", new Guid("4d4496af-ca7a-4fee-b9f0-71439d9e710f"), "gamborubornonigeria gamborunigeria", "gamboru" },
                    { new Guid("9aba57fa-b11f-4f28-a887-961a70cc9dfc"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4045), "Marte, Borno, Nigeria", "PPL", null, 2330719, false, 12.0m, 14.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4045), "Marte", "Marte", "15707", new Guid("4d4496af-ca7a-4fee-b9f0-71439d9e710f"), "martebornonigeria martenigeria", "marte" },
                    { new Guid("63fa158d-145f-4164-b4ef-03ea522650cd"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4050), "Monguno, Borno, Nigeria", "PPLA2", null, 2329946, false, 13.0m, 14.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4050), "Monguno", "Monguno", "20297", new Guid("4d4496af-ca7a-4fee-b9f0-71439d9e710f"), "mongunobornonigeria mongunonigeria", "monguno" },
                    { new Guid("bebe2d82-7900-422a-9b53-8e3f4278c5e0"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4060), "Maiduguri, Borno, Nigeria", "PPLA", null, 2331447, false, 12.0m, 13.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4060), "Maiduguri", "Maiduguri", "1112449", new Guid("4d4496af-ca7a-4fee-b9f0-71439d9e710f"), "maiduguribornonigeria maidugurinigeria", "maiduguri" },
                    { new Guid("0f7c75f3-99f1-4b45-95b0-7151d409d156"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4060), "Magumeri, Borno, Nigeria", "PPLA2", null, 2331528, false, 12.0m, 13.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4060), "Magumeri", "Magumeri", "19363", new Guid("4d4496af-ca7a-4fee-b9f0-71439d9e710f"), "magumeribornonigeria magumerinigeria", "magumeri" },
                    { new Guid("888b45d6-51b2-49c1-a96b-aeb29d449a40"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4070), "Kukawa, Borno, Nigeria", "PPLA2", null, 2333563, false, 13.0m, 14.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4070), "Kukawa", "Kukawa", "16077", new Guid("4d4496af-ca7a-4fee-b9f0-71439d9e710f"), "kukawabornonigeria kukawanigeria", "kukawa" },
                    { new Guid("82b9ec45-30fe-4f0d-a33c-651895b53328"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4081), "Makurdi, Benue, Nigeria", "PPLA", null, 2331140, false, 8.0m, 9.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4081), "Makurdi", "Makurdi", "292645", new Guid("ce1f63d1-e4f2-4397-8150-ed8dfdc0c7c8"), "makurdibenuenigeria makurdinigeria", "makurdi" },
                    { new Guid("3de9c4e2-3429-4996-a652-61395dce9a7e"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4086), "Otukpa, Benue, Nigeria", "PPLA2", null, 2325437, false, 7.0m, 8.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4086), "Otukpa", "Otukpa", "21686", new Guid("ce1f63d1-e4f2-4397-8150-ed8dfdc0c7c8"), "otukpabenuenigeria otukpanigeria", "otukpa" },
                    { new Guid("139cd0c1-ae40-4382-bb3c-38cbce614140"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4091), "Takum, Benue, Nigeria", "PPL", null, 2322552, false, 7.0m, 10.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4091), "Takum", "Takum", "24822", new Guid("ce1f63d1-e4f2-4397-8150-ed8dfdc0c7c8"), "takumbenuenigeria takumnigeria", "takum" },
                    { new Guid("249711a7-d380-4aaf-92ad-d3cda8b59359"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4019), "Bama, Borno, Nigeria", "PPLA2", null, 2347954, false, 12.0m, 14.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4019), "Bama", "Bama", "118121", new Guid("4d4496af-ca7a-4fee-b9f0-71439d9e710f"), "bamabornonigeria bamanigeria", "bama" },
                    { new Guid("108b6698-1dfd-4092-a4a9-bace4bc7f7a8"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4096), "Igbor, Benue, Nigeria", "PPL", null, 2338660, false, 7.0m, 9.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4096), "Igbor", "Igbor", "17666", new Guid("ce1f63d1-e4f2-4397-8150-ed8dfdc0c7c8"), "igborbenuenigeria igbornigeria", "igbor" },
                    { new Guid("7a273b19-8690-4564-b50e-d753a0b319ee"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4111), "Kari, Bauchi, Nigeria", "PPL", null, 2335015, false, 11.0m, 11.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4111), "Kari", "Kari", "18812", new Guid("d4278b26-e02a-4bb1-ba84-131f2d318e29"), "karibauchinigeria karinigeria", "kari" },
                    { new Guid("1001fad7-5552-4390-af93-23a78e6226c9"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4116), "Darazo, Bauchi, Nigeria", "PPLA2", null, 2345152, false, 11.0m, 10.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4116), "Darazo", "Darazo", "18415", new Guid("d4278b26-e02a-4bb1-ba84-131f2d318e29"), "darazobauchinigeria darazonigeria", "darazo" },
                    { new Guid("40c917cf-9741-486f-907a-10ffa9b49d26"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4122), "Bauchi, Bauchi, Nigeria", "PPLA", null, 2347470, false, 10.0m, 10.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4122), "Bauchi", "Bauchi", "316149", new Guid("d4278b26-e02a-4bb1-ba84-131f2d318e29"), "bauchibauchinigeria bauchinigeria", "bauchi" },
                    { new Guid("ac864060-5533-42e1-8c00-f0e0f276721c"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4127), "Azare, Bauchi, Nigeria", "PPLA2", null, 2348595, false, 12.0m, 10.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4127), "Azare", "Azare", "105687", new Guid("d4278b26-e02a-4bb1-ba84-131f2d318e29"), "azarebauchinigeria azarenigeria", "azare" },
                    { new Guid("636adcce-a512-483a-8c11-bf11f2e4db4d"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4183), "Awka, Anambra, Nigeria", "PPLA", null, 2348773, false, 6.0m, 7.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4183), "Awka", "Awka", "167738", new Guid("23fa487e-e6e3-4c6c-84f3-78b651653809"), "awkaanambranigeria awkanigeria", "awka" },
                    { new Guid("a2b8517d-6480-4a4b-b894-d15c0322af2d"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4188), "Agulu, Anambra, Nigeria", "PPL", null, 2351740, false, 6.0m, 7.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4188), "Agulu", "Agulu", "79021", new Guid("23fa487e-e6e3-4c6c-84f3-78b651653809"), "aguluanambranigeria agulunigeria", "agulu" },
                    { new Guid("c9c2384a-4113-46ef-a6d7-42457be4e79e"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4194), "Enugu-Ukwu, Anambra, Nigeria", "PPL", null, 2343270, false, 6.0m, 7.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4194), "Enugu-Ukwu", "Enugu-Ukwu", "68785", new Guid("23fa487e-e6e3-4c6c-84f3-78b651653809"), "enuguukwuanambranigeria enuguukwunigeria", "enugu-ukwu" },
                    { new Guid("70489484-8698-4a4d-b247-696e9211a902"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4199), "Igbo-Ukwu, Anambra, Nigeria", "PPL", null, 2338640, false, 6.0m, 7.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4199), "Igbo-Ukwu", "Igbo-Ukwu", "75224", new Guid("23fa487e-e6e3-4c6c-84f3-78b651653809"), "igboukwuanambranigeria igboukwunigeria", "igbo-ukwu" },
                    { new Guid("6c384b43-2bd0-44d5-acbf-738ff3139684"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4204), "Ihiala, Anambra, Nigeria", "PPLA2", null, 2338497, false, 6.0m, 7.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4204), "Ihiala", "Ihiala", "83265", new Guid("23fa487e-e6e3-4c6c-84f3-78b651653809"), "ihialaanambranigeria ihialanigeria", "ihiala" },
                    { new Guid("0dd7024a-2010-47a2-bcbc-ea8d248a29c4"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4209), "Uga, Anambra, Nigeria", "PPL", null, 2320920, false, 6.0m, 7.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4209), "Uga", "Uga", "64179", new Guid("23fa487e-e6e3-4c6c-84f3-78b651653809"), "ugaanambranigeria uganigeria", "uga" },
                    { new Guid("2f302396-b75f-4497-8061-78f1439fa4ee"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4214), "Ozubulu, Anambra, Nigeria", "PPLA2", null, 2325161, false, 6.0m, 7.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4214), "Ozubulu", "Ozubulu", "73812", new Guid("23fa487e-e6e3-4c6c-84f3-78b651653809"), "ozubuluanambranigeria ozubulunigeria", "ozubulu" },
                    { new Guid("140c754d-45b3-49dd-8396-013e273580a7"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4224), "Onitsha, Anambra, Nigeria", "PPLA2", null, 2326016, false, 6.0m, 7.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4224), "Onitsha", "Onitsha", "561066", new Guid("23fa487e-e6e3-4c6c-84f3-78b651653809"), "onitshaanambranigeria onitshanigeria", "onitsha" },
                    { new Guid("1e7b787c-f029-424e-abde-a4e0110aac9f"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4101), "Katsina-Ala, Benue, Nigeria", "PPLA2", null, 2334801, false, 7.0m, 9.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4101), "Katsina-Ala", "Katsina-Ala", "36722", new Guid("ce1f63d1-e4f2-4397-8150-ed8dfdc0c7c8"), "katsinaalabenuenigeria katsinaalanigeria", "katsina-ala" },
                    { new Guid("942ae04d-b5c3-48aa-93d9-83c94f840388"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4014), "Gwoza, Borno, Nigeria", "PPLA2", null, 2339665, false, 11.0m, 14.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4014), "Gwoza", "Gwoza", "15176", new Guid("4d4496af-ca7a-4fee-b9f0-71439d9e710f"), "gwozabornonigeria gwozanigeria", "gwoza" },
                    { new Guid("9cfa8d4f-0036-4b11-afb8-80361f01bfb7"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4003), "Ikom, Cross River, Nigeria", "PPL", null, 2338242, false, 6.0m, 9.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4003), "Ikom", "Ikom", "79103", new Guid("30982108-afab-492c-b987-bd4c770498c5"), "ikomcrossrivernigeria ikomnigeria", "ikom" },
                    { new Guid("c2cc65ba-f5d2-405b-9c5a-5515834e8377"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3998), "Calabar, Cross River, Nigeria", "PPLA", null, 2346229, false, 5.0m, 8.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3998), "Calabar", "Calabar", "461796", new Guid("30982108-afab-492c-b987-bd4c770498c5"), "calabarcrossrivernigeria calabarnigeria", "calabar" },
                    { new Guid("285f206f-00aa-41d0-9cd7-75ce45ba56e1"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3746), "Jebba, Kwara, Nigeria", "PPL", null, 2336251, false, 9.0m, 5.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3746), "Jebba", "Jebba", "21488", new Guid("9216cdb7-87a0-4485-90d7-dabbf68544b7"), "jebbakwaranigeria jebbanigeria", "jebba" },
                    { new Guid("bf7f20f2-382b-4f60-bd2f-0db5f5f62983"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3762), "Katsina, Katsina, Nigeria", "PPLA", null, 2334802, false, 13.0m, 8.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3762), "Katsina", "Katsina", "432149", new Guid("014fd2f0-9a06-42cd-b119-43198725732d"), "katsinakatsinanigeria katsinanigeria", "katsina" },
                    { new Guid("0f9484e2-30dc-4e35-8da0-71af3380f120"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3767), "Daura, Katsina, Nigeria", "PPLA2", null, 2345094, false, 13.0m, 8.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3767), "Daura", "Daura", "25289", new Guid("014fd2f0-9a06-42cd-b119-43198725732d"), "daurakatsinanigeria dauranigeria", "daura" },
                    { new Guid("7a7f78d7-a453-4889-9b94-03daf404a182"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3772), "Funtua, Katsina, Nigeria", "PPLA2", null, 2342490, false, 12.0m, 7.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3772), "Funtua", "Funtua", "136811", new Guid("014fd2f0-9a06-42cd-b119-43198725732d"), "funtuakatsinanigeria funtuanigeria", "funtua" },
                    { new Guid("bd9e0562-c129-4410-91a3-974a6dd8f23a"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3813), "Malumfashi, Katsina, Nigeria", "PPLA2", null, 2331005, false, 12.0m, 8.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3813), "Malumfashi", "Malumfashi", "70709", new Guid("014fd2f0-9a06-42cd-b119-43198725732d"), "malumfashikatsinanigeria malumfashinigeria", "malumfashi" },
                    { new Guid("d14a59a2-cca6-4a8d-b863-9d0c49afe89f"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3823), "Rano, Kano, Nigeria", "PPLA2", null, 2324575, false, 12.0m, 9.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3823), "Rano", "Rano", "17972", new Guid("f52c744e-8254-46a8-a89e-47745f3cd5b6"), "ranokanonigeria ranonigeria", "rano" },
                    { new Guid("fc041ca4-4761-4cc5-9898-7c0400971507"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3829), "Wudil, Kano, Nigeria", "PPLA2", null, 2318933, false, 12.0m, 9.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3829), "Wudil", "Wudil", "23066", new Guid("f52c744e-8254-46a8-a89e-47745f3cd5b6"), "wudilkanonigeria wudilnigeria", "wudil" },
                    { new Guid("70aa3c5b-5b47-48ac-b3f8-d6f36fcc090a"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3834), "Kano, Kano, Nigeria", "PPLA", null, 2335204, false, 12.0m, 9.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3834), "Kano", "Kano", "3626068", new Guid("f52c744e-8254-46a8-a89e-47745f3cd5b6"), "kanokanonigeria kanonigeria", "kano" }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "AlternativeNames", "CreatedBy_Id", "CreatedOn", "DisplayName", "FeatureCode", "GeonameCode", "GeonameId", "IsDeleted", "Latitude", "Longitude", "ModifiedBy_Id", "ModifiedOn", "Name", "NameAscii", "Population", "Region_Id", "SearchNames", "Slug" },
                values: new object[,]
                {
                    { new Guid("fea11a0d-71f0-4a6b-b9b1-13a049847ee5"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3839), "Gwarzo, Kano, Nigeria", "PPLA2", null, 2339756, false, 12.0m, 8.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3839), "Gwarzo", "Gwarzo", "16303", new Guid("f52c744e-8254-46a8-a89e-47745f3cd5b6"), "gwarzokanonigeria gwarzonigeria", "gwarzo" },
                    { new Guid("26d4ddb6-f05a-42ba-a9f9-73eadfa196d5"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3844), "Gaya, Kano, Nigeria", "PPLA2", null, 2341580, false, 12.0m, 9.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3844), "Gaya", "Gaya", "20959", new Guid("f52c744e-8254-46a8-a89e-47745f3cd5b6"), "gayakanonigeria gayanigeria", "gaya" },
                    { new Guid("a6ed61ff-4fbd-49eb-9fc1-a441cb0e9c0c"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3854), "Kagoro, Kaduna, Nigeria", "PPL", null, 2335614, false, 10.0m, 8.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3854), "Kagoro", "Kagoro", "77008", new Guid("813e2e6d-6386-4f96-a1eb-53bde23e836d"), "kagorokadunanigeria kagoronigeria", "kagoro" },
                    { new Guid("77177ff3-7046-4fea-997d-b9ac2012b600"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3859), "Kafanchan, Kaduna, Nigeria", "PPLA2", null, 2335713, false, 10.0m, 8.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3859), "Kafanchan", "Kafanchan", "79522", new Guid("813e2e6d-6386-4f96-a1eb-53bde23e836d"), "kafanchankadunanigeria kafanchannigeria", "kafanchan" },
                    { new Guid("b2348a4b-9ff3-4df9-8f7a-0fc091a22aa4"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3870), "Kaduna, Kaduna, Nigeria", "PPLA", null, 2335727, false, 11.0m, 7.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3870), "Kaduna", "Kaduna", "1582102", new Guid("813e2e6d-6386-4f96-a1eb-53bde23e836d"), "kadunakadunanigeria kadunanigeria", "kaduna" },
                    { new Guid("5058fd99-32ff-4385-b46d-d23b137c84e1"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3875), "Kachia, Kaduna, Nigeria", "PPLA2", null, 2335798, false, 10.0m, 8.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3875), "Kachia", "Kachia", "30893", new Guid("813e2e6d-6386-4f96-a1eb-53bde23e836d"), "kachiakadunanigeria kachianigeria", "kachia" },
                    { new Guid("5d388ec1-2d3a-4bcf-acf7-d5da88261300"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3875), "Dutsen Wai, Kaduna, Nigeria", "PPL", null, 2344229, false, 11.0m, 8.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3875), "Dutsen Wai", "Dutsen Wai", "22062", new Guid("813e2e6d-6386-4f96-a1eb-53bde23e836d"), "dutsenwaikadunanigeria dutsenwainigeria", "dutsen-wai" },
                    { new Guid("0f500df0-384d-4e9b-92c3-526bd4cbb0c0"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3885), "Anchau, Kaduna, Nigeria", "PPLA2", null, 2349951, false, 11.0m, 8.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3885), "Anchau", "Anchau", "15538", new Guid("813e2e6d-6386-4f96-a1eb-53bde23e836d"), "anchaukadunanigeria anchaunigeria", "anchau" },
                    { new Guid("7b4d1ed9-f03a-4882-b2a7-4f1f1123ff53"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3890), "Sofo-Birnin-Gwari, Kaduna, Nigeria", "PPL", null, 2347061, false, 11.0m, 7.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3890), "Sofo-Birnin-Gwari", "Sofo-Birnin-Gwari", "22380", new Guid("813e2e6d-6386-4f96-a1eb-53bde23e836d"), "sofobirningwarikadunanigeria sofobirningwarinigeria", "sofo-birnin-gwari" },
                    { new Guid("929c5053-78e0-47f4-8ec8-cf8b9b942c4c"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3895), "Soba, Kaduna, Nigeria", "PPL", null, 2322957, false, 11.0m, 8.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3895), "Soba", "Soba", "15715", new Guid("813e2e6d-6386-4f96-a1eb-53bde23e836d"), "sobakadunanigeria sobanigeria", "soba" },
                    { new Guid("a11848cb-c3a1-4a84-b291-6e0516b96339"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3901), "Zaria, Kaduna, Nigeria", "PPL", null, 2317765, false, 11.0m, 8.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3901), "Zaria", "Zaria", "975153", new Guid("813e2e6d-6386-4f96-a1eb-53bde23e836d"), "zariakadunanigeria zarianigeria", "zaria" },
                    { new Guid("b62978af-e093-4907-8a00-509797156c72"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3906), "Lere, Kaduna, Nigeria", "PPL", null, 2332079, false, 10.0m, 9.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3906), "Lere", "Lere", "93290", new Guid("813e2e6d-6386-4f96-a1eb-53bde23e836d"), "lerekadunanigeria lerenigeria", "lere" },
                    { new Guid("38a54474-3fff-4645-b964-e00adebb76ee"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3916), "Nkwerre, Imo, Nigeria", "PPLA2", null, 2328790, false, 6.0m, 7.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3916), "Nkwerre", "Nkwerre", "62973", new Guid("070819e9-1afc-45ce-bff0-e7830dc435ef"), "nkwerreimonigeria nkwerrenigeria", "nkwerre" },
                    { new Guid("769920ed-f09a-4af5-994b-8c18513d9a04"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3921), "Owerri, Imo, Nigeria", "PPLA", null, 2325330, false, 5.0m, 7.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3921), "Owerri", "Owerri", "215038", new Guid("070819e9-1afc-45ce-bff0-e7830dc435ef"), "owerriimonigeria owerrinigeria", "owerri" },
                    { new Guid("d134099a-2036-4f06-9dcb-cad202bbb186"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3926), "Oguta, Imo, Nigeria", "PPLA2", null, 2327521, false, 6.0m, 7.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3926), "Oguta", "Oguta", "21639", new Guid("070819e9-1afc-45ce-bff0-e7830dc435ef"), "ogutaimonigeria ogutanigeria", "oguta" },
                    { new Guid("a278f8af-4c6b-4bdd-af22-9385a78ce4ea"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3931), "Okigwe, Imo, Nigeria", "PPLA2", null, 2327143, false, 6.0m, 7.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3931), "Okigwe", "Okigwe", "115499", new Guid("070819e9-1afc-45ce-bff0-e7830dc435ef"), "okigweimonigeria okigwenigeria", "okigwe" },
                    { new Guid("d6963984-9fe9-4efb-a963-fb4909675b1f"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3942), "Ogoja, Cross River, Nigeria", "PPLA2", null, 2327650, false, 7.0m, 9.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3942), "Ogoja", "Ogoja", "37466", new Guid("30982108-afab-492c-b987-bd4c770498c5"), "ogojacrossrivernigeria ogojanigeria", "ogoja" },
                    { new Guid("0fdde649-738e-4573-9b95-31696e0c0d54"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3947), "Obudu, Cross River, Nigeria", "PPLA2", null, 2328151, false, 7.0m, 9.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3947), "Obudu", "Obudu", "19668", new Guid("30982108-afab-492c-b987-bd4c770498c5"), "obuducrossrivernigeria obudunigeria", "obudu" },
                    { new Guid("fea60ee2-1ecc-446a-b3a5-33756d662838"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3988), "Ugep, Cross River, Nigeria", "PPLA2", null, 2320831, false, 6.0m, 8.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(3988), "Ugep", "Ugep", "200276", new Guid("30982108-afab-492c-b987-bd4c770498c5"), "ugepcrossrivernigeria ugepnigeria", "ugep" },
                    { new Guid("143cad8f-11fa-45b1-b387-1ba60642cd7c"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4230), "Nnewi, Anambra, Nigeria", "PPLA2", null, 2328765, false, 6.0m, 7.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(4230), "Nnewi", "Nnewi", "193987", new Guid("23fa487e-e6e3-4c6c-84f3-78b651653809"), "nnewianambranigeria nnewinigeria", "nnewi" },
                    { new Guid("80530779-83b1-4c96-866c-0221619b4cb8"), null, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5217), "Potiskum, Yobe, Nigeria", "PPLA2", null, 2324767, false, 12.0m, 11.0m, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 8, 6, 22, 23, 5, 809, DateTimeKind.Utc).AddTicks(5217), "Potiskum", "Potiskum", "86002", new Guid("bd860af9-1ce9-4e42-b8a7-2144c6d1c3f5"), "potiskumnigeria potiskumyobenigeria", "potiskum" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_CreatedBy_Id",
                table: "City",
                column: "CreatedBy_Id");

            migrationBuilder.CreateIndex(
                name: "IX_City_ModifiedBy_Id",
                table: "City",
                column: "ModifiedBy_Id");

            migrationBuilder.CreateIndex(
                name: "IX_City_Region_Id",
                table: "City",
                column: "Region_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Country_CreatedBy_Id",
                table: "Country",
                column: "CreatedBy_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Country_ModifiedBy_Id",
                table: "Country",
                column: "ModifiedBy_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Idea_ApplicationIdentityUserId",
                table: "Idea",
                column: "ApplicationIdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Idea_CreatedBy_Id",
                table: "Idea",
                column: "CreatedBy_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Idea_Login_Id",
                table: "Idea",
                column: "Login_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Idea_ModifiedBy_Id",
                table: "Idea",
                column: "ModifiedBy_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_ApplicationIdentityUserId",
                table: "Photo",
                column: "ApplicationIdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_CreatedBy_Id",
                table: "Photo",
                column: "CreatedBy_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_Login_Id",
                table: "Photo",
                column: "Login_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_ModifiedBy_Id",
                table: "Photo",
                column: "ModifiedBy_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Region_Country_Id",
                table: "Region",
                column: "Country_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Region_CreatedBy_Id",
                table: "Region",
                column: "CreatedBy_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Region_ModifiedBy_Id",
                table: "Region",
                column: "ModifiedBy_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddress_City_Id",
                table: "UserAddress",
                column: "City_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddress_Country_Id",
                table: "UserAddress",
                column: "Country_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddress_CreatedBy_Id",
                table: "UserAddress",
                column: "CreatedBy_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddress_Login_Id",
                table: "UserAddress",
                column: "Login_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddress_ModifiedBy_Id",
                table: "UserAddress",
                column: "ModifiedBy_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddress_Region_Id",
                table: "UserAddress",
                column: "Region_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Address_Id",
                table: "Users",
                column: "Address_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddress_Users_CreatedBy_Id",
                table: "UserAddress",
                column: "CreatedBy_Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddress_Users_Login_Id",
                table: "UserAddress",
                column: "Login_Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddress_Users_ModifiedBy_Id",
                table: "UserAddress",
                column: "ModifiedBy_Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddress_Region_Region_Id",
                table: "UserAddress",
                column: "Region_Id",
                principalTable: "Region",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddress_Country_Country_Id",
                table: "UserAddress",
                column: "Country_Id",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddress_City_City_Id",
                table: "UserAddress",
                column: "City_Id",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_Users_CreatedBy_Id",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_City_Users_ModifiedBy_Id",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_Country_Users_CreatedBy_Id",
                table: "Country");

            migrationBuilder.DropForeignKey(
                name: "FK_Country_Users_ModifiedBy_Id",
                table: "Country");

            migrationBuilder.DropForeignKey(
                name: "FK_Region_Users_CreatedBy_Id",
                table: "Region");

            migrationBuilder.DropForeignKey(
                name: "FK_Region_Users_ModifiedBy_Id",
                table: "Region");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAddress_Users_CreatedBy_Id",
                table: "UserAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAddress_Users_Login_Id",
                table: "UserAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAddress_Users_ModifiedBy_Id",
                table: "UserAddress");

            migrationBuilder.DropTable(
                name: "Idea");

            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserAddress");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
