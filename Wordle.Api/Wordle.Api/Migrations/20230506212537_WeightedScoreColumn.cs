using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wordle.Api.Migrations
{
    /// <inheritdoc />
    public partial class WeightedScoreColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AveargeSecondsPerGame",
                table: "Players",
                newName: "AverageSecondsPerGame");

            migrationBuilder.AddColumn<double>(
                name: "WeightedScore",
                table: "Players",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WeightedScore",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "AverageSecondsPerGame",
                table: "Players",
                newName: "AveargeSecondsPerGame");
        }
    }
}
