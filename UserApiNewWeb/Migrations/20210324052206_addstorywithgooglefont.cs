using Microsoft.EntityFrameworkCore.Migrations;

namespace UserApiNewWeb.Migrations
{
    public partial class addstorywithgooglefont : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoogleFontId",
                table: "Stories");

            migrationBuilder.AddColumn<int>(
                name: "GoogleFontsId",
                table: "Stories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stories_GoogleFontsId",
                table: "Stories",
                column: "GoogleFontsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stories_GoogleFonts_GoogleFontsId",
                table: "Stories",
                column: "GoogleFontsId",
                principalTable: "GoogleFonts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stories_GoogleFonts_GoogleFontsId",
                table: "Stories");

            migrationBuilder.DropIndex(
                name: "IX_Stories_GoogleFontsId",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "GoogleFontsId",
                table: "Stories");

            migrationBuilder.AddColumn<int>(
                name: "GoogleFontId",
                table: "Stories",
                nullable: false,
                defaultValue: 0);
        }
    }
}
