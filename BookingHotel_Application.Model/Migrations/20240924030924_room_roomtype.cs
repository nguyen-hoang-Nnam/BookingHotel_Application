using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingHotel_Application.Model.Migrations
{
    /// <inheritdoc />
    public partial class room_roomtype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    roomTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roomTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.roomTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    roomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roomName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    guestNumber = table.Column<int>(type: "int", nullable: false),
                    roomDes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pricePerDay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    roomSize = table.Column<int>(type: "int", nullable: false),
                    roomStatus = table.Column<int>(type: "int", nullable: false),
                    hotelId = table.Column<int>(type: "int", nullable: true),
                    roomTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.roomId);
                    table.ForeignKey(
                        name: "FK_Rooms_Hotels_hotelId",
                        column: x => x.hotelId,
                        principalTable: "Hotels",
                        principalColumn: "hotelId");
                    table.ForeignKey(
                        name: "FK_Rooms_RoomTypes_roomTypeId",
                        column: x => x.roomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "roomTypeId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_hotelId",
                table: "Rooms",
                column: "hotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_roomTypeId",
                table: "Rooms",
                column: "roomTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "RoomTypes");
        }
    }
}
