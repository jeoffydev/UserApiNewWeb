using Microsoft.EntityFrameworkCore.Migrations;

namespace UserApiNewWeb.Migrations
{
    public partial class addtitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Stories",
                maxLength: 255,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Stories");
        }
    }
}
