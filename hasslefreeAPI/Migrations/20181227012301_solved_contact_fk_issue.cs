using Microsoft.EntityFrameworkCore.Migrations;

namespace hasslefreeAPI.Migrations
{
    public partial class solved_contact_fk_issue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbo.Contacts_dbo.Accounts_AccountID",
                schema: "dbo",
                table: "Contacts");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_AccountID",
                schema: "dbo",
                table: "Contacts",
                column: "AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_dbo.Contacts_dbo.Accounts_AccountID",
                schema: "dbo",
                table: "Contacts",
                column: "AccountID",
                principalSchema: "dbo",
                principalTable: "Accounts",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbo.Contacts_dbo.Accounts_AccountID",
                schema: "dbo",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_AccountID",
                schema: "dbo",
                table: "Contacts");

            migrationBuilder.AddForeignKey(
                name: "FK_dbo.Contacts_dbo.Accounts_AccountID",
                schema: "dbo",
                table: "Contacts",
                column: "ContactID",
                principalSchema: "dbo",
                principalTable: "Accounts",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
