using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wordle.Api.Migrations
{
/// <inheritdoc />
public partial class DateWord : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "DateWords",
            columns: table =>
                new { DateWordId = table.Column<int>(type: "int", nullable: false)
                                       .Annotation("SqlServer:Identity", "1, 1"),
                      Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                      WordId = table.Column<int>(type: "int", nullable: false) },
            constraints: table =>
            {
                table.PrimaryKey("PK_DateWords", x => x.DateWordId);
                table.ForeignKey(name: "FK_DateWords_Words_WordId", column: x => x.WordId,
                                 principalTable: "Words", principalColumn: "WordId");
            });

        migrationBuilder.CreateTable(
            name: "PlayerGames",
            columns: table =>
                new { PlayerGameId = table.Column<int>(type: "int", nullable: false)
                                         .Annotation("SqlServer:Identity", "1, 1"),
                      PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                      WordId = table.Column<int>(type: "int", nullable: false),
                      DateWordId = table.Column<int>(type: "int", nullable: true),
                      Attempts = table.Column<int>(type: "int", nullable: false),
                      DurationInSeconds = table.Column<int>(type: "int", nullable: false),
                      Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                      WasGameWon = table.Column<bool>(type: "bit", nullable: false) },
            constraints: table =>
            {
                table.PrimaryKey("PK_PlayerGames", x => x.PlayerGameId);
                table.ForeignKey(name: "FK_PlayerGames_DateWords_DateWordId",
                                 column: x => x.DateWordId, principalTable: "DateWords",
                                 principalColumn: "DateWordId");
                table.ForeignKey(name: "FK_PlayerGames_Players_PlayerId", column: x => x.PlayerId,
                                 principalTable: "Players", principalColumn: "PlayerId",
                                 onDelete: ReferentialAction.Cascade);
                table.ForeignKey(name: "FK_PlayerGames_Words_WordId", column: x => x.WordId,
                                 principalTable: "Words", principalColumn: "WordId",
                                 onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(name: "IX_DateWords_Date", table: "DateWords", column: "Date",
                                     unique: true);

        migrationBuilder.CreateIndex(name: "IX_DateWords_WordId", table: "DateWords",
                                     column: "WordId");

        migrationBuilder.CreateIndex(name: "IX_PlayerGames_DateWordId", table: "PlayerGames",
                                     column: "DateWordId");

        migrationBuilder.CreateIndex(name: "IX_PlayerGames_PlayerId", table: "PlayerGames",
                                     column: "PlayerId");

        migrationBuilder.CreateIndex(name: "IX_PlayerGames_WordId", table: "PlayerGames",
                                     column: "WordId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(name: "PlayerGames");

        migrationBuilder.DropTable(name: "DateWords");
    }
}
}
