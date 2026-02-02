using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartWordList.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PartialWordListId",
                table: "WeekPartialWordLists",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeekPartialWordLists_PartialWordListId",
                table: "WeekPartialWordLists",
                column: "PartialWordListId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeekPartialWordLists_partialWordLists_PartialWordListId",
                table: "WeekPartialWordLists",
                column: "PartialWordListId",
                principalTable: "partialWordLists",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeekPartialWordLists_partialWordLists_PartialWordListId",
                table: "WeekPartialWordLists");

            migrationBuilder.DropIndex(
                name: "IX_WeekPartialWordLists_PartialWordListId",
                table: "WeekPartialWordLists");

            migrationBuilder.DropColumn(
                name: "PartialWordListId",
                table: "WeekPartialWordLists");
        }
    }
}
