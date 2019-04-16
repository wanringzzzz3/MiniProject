using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniProject.Migrations
{
    public partial class EditTable_Room_RemoveFgk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Rooms_RoomId1",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_RoomId1",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "RoomId1",
                table: "Bookings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomId1",
                table: "Bookings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomId1",
                table: "Bookings",
                column: "RoomId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Rooms_RoomId1",
                table: "Bookings",
                column: "RoomId1",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
