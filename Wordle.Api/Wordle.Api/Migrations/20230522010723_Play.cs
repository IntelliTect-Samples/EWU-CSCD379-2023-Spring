using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wordle.Api.Migrations
{
    /// <inheritdoc />
    public partial class Play : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plays",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HasPlayed = table.Column<bool>(type: "bit", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    DailyWordDateWordId = table.Column<int>(type: "int", nullable: true),
                    GameDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NumberOfPlays = table.Column<int>(type: "int", nullable: false),
                    AvgScore = table.Column<int>(type: "int", nullable: false),
                    AvgTime = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plays_DateWords_DailyWordDateWordId",
                        column: x => x.DailyWordDateWordId,
                        principalTable: "DateWords",
                        principalColumn: "DateWordId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plays_DailyWordDateWordId",
                table: "Plays",
                column: "DailyWordDateWordId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plays");
        }
    }
}
