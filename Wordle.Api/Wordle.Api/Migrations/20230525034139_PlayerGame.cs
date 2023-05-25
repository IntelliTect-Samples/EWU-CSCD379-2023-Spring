using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wordle.Api.Migrations
{
    /// <inheritdoc />
    public partial class PlayerGame : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DateWords_Words_WordId",
                table: "DateWords");

            migrationBuilder.CreateTable(
                name: "PlayerGames",
                columns: table => new
                {
                    PlayerGameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WordId = table.Column<int>(type: "int", nullable: false),
                    DateWordId = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Attempts = table.Column<int>(type: "int", nullable: false),
                    DurationInSeconds = table.Column<int>(type: "int", nullable: false),
                    WasGameWon = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerGames", x => x.PlayerGameId);
                    table.ForeignKey(
                        name: "FK_PlayerGames_DateWords_DateWordId",
                        column: x => x.DateWordId,
                        principalTable: "DateWords",
                        principalColumn: "DateWordId");
                    table.ForeignKey(
                        name: "FK_PlayerGames_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerGames_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "WordId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DateWords_Date",
                table: "DateWords",
                column: "Date",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGames_DateWordId",
                table: "PlayerGames",
                column: "DateWordId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGames_PlayerId",
                table: "PlayerGames",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGames_WordId",
                table: "PlayerGames",
                column: "WordId");

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

            migrationBuilder.DropTable(
                name: "PlayerGames");

            migrationBuilder.DropIndex(
                name: "IX_DateWords_Date",
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
