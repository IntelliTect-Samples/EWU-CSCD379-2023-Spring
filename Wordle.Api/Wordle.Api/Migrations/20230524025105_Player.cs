﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wordle.Api.Migrations
{
    /// <inheritdoc />
    public partial class Player : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new { PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                                        PlayerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                                        GameCount = table.Column<int>(type: "int", nullable: false),
                                        TotalSecondsPerGame = table.Column<int>(type: "int", nullable: false),
                                        AverageSecondsPerGame = table.Column<int>(type: "int", nullable: false),
                                        TotalAttempts = table.Column<double>(type: "float", nullable: false),
                                        AverageAttempts = table.Column<double>(type: "float", nullable: false) },
                constraints: table =>
                { table.PrimaryKey("PK_Players", x => x.PlayerId); });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Players");
        }
    }
}
