using Microsoft.EntityFrameworkCore.Migrations;

namespace hasslefreeAPI.Migrations
{
    public partial class added_product_Type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "ProductType",
                schema: "dbo",
                table: "Products",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AlterColumn<int>(
                name: "AccountID",
                schema: "dbo",
                table: "Contacts",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductType",
                schema: "dbo",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "AccountID",
                schema: "dbo",
                table: "Contacts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
