using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wordle.Api.Migrations
{
    /// <inheritdoc />
    public partial class playid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Plays",
                table: "Plays");

            migrationBuilder.AddColumn<Guid>(
                name: "PlayId",
                table: "Plays",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plays",
                table: "Plays",
                column: "PlayId");

            migrationBuilder.CreateIndex(
                name: "IX_Plays_UserId",
                table: "Plays",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Plays",
                table: "Plays");

            migrationBuilder.DropIndex(
                name: "IX_Plays_UserId",
                table: "Plays");

            migrationBuilder.DropColumn(
                name: "PlayId",
                table: "Plays");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plays",
                table: "Plays",
                columns: new[] { "UserId", "WordId" });
        }
    }
}
