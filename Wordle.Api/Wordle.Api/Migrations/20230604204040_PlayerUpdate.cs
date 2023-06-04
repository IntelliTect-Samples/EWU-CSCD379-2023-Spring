using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wordle.Api.Migrations
{
    /// <inheritdoc />
    public partial class PlayerUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "MasterOfTheUniverse",
                table: "Players",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "birthday",
                table: "Players",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MasterOfTheUniverse",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "birthday",
                table: "Players");
        }
    }
}
