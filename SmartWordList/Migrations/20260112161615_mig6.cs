using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartWordList.Migrations
{
    /// <inheritdoc />
    public partial class mig6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_partialWordLists_AspNetUsers_AppUserId",
                table: "partialWordLists");

            migrationBuilder.DropForeignKey(
                name: "FK_wordLists_AspNetUsers_AppUserId",
                table: "wordLists");

            migrationBuilder.DropIndex(
                name: "IX_wordLists_AppUserId",
                table: "wordLists");

            migrationBuilder.DropIndex(
                name: "IX_partialWordLists_AppUserId",
                table: "partialWordLists");

            migrationBuilder.AddColumn<int>(
                name: "WeekPartialWordListId",
                table: "words",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "wordLists",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "wordLists",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "partialWordLists",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "partialWordLists",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WeekPartialWordLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WeekNumber = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: true),
                    AppUserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekPartialWordLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeekPartialWordLists_AspNetUsers_AppUserId1",
                        column: x => x.AppUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_words_WeekPartialWordListId",
                table: "words",
                column: "WeekPartialWordListId");

            migrationBuilder.CreateIndex(
                name: "IX_wordLists_AppUserId1",
                table: "wordLists",
                column: "AppUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_partialWordLists_AppUserId1",
                table: "partialWordLists",
                column: "AppUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_WeekPartialWordLists_AppUserId1",
                table: "WeekPartialWordLists",
                column: "AppUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_partialWordLists_AspNetUsers_AppUserId1",
                table: "partialWordLists",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_wordLists_AspNetUsers_AppUserId1",
                table: "wordLists",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_words_WeekPartialWordLists_WeekPartialWordListId",
                table: "words",
                column: "WeekPartialWordListId",
                principalTable: "WeekPartialWordLists",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_partialWordLists_AspNetUsers_AppUserId1",
                table: "partialWordLists");

            migrationBuilder.DropForeignKey(
                name: "FK_wordLists_AspNetUsers_AppUserId1",
                table: "wordLists");

            migrationBuilder.DropForeignKey(
                name: "FK_words_WeekPartialWordLists_WeekPartialWordListId",
                table: "words");

            migrationBuilder.DropTable(
                name: "WeekPartialWordLists");

            migrationBuilder.DropIndex(
                name: "IX_words_WeekPartialWordListId",
                table: "words");

            migrationBuilder.DropIndex(
                name: "IX_wordLists_AppUserId1",
                table: "wordLists");

            migrationBuilder.DropIndex(
                name: "IX_partialWordLists_AppUserId1",
                table: "partialWordLists");

            migrationBuilder.DropColumn(
                name: "WeekPartialWordListId",
                table: "words");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "wordLists");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "partialWordLists");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "wordLists",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "partialWordLists",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_wordLists_AppUserId",
                table: "wordLists",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_partialWordLists_AppUserId",
                table: "partialWordLists",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_partialWordLists_AspNetUsers_AppUserId",
                table: "partialWordLists",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_wordLists_AspNetUsers_AppUserId",
                table: "wordLists",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
