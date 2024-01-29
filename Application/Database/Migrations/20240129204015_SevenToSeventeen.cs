using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoomCoder.Application.Database.Migrations
{
    /// <inheritdoc />
    public partial class SevenToSeventeen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "code10",
                table: "room_codes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "code11",
                table: "room_codes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "code12",
                table: "room_codes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "code13",
                table: "room_codes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "code14",
                table: "room_codes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "code15",
                table: "room_codes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "code16",
                table: "room_codes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "code17",
                table: "room_codes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "code8",
                table: "room_codes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "code9",
                table: "room_codes",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "code10",
                table: "room_codes");

            migrationBuilder.DropColumn(
                name: "code11",
                table: "room_codes");

            migrationBuilder.DropColumn(
                name: "code12",
                table: "room_codes");

            migrationBuilder.DropColumn(
                name: "code13",
                table: "room_codes");

            migrationBuilder.DropColumn(
                name: "code14",
                table: "room_codes");

            migrationBuilder.DropColumn(
                name: "code15",
                table: "room_codes");

            migrationBuilder.DropColumn(
                name: "code16",
                table: "room_codes");

            migrationBuilder.DropColumn(
                name: "code17",
                table: "room_codes");

            migrationBuilder.DropColumn(
                name: "code8",
                table: "room_codes");

            migrationBuilder.DropColumn(
                name: "code9",
                table: "room_codes");
        }
    }
}
