using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wordle.Api.Migrations
{
    /// <inheritdoc />
    public partial class Plays6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plays_Players_PlayerId1",
                table: "Plays");

            migrationBuilder.DropIndex(
                name: "IX_Plays_PlayerId1",
                table: "Plays");

            migrationBuilder.DropColumn(
                name: "PlayerId1",
                table: "Plays");

            migrationBuilder.AlterColumn<Guid>(
                name: "PlayerId",
                table: "Players",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_Plays_PlayerId",
                table: "Plays",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plays_Players_PlayerId",
                table: "Plays",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plays_Players_PlayerId",
                table: "Plays");

            migrationBuilder.DropIndex(
                name: "IX_Plays_PlayerId",
                table: "Plays");

            migrationBuilder.AddColumn<int>(
                name: "PlayerId1",
                table: "Plays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "Players",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_Plays_PlayerId1",
                table: "Plays",
                column: "PlayerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Plays_Players_PlayerId1",
                table: "Plays",
                column: "PlayerId1",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
