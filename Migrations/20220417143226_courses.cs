using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace learningSystem.Migrations
{
    public partial class courses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoursesDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursesDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_CoursesDetail_CourseId",
                        column: x => x.CourseId,
                        principalTable: "CoursesDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoursesMain",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EyeId = table.Column<int>(type: "int", nullable: true),
                    EarId = table.Column<int>(type: "int", nullable: true),
                    WorkId = table.Column<int>(type: "int", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursesMain", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoursesMain_CoursesDetail_EarId",
                        column: x => x.EarId,
                        principalTable: "CoursesDetail",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CoursesMain_CoursesDetail_EyeId",
                        column: x => x.EyeId,
                        principalTable: "CoursesDetail",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CoursesMain_CoursesDetail_WorkId",
                        column: x => x.WorkId,
                        principalTable: "CoursesDetail",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Quizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quizes_CoursesDetail_CourseId",
                        column: x => x.CourseId,
                        principalTable: "CoursesDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToDisplay = table.Column<bool>(type: "bit", nullable: false),
                    articleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseFiles_Articles_articleId",
                        column: x => x.articleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    quizId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Quizes_quizId",
                        column: x => x.quizId,
                        principalTable: "Quizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: true),
                    questionId = table.Column<int>(type: "int", nullable: false),
                    quesitonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_questionId",
                        column: x => x.questionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_questionId",
                table: "Answers",
                column: "questionId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CourseId",
                table: "Articles",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseFiles_articleId",
                table: "CourseFiles",
                column: "articleId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Questions_quizId",
                table: "Questions",
                column: "quizId");

            migrationBuilder.CreateIndex(
                name: "IX_Quizes_CourseId",
                table: "Quizes",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "CourseFiles");

            migrationBuilder.DropTable(
                name: "CoursesMain");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Quizes");

            migrationBuilder.DropTable(
                name: "CoursesDetail");
        }
    }
}
