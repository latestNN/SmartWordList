using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartWordList.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "wordLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Organisation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wordLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_wordLists_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "partialWordLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListLevel = table.Column<int>(type: "int", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Weak = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuccessAnswerCount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WrongAnswerCount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SuccesPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WordListId = table.Column<int>(type: "int", nullable: true),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_partialWordLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_partialWordLists_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_partialWordLists_wordLists_WordListId",
                        column: x => x.WordListId,
                        principalTable: "wordLists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "words",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EngWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Connective = table.Column<bool>(type: "bit", nullable: false),
                    WordListId = table.Column<int>(type: "int", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    SuccessAnswerCount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WrongAnswerCount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SuccesPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AskCount = table.Column<int>(type: "int", nullable: true),
                    IsAsked = table.Column<bool>(type: "bit", nullable: true),
                    LastAskedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PartialWordListId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_words", x => x.Id);
                    table.ForeignKey(
                        name: "FK_words_partialWordLists_PartialWordListId",
                        column: x => x.PartialWordListId,
                        principalTable: "partialWordLists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_words_wordLists_WordListId",
                        column: x => x.WordListId,
                        principalTable: "wordLists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "trMeans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mean = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WordId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trMeans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_trMeans_words_WordId",
                        column: x => x.WordId,
                        principalTable: "words",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_partialWordLists_AppUserId",
                table: "partialWordLists",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_partialWordLists_WordListId",
                table: "partialWordLists",
                column: "WordListId");

            migrationBuilder.CreateIndex(
                name: "IX_trMeans_WordId",
                table: "trMeans",
                column: "WordId");

            migrationBuilder.CreateIndex(
                name: "IX_wordLists_AppUserId",
                table: "wordLists",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_words_PartialWordListId",
                table: "words",
                column: "PartialWordListId");

            migrationBuilder.CreateIndex(
                name: "IX_words_WordListId",
                table: "words",
                column: "WordListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "trMeans");

            migrationBuilder.DropTable(
                name: "words");

            migrationBuilder.DropTable(
                name: "partialWordLists");

            migrationBuilder.DropTable(
                name: "wordLists");
        }
    }
}
