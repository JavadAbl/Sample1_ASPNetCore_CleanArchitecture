using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cleaners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<int>(type: "INTEGER", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cleaners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<int>(type: "INTEGER", nullable: false),
                    Bed = table.Column<int>(type: "INTEGER", nullable: false),
                    Capacity = table.Column<int>(type: "INTEGER", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PassNumber = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Mobile = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Address_Street = table.Column<string>(type: "TEXT", nullable: true),
                    Address_City = table.Column<string>(type: "TEXT", nullable: true),
                    Address_State = table.Column<string>(type: "TEXT", nullable: true),
                    Address_PostalCode = table.Column<string>(type: "TEXT", nullable: true),
                    Address_Country = table.Column<string>(type: "TEXT", nullable: true),
                    RoomId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Guests_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomCleaners",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "INTEGER", nullable: false),
                    CleanerId = table.Column<int>(type: "INTEGER", nullable: false),
                    RoomId1 = table.Column<int>(type: "INTEGER", nullable: false),
                    CleanerId1 = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomCleaners", x => new { x.RoomId, x.CleanerId });
                    table.ForeignKey(
                        name: "FK_RoomCleaners_Cleaners_CleanerId",
                        column: x => x.CleanerId,
                        principalTable: "Cleaners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomCleaners_Cleaners_CleanerId1",
                        column: x => x.CleanerId1,
                        principalTable: "Cleaners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomCleaners_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomCleaners_Rooms_RoomId1",
                        column: x => x.RoomId1,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Guests_RoomId",
                table: "Guests",
                column: "RoomId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoomCleaners_CleanerId",
                table: "RoomCleaners",
                column: "CleanerId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomCleaners_CleanerId1",
                table: "RoomCleaners",
                column: "CleanerId1");

            migrationBuilder.CreateIndex(
                name: "IX_RoomCleaners_RoomId1",
                table: "RoomCleaners",
                column: "RoomId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "RoomCleaners");

            migrationBuilder.DropTable(
                name: "Cleaners");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
