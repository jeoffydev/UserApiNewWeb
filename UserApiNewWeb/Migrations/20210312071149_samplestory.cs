using Microsoft.EntityFrameworkCore.Migrations;

namespace UserApiNewWeb.Migrations
{
    public partial class samplestory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Stories (MyStory) VALUES('My Story 1')");
            migrationBuilder.Sql("INSERT INTO Stories (MyStory) VALUES('My Story 2')");
            migrationBuilder.Sql("INSERT INTO Stories (MyStory) VALUES('My Story 3')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
