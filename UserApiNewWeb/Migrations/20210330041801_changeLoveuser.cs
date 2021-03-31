using Microsoft.EntityFrameworkCore.Migrations;

namespace UserApiNewWeb.Migrations
{
    public partial class changeLoveuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Loves_UserId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Loves",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Loves_UserId",
                table: "Loves",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loves_AspNetUsers_UserId",
                table: "Loves",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loves_AspNetUsers_UserId",
                table: "Loves");

            migrationBuilder.DropIndex(
                name: "IX_Loves_UserId",
                table: "Loves");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Loves",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserId",
                table: "AspNetUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Loves_UserId",
                table: "AspNetUsers",
                column: "UserId",
                principalTable: "Loves",
                principalColumn: "LoveId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
