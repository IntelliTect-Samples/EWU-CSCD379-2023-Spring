using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wordle.Api.Migrations
{
    /// <inheritdoc />
    public partial class PlayerNoTotals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "TotalAttempts", table: "Players");

            migrationBuilder.DropColumn(name: "TotalSecondsPerGame", table: "Players");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(name: "TotalAttempts",
                                               table: "Players",
                                               type: "float",
                                               nullable: false,
                                               defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(name: "TotalSecondsPerGame",
                                            table: "Players",
                                            type: "int",
                                            nullable: false,
                                            defaultValue: 0);
        }
    }
}
