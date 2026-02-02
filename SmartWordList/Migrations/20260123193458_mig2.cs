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
            migrationBuilder.DropForeignKey(
                name: "FK_wordLists_AspNetUsers_AppUserId",
                table: "wordLists");

            migrationBuilder.DropIndex(
                name: "IX_wordLists_AppUserId",
                table: "wordLists");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "wordLists");

            migrationBuilder.AddColumn<int>(
                name: "PartialWordListId",
                table: "userWords",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_userWords_PartialWordListId",
                table: "userWords",
                column: "PartialWordListId");

            migrationBuilder.AddForeignKey(
                name: "FK_userWords_partialWordLists_PartialWordListId",
                table: "userWords",
                column: "PartialWordListId",
                principalTable: "partialWordLists",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userWords_partialWordLists_PartialWordListId",
                table: "userWords");

            migrationBuilder.DropIndex(
                name: "IX_userWords_PartialWordListId",
                table: "userWords");

            migrationBuilder.DropColumn(
                name: "PartialWordListId",
                table: "userWords");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "wordLists",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_wordLists_AppUserId",
                table: "wordLists",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_wordLists_AspNetUsers_AppUserId",
                table: "wordLists",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
