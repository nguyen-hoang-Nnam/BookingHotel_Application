using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingHotel_Application.Model.Migrations
{
    /// <inheritdoc />
    public partial class admin_data_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: "e4907243-d882-4b44-9cb5-c7534f7d1db7");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: "a2036d0b-3631-4eb3-942b-807e5aee4409");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "adminId",
                keyValue: 1,
                column: "userId",
                value: "e4907243-d882-4b44-9cb5-c7534f7d1db7");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "userId", "Email", "Role", "Status", "passwordHash", "phoneNumber", "refreshToken", "userName" },
                values: new object[] { "e4907243-d882-4b44-9cb5-c7534f7d1db7", "admin@gmail.com", 1, 1, "jGl25bVBBBW96Qi9Te4V37Fnqchz/Eu4qB9vKrRIqRg=", "1234567890", "", "admin" });
        }
    }
}
