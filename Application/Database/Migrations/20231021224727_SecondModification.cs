using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoomCoder.Application.Database.Migrations
{
    /// <inheritdoc />
    public partial class SecondModification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "code09",
                table: "room_codes",
                newName: "code9");

            migrationBuilder.RenameColumn(
                name: "code08",
                table: "room_codes",
                newName: "code8");

            migrationBuilder.RenameColumn(
                name: "code07",
                table: "room_codes",
                newName: "code7");

            migrationBuilder.RenameColumn(
                name: "code06",
                table: "room_codes",
                newName: "code6");

            migrationBuilder.RenameColumn(
                name: "code05",
                table: "room_codes",
                newName: "code5");

            migrationBuilder.RenameColumn(
                name: "code04",
                table: "room_codes",
                newName: "code4");

            migrationBuilder.RenameColumn(
                name: "code03",
                table: "room_codes",
                newName: "code3");

            migrationBuilder.RenameColumn(
                name: "code02",
                table: "room_codes",
                newName: "code2");

            migrationBuilder.RenameColumn(
                name: "code01",
                table: "room_codes",
                newName: "code1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "code9",
                table: "room_codes",
                newName: "code09");

            migrationBuilder.RenameColumn(
                name: "code8",
                table: "room_codes",
                newName: "code08");

            migrationBuilder.RenameColumn(
                name: "code7",
                table: "room_codes",
                newName: "code07");

            migrationBuilder.RenameColumn(
                name: "code6",
                table: "room_codes",
                newName: "code06");

            migrationBuilder.RenameColumn(
                name: "code5",
                table: "room_codes",
                newName: "code05");

            migrationBuilder.RenameColumn(
                name: "code4",
                table: "room_codes",
                newName: "code04");

            migrationBuilder.RenameColumn(
                name: "code3",
                table: "room_codes",
                newName: "code03");

            migrationBuilder.RenameColumn(
                name: "code2",
                table: "room_codes",
                newName: "code02");

            migrationBuilder.RenameColumn(
                name: "code1",
                table: "room_codes",
                newName: "code01");
        }
    }
}
