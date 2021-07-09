using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL_SERVICES.Migrations
{
    public partial class UniqueAccountNumberOnCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AccountNumber",
                schema: "dbo",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AccountNumber",
                schema: "dbo",
                table: "Customers",
                column: "AccountNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_AccountNumber",
                schema: "dbo",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "AccountNumber",
                schema: "dbo",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
