using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL_SERVICES.Migrations
{
    public partial class UpdatedCategoryIdInCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                schema: "dbo",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                computedColumnSql: "'CATE' + ' ' + [Id]",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                schema: "dbo",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComputedColumnSql: "'CATE' + ' ' + [Id]");
        }
    }
}
