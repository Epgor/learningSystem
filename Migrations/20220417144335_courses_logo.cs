using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace learningSystem.Migrations
{
    public partial class courses_logo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LogoURL",
                table: "CoursesMain",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogoURL",
                table: "CoursesMain");
        }
    }
}
