using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wordle.Api.Migrations
{
    /// <inheritdoc />
    public partial class AllowCascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DateWords_Words_WordId",
                table: "DateWords");

            migrationBuilder.AddForeignKey(
                name: "FK_DateWords_Words_WordId",
                table: "DateWords",
                column: "WordId",
                principalTable: "Words",
                principalColumn: "WordId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DateWords_Words_WordId",
                table: "DateWords");

            migrationBuilder.AddForeignKey(
                name: "FK_DateWords_Words_WordId",
                table: "DateWords",
                column: "WordId",
                principalTable: "Words",
                principalColumn: "WordId");
        }
    }
}
