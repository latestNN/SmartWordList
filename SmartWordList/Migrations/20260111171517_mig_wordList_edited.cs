using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartWordList.Migrations
{
    /// <inheritdoc />
    public partial class mig_wordList_edited : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LogoUrl",
                table: "wordLists",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogoUrl",
                table: "wordLists");
        }
    }
}
