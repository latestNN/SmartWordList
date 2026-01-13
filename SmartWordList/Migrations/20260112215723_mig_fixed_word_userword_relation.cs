using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartWordList.Migrations
{
    /// <inheritdoc />
    public partial class mig_fixed_word_userword_relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_words_WeekPartialWordLists_WeekPartialWordListId",
                table: "words");

            migrationBuilder.DropIndex(
                name: "IX_words_WeekPartialWordListId",
                table: "words");

            migrationBuilder.DropColumn(
                name: "AskCount",
                table: "words");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "words");

            migrationBuilder.DropColumn(
                name: "IsAsked",
                table: "words");

            migrationBuilder.DropColumn(
                name: "LastAskedDate",
                table: "words");

            migrationBuilder.DropColumn(
                name: "SuccesPercent",
                table: "words");

            migrationBuilder.DropColumn(
                name: "SuccessAnswerCount",
                table: "words");

            migrationBuilder.DropColumn(
                name: "WeekPartialWordListId",
                table: "words");

            migrationBuilder.DropColumn(
                name: "WrongAnswerCount",
                table: "words");

            migrationBuilder.CreateTable(
                name: "userWords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SuccessAnswerCount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WrongAnswerCount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SuccesPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AskCount = table.Column<int>(type: "int", nullable: false),
                    IsAsked = table.Column<bool>(type: "bit", nullable: false),
                    LastAskedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WeekPartialWordListId = table.Column<int>(type: "int", nullable: true),
                    WordId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userWords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userWords_WeekPartialWordLists_WeekPartialWordListId",
                        column: x => x.WeekPartialWordListId,
                        principalTable: "WeekPartialWordLists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_userWords_words_WordId",
                        column: x => x.WordId,
                        principalTable: "words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_userWords_WeekPartialWordListId",
                table: "userWords",
                column: "WeekPartialWordListId");

            migrationBuilder.CreateIndex(
                name: "IX_userWords_WordId",
                table: "userWords",
                column: "WordId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "userWords");

            migrationBuilder.AddColumn<int>(
                name: "AskCount",
                table: "words",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "words",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsAsked",
                table: "words",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastAskedDate",
                table: "words",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SuccesPercent",
                table: "words",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SuccessAnswerCount",
                table: "words",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WeekPartialWordListId",
                table: "words",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "WrongAnswerCount",
                table: "words",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_words_WeekPartialWordListId",
                table: "words",
                column: "WeekPartialWordListId");

            migrationBuilder.AddForeignKey(
                name: "FK_words_WeekPartialWordLists_WeekPartialWordListId",
                table: "words",
                column: "WeekPartialWordListId",
                principalTable: "WeekPartialWordLists",
                principalColumn: "Id");
        }
    }
}
