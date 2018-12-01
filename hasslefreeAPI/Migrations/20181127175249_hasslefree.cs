using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace hasslefreeAPI.Migrations
{
    public partial class hasslefree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                schema: "dbo",
                columns: table => new
                {
                    AccountID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(maxLength: 50, nullable: true),
                    AccountName = table.Column<string>(nullable: false),
                    Website = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Turnover = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    IndustryID = table.Column<short>(nullable: true),
                    IndustrySubTypeID = table.Column<short>(nullable: true),
                    LeadSource = table.Column<short>(nullable: true),
                    WorkPhone_Main = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    WorkPhone_Alternate = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Employees = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    ParentID = table.Column<int>(nullable: true),
                    CampaignID = table.Column<int>(nullable: true),
                    DetailDescription = table.Column<string>(nullable: true),
                    FlagActive = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountID);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                schema: "dbo",
                columns: table => new
                {
                    ActivityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActivityTypeId = table.Column<short>(nullable: false),
                    ActivitySubTypeId = table.Column<short>(nullable: false),
                    ActivityTitle = table.Column<string>(nullable: false),
                    ActivityStartTime = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    ActivityEndTime = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    ActivityLocation = table.Column<string>(nullable: false),
                    StatusId = table.Column<short>(nullable: false),
                    ActivityOwner = table.Column<int>(nullable: true),
                    Source = table.Column<int>(nullable: true),
                    ReferenceID = table.Column<int>(nullable: true),
                    FlagActive = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.ActivityId);
                });

            migrationBuilder.CreateTable(
                name: "Competitors",
                schema: "dbo",
                columns: table => new
                {
                    CompetitorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(unicode: false, nullable: true),
                    Amount = table.Column<decimal>(type: "money", nullable: true),
                    Remarks = table.Column<string>(unicode: false, nullable: true),
                    Source = table.Column<int>(nullable: true),
                    RefernceId = table.Column<int>(nullable: true),
                    FlagActive = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitors", x => x.CompetitorId);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                schema: "dbo",
                columns: table => new
                {
                    DocumentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FileName = table.Column<string>(nullable: false),
                    Type = table.Column<string>(maxLength: 50, nullable: true),
                    Source = table.Column<int>(nullable: true),
                    ReferenceId = table.Column<int>(nullable: true),
                    FlagActive = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.DocumentId);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                schema: "dbo",
                columns: table => new
                {
                    NotesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActivityId = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: false),
                    FlagActive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.NotesId);
                });

            migrationBuilder.CreateTable(
                name: "ProductList",
                schema: "dbo",
                columns: table => new
                {
                    ProductListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<short>(nullable: true),
                    UOM = table.Column<short>(nullable: true),
                    Rate = table.Column<decimal>(type: "money", nullable: true),
                    Discount = table.Column<double>(nullable: true),
                    TaxAmount = table.Column<decimal>(type: "money", nullable: true),
                    Amount = table.Column<decimal>(type: "money", nullable: true),
                    Source = table.Column<int>(nullable: true),
                    ReferenceID = table.Column<int>(nullable: true),
                    FlagActive = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductList", x => x.ProductListId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "dbo",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(unicode: false, nullable: true),
                    Rate = table.Column<decimal>(type: "money", nullable: true),
                    FlagActive = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "ReferenceLookup",
                schema: "dbo",
                columns: table => new
                {
                    ReferenceLookupID = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(maxLength: 50, nullable: false),
                    OrderId = table.Column<short>(nullable: true),
                    Category = table.Column<string>(maxLength: 50, nullable: false),
                    SubCategory = table.Column<string>(maxLength: 50, nullable: true),
                    FlagActive = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferenceLookup", x => x.ReferenceLookupID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "dbo",
                columns: table => new
                {
                    AddressID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<int>(nullable: true),
                    AccountID = table.Column<int>(nullable: false),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    AddressLine3 = table.Column<string>(nullable: true),
                    City = table.Column<string>(maxLength: 50, nullable: true),
                    State = table.Column<string>(maxLength: 50, nullable: true),
                    Pincode = table.Column<string>(maxLength: 50, nullable: true),
                    Country = table.Column<string>(maxLength: 50, nullable: true),
                    Landmark = table.Column<string>(maxLength: 100, nullable: true),
                    Remarks = table.Column<string>(maxLength: 100, nullable: true),
                    FlagActive = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressID);
                    table.ForeignKey(
                        name: "FK_dbo.Address_dbo.Accounts_AccountID",
                        column: x => x.AccountID,
                        principalSchema: "dbo",
                        principalTable: "Accounts",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                schema: "dbo",
                columns: table => new
                {
                    ContactID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountID = table.Column<int>(nullable: false),
                    ContactFirstName = table.Column<string>(unicode: false, nullable: true),
                    ContactLastName = table.Column<string>(unicode: false, nullable: true),
                    GenderID = table.Column<int>(nullable: false),
                    Designation = table.Column<string>(unicode: false, nullable: true),
                    Department = table.Column<string>(unicode: false, nullable: true),
                    AddressLine1 = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    AddressLine2 = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    AddressLine3 = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    City = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    State = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    PostalCode = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Country = table.Column<short>(nullable: true),
                    Email = table.Column<string>(unicode: false, nullable: true),
                    WorkPhone = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    MobilePhone = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Facebook = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Twitter = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    GooglePlus = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: true),
                    ContactTypeId = table.Column<short>(nullable: true),
                    CampaignID = table.Column<int>(nullable: true),
                    FlagActive = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactID);
                    table.ForeignKey(
                        name: "FK_dbo.Contacts_dbo.Accounts_AccountID",
                        column: x => x.ContactID,
                        principalSchema: "dbo",
                        principalTable: "Accounts",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Leads",
                schema: "dbo",
                columns: table => new
                {
                    LeadId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    Salutation = table.Column<short>(nullable: true),
                    LeadFirstName = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    LeadLastName = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    LeadDate = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    Email = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    SalesStage = table.Column<short>(nullable: true),
                    LeadOwnerExecutiveId = table.Column<int>(nullable: true),
                    WorkPhone = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    MobilePhone = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    AddressLine1 = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    AddressLine2 = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    AddressLine3 = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    City = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    State = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    PostalCode = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Country = table.Column<short>(nullable: true),
                    CompanyName = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    CompanyAddressLine1 = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    CompanyAddressLine2 = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    CompanyAddressLine3 = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    CompanyCity = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CompanyState = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CompanyPostalCode = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CompanyCountry = table.Column<short>(nullable: true),
                    CompanyWebsite = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    CompanyTurnover = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    IndustryID = table.Column<short>(nullable: true),
                    IndustrySubTypeID = table.Column<short>(nullable: true),
                    LeadSource = table.Column<short>(nullable: true),
                    DetailDescription = table.Column<string>(nullable: true),
                    ContactID = table.Column<int>(nullable: true),
                    OpportunityID = table.Column<int>(nullable: true),
                    AccountID = table.Column<int>(nullable: true),
                    CONVERTED = table.Column<bool>(nullable: true),
                    FlagActive = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leads", x => x.LeadId);
                    table.ForeignKey(
                        name: "FK_dbo.Leads_dbo.Accounts_AccountID",
                        column: x => x.AccountID,
                        principalSchema: "dbo",
                        principalTable: "Accounts",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Address_AccountID",
                schema: "dbo",
                table: "Address",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_AccountID",
                schema: "dbo",
                table: "Leads",
                column: "AccountID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Activities",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Address",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Competitors",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Contacts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Documents",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Leads",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Notes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ProductList",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ReferenceLookup",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Accounts",
                schema: "dbo");
        }
    }
}
