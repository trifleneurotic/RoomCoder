using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoomCoder.Application.Database.Migrations
{
    /// <inheritdoc />
    public partial class FirstModification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "current_codes",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    room_number = table.Column<byte>(type: "INTEGER", nullable: false),
                    current_code_number = table.Column<ushort>(type: "INTEGER", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_current_codes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "room_codes",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    code01 = table.Column<ushort>(type: "INTEGER", nullable: false),
                    code02 = table.Column<ushort>(type: "INTEGER", nullable: false),
                    code03 = table.Column<ushort>(type: "INTEGER", nullable: false),
                    code04 = table.Column<ushort>(type: "INTEGER", nullable: false),
                    code05 = table.Column<ushort>(type: "INTEGER", nullable: false),
                    code06 = table.Column<ushort>(type: "INTEGER", nullable: false),
                    code07 = table.Column<ushort>(type: "INTEGER", nullable: false),
                    code08 = table.Column<ushort>(type: "INTEGER", nullable: false),
                    code09 = table.Column<ushort>(type: "INTEGER", nullable: false),
                    code10 = table.Column<ushort>(type: "INTEGER", nullable: false),
                    code11 = table.Column<ushort>(type: "INTEGER", nullable: false),
                    code12 = table.Column<ushort>(type: "INTEGER", nullable: false),
                    code13 = table.Column<ushort>(type: "INTEGER", nullable: false),
                    code14 = table.Column<ushort>(type: "INTEGER", nullable: false),
                    code15 = table.Column<ushort>(type: "INTEGER", nullable: false),
                    code16 = table.Column<ushort>(type: "INTEGER", nullable: false),
                    code17 = table.Column<ushort>(type: "INTEGER", nullable: false),
                    code18 = table.Column<ushort>(type: "INTEGER", nullable: false),
                    code19 = table.Column<ushort>(type: "INTEGER", nullable: false),
                    room_number = table.Column<byte>(type: "INTEGER", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_room_codes", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "current_codes");

            migrationBuilder.DropTable(
                name: "room_codes");
        }
    }
}
