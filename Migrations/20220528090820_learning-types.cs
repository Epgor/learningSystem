using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace learningSystem.Migrations
{
    public partial class learningtypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LearningType",
                table: "Quizes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LearningType",
                table: "Articles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LearningType",
                table: "Quizes");

            migrationBuilder.DropColumn(
                name: "LearningType",
                table: "Articles");
        }
    }
}
