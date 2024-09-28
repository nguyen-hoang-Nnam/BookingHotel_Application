using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingHotel_Application.Model.Migrations
{
    /// <inheritdoc />
    public partial class bookingDB_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Payments_bookingId",
                table: "Payments");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: "c7ff328c-efe3-41e0-976a-017a51865b73");

            migrationBuilder.AddColumn<string>(
                name: "PaymentLink",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "adminId",
                keyValue: 1,
                column: "userId",
                value: "12d01617-809f-4ade-8e82-17be5be51461");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "userId", "Email", "Role", "Status", "passwordHash", "phoneNumber", "refreshToken", "userName" },
                values: new object[] { "12d01617-809f-4ade-8e82-17be5be51461", "admin@gmail.com", 1, 1, "$2a$11$wFbJxm54eo7EPtVYZN7jx.UAqwhRjo3BXUCaG2Pam98r9nBvg075u", "1234567890", "", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_bookingId",
                table: "Payments",
                column: "bookingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Payments_bookingId",
                table: "Payments");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: "12d01617-809f-4ade-8e82-17be5be51461");

            migrationBuilder.DropColumn(
                name: "PaymentLink",
                table: "Bookings");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "adminId",
                keyValue: 1,
                column: "userId",
                value: "c7ff328c-efe3-41e0-976a-017a51865b73");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "userId", "Email", "Role", "Status", "passwordHash", "phoneNumber", "refreshToken", "userName" },
                values: new object[] { "c7ff328c-efe3-41e0-976a-017a51865b73", "admin@gmail.com", 1, 1, "$2a$11$hLYQ1ASvze0RuLjBSAaa0OgNXc1dIhqe0WU0HkuNjGQ2/rQVIeAf6", "1234567890", "", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_bookingId",
                table: "Payments",
                column: "bookingId",
                unique: true);
        }
    }
}
