using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace learningSystem.Migrations
{
    public partial class databaserefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_CoursesDetail_CourseId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_CoursesMain_CoursesDetail_EarId",
                table: "CoursesMain");

            migrationBuilder.DropForeignKey(
                name: "FK_CoursesMain_CoursesDetail_EyeId",
                table: "CoursesMain");

            migrationBuilder.DropForeignKey(
                name: "FK_CoursesMain_CoursesDetail_WorkId",
                table: "CoursesMain");

            migrationBuilder.DropForeignKey(
                name: "FK_Quizes_CoursesDetail_CourseId",
                table: "Quizes");

            migrationBuilder.DropTable(
                name: "CoursesDetail");

            migrationBuilder.DropIndex(
                name: "IX_CoursesMain_EarId",
                table: "CoursesMain");

            migrationBuilder.DropIndex(
                name: "IX_CoursesMain_EyeId",
                table: "CoursesMain");

            migrationBuilder.DropIndex(
                name: "IX_CoursesMain_WorkId",
                table: "CoursesMain");

            migrationBuilder.DropColumn(
                name: "EarId",
                table: "CoursesMain");

            migrationBuilder.DropColumn(
                name: "EyeId",
                table: "CoursesMain");

            migrationBuilder.DropColumn(
                name: "WorkId",
                table: "CoursesMain");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_CoursesMain_CourseId",
                table: "Articles",
                column: "CourseId",
                principalTable: "CoursesMain",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quizes_CoursesMain_CourseId",
                table: "Quizes",
                column: "CourseId",
                principalTable: "CoursesMain",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_CoursesMain_CourseId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Quizes_CoursesMain_CourseId",
                table: "Quizes");

            migrationBuilder.AddColumn<int>(
                name: "EarId",
                table: "CoursesMain",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EyeId",
                table: "CoursesMain",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkId",
                table: "CoursesMain",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CoursesDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursesDetail", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoursesMain_EarId",
                table: "CoursesMain",
                column: "EarId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesMain_EyeId",
                table: "CoursesMain",
                column: "EyeId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesMain_WorkId",
                table: "CoursesMain",
                column: "WorkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_CoursesDetail_CourseId",
                table: "Articles",
                column: "CourseId",
                principalTable: "CoursesDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoursesMain_CoursesDetail_EarId",
                table: "CoursesMain",
                column: "EarId",
                principalTable: "CoursesDetail",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CoursesMain_CoursesDetail_EyeId",
                table: "CoursesMain",
                column: "EyeId",
                principalTable: "CoursesDetail",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CoursesMain_CoursesDetail_WorkId",
                table: "CoursesMain",
                column: "WorkId",
                principalTable: "CoursesDetail",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Quizes_CoursesDetail_CourseId",
                table: "Quizes",
                column: "CourseId",
                principalTable: "CoursesDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
