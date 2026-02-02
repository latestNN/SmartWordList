using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartWordList.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_words_partialWordLists_PartialWordListId",
                table: "words");

            migrationBuilder.DropIndex(
                name: "IX_words_PartialWordListId",
                table: "words");

            migrationBuilder.DropColumn(
                name: "PartialWordListId",
                table: "words");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PartialWordListId",
                table: "words",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_words_PartialWordListId",
                table: "words",
                column: "PartialWordListId");

            migrationBuilder.AddForeignKey(
                name: "FK_words_partialWordLists_PartialWordListId",
                table: "words",
                column: "PartialWordListId",
                principalTable: "partialWordLists",
                principalColumn: "Id");
        }
    }
}
