using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingHotel_Application.Model.Migrations
{
    /// <inheritdoc />
    public partial class booking_db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: "a2036d0b-3631-4eb3-942b-807e5aee4409");

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    bookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    checkIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    checkOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    totalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    bookingStatus = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    roomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.bookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_Rooms_roomId",
                        column: x => x.roomId,
                        principalTable: "Rooms",
                        principalColumn: "roomId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "adminId",
                keyValue: 1,
                column: "userId",
                value: "bbde3d19-c64e-44a2-ae27-058fe417c386");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "userId", "Email", "Role", "Status", "passwordHash", "phoneNumber", "refreshToken", "userName" },
                values: new object[] { "bbde3d19-c64e-44a2-ae27-058fe417c386", "admin@gmail.com", 1, 1, "$2a$11$qk0dV4lThnnjyCW71tHTJeX23C/FUPsLjepyYKd8mTk38RDXjGSjW", "1234567890", "", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_roomId",
                table: "Bookings",
                column: "roomId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_userId",
                table: "Bookings",
                column: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: "bbde3d19-c64e-44a2-ae27-058fe417c386");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "adminId",
                keyValue: 1,
                column: "userId",
                value: "a2036d0b-3631-4eb3-942b-807e5aee4409");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "userId", "Email", "Role", "Status", "passwordHash", "phoneNumber", "refreshToken", "userName" },
                values: new object[] { "a2036d0b-3631-4eb3-942b-807e5aee4409", "admin@gmail.com", 1, 1, "$2a$11$FIE.tyi9xMhq2K5YaA4PuueIyvzLUT9IWVdCrDfjpAVlkGJw8CbYS", "1234567890", "", "admin" });
        }
    }
}
