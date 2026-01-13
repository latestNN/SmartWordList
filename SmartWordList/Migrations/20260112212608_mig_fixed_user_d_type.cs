using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartWordList.Migrations
{
    /// <inheritdoc />
    public partial class mig_fixed_user_d_type : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_partialWordLists_AspNetUsers_AppUserId1",
                table: "partialWordLists");

            migrationBuilder.DropForeignKey(
                name: "FK_WeekPartialWordLists_AspNetUsers_AppUserId1",
                table: "WeekPartialWordLists");

            migrationBuilder.DropForeignKey(
                name: "FK_wordLists_AspNetUsers_AppUserId1",
                table: "wordLists");

            migrationBuilder.DropIndex(
                name: "IX_wordLists_AppUserId1",
                table: "wordLists");

            migrationBuilder.DropIndex(
                name: "IX_WeekPartialWordLists_AppUserId1",
                table: "WeekPartialWordLists");

            migrationBuilder.DropIndex(
                name: "IX_partialWordLists_AppUserId1",
                table: "partialWordLists");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "wordLists");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "WeekPartialWordLists");

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
                table: "WeekPartialWordLists",
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
                name: "IX_WeekPartialWordLists_AppUserId",
                table: "WeekPartialWordLists",
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
                name: "FK_WeekPartialWordLists_AspNetUsers_AppUserId",
                table: "WeekPartialWordLists",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_partialWordLists_AspNetUsers_AppUserId",
                table: "partialWordLists");

            migrationBuilder.DropForeignKey(
                name: "FK_WeekPartialWordLists_AspNetUsers_AppUserId",
                table: "WeekPartialWordLists");

            migrationBuilder.DropForeignKey(
                name: "FK_wordLists_AspNetUsers_AppUserId",
                table: "wordLists");

            migrationBuilder.DropIndex(
                name: "IX_wordLists_AppUserId",
                table: "wordLists");

            migrationBuilder.DropIndex(
                name: "IX_WeekPartialWordLists_AppUserId",
                table: "WeekPartialWordLists");

            migrationBuilder.DropIndex(
                name: "IX_partialWordLists_AppUserId",
                table: "partialWordLists");

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
                table: "WeekPartialWordLists",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "WeekPartialWordLists",
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

            migrationBuilder.CreateIndex(
                name: "IX_wordLists_AppUserId1",
                table: "wordLists",
                column: "AppUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_WeekPartialWordLists_AppUserId1",
                table: "WeekPartialWordLists",
                column: "AppUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_partialWordLists_AppUserId1",
                table: "partialWordLists",
                column: "AppUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_partialWordLists_AspNetUsers_AppUserId1",
                table: "partialWordLists",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WeekPartialWordLists_AspNetUsers_AppUserId1",
                table: "WeekPartialWordLists",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_wordLists_AspNetUsers_AppUserId1",
                table: "wordLists",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
