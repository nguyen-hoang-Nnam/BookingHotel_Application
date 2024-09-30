using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingHotel_Application.Model.Migrations
{
    /// <inheritdoc />
    public partial class user_data_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: "2b089b74-0941-4478-bc24-6296038bba35");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: "69813064-f1d0-46f4-b8b8-9e89b1319c3b");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: "8473dd4b-6455-4df1-ba92-23e8bfd475de");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "adminId",
                keyValue: 1,
                column: "userId",
                value: "b7d6463c-2886-4437-aa24-dcf9750e9042");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "customerId",
                keyValue: 1,
                column: "userId",
                value: "5cf37520-77f7-4169-916c-1513a0c298e9");

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "staffId",
                keyValue: 1,
                column: "userId",
                value: "ebb8a3e0-7493-4367-9ad8-792c5722667c");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "userId", "Email", "Role", "Status", "passwordHash", "phoneNumber", "refreshToken", "userName" },
                values: new object[,]
                {
                    { "5cf37520-77f7-4169-916c-1513a0c298e9", "customer@gmail.com", 3, 1, "$2a$11$MXj.9U2n76mtkzzNQBmBEu/oGOzBzqVwBt92c5ySGDnxza81YynHi", "1234567890", "", "customer" },
                    { "b7d6463c-2886-4437-aa24-dcf9750e9042", "admin@gmail.com", 1, 1, "$2a$11$UXJAxlypIo2CmsHCCuVa0OZMhmv9HoWEij56c/SBZL41Hg.skR2H6", "1234567890", "", "admin" },
                    { "ebb8a3e0-7493-4367-9ad8-792c5722667c", "staff@gmail.com", 2, 1, "$2a$11$jWVe5TspAAAsAjZvIfjoCOenC89kdpe2oLVSPbAwEokVGrGOTWeIW", "1234567890", "", "staff" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: "5cf37520-77f7-4169-916c-1513a0c298e9");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: "b7d6463c-2886-4437-aa24-dcf9750e9042");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: "ebb8a3e0-7493-4367-9ad8-792c5722667c");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "adminId",
                keyValue: 1,
                column: "userId",
                value: "2b089b74-0941-4478-bc24-6296038bba35");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "customerId",
                keyValue: 1,
                column: "userId",
                value: "69813064-f1d0-46f4-b8b8-9e89b1319c3b");

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "staffId",
                keyValue: 1,
                column: "userId",
                value: "8473dd4b-6455-4df1-ba92-23e8bfd475de");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "userId", "Email", "Role", "Status", "passwordHash", "phoneNumber", "refreshToken", "userName" },
                values: new object[,]
                {
                    { "2b089b74-0941-4478-bc24-6296038bba35", "admin@gmail.com", 1, 1, "$2a$11$oIVEOHDrRJmLlclpxl2ZR.ceEWaIydpu87iHcFV5Ln.7rmoyUZoLm", "1234567890", "", "admin" },
                    { "69813064-f1d0-46f4-b8b8-9e89b1319c3b", "customer@gmail.com", 3, 1, "$2a$11$bTuCiUL3P/oj7DcRG8HIE.0wLf.CjstxmrWqIgJd6J3aH2bZ8nQ6u", "1234567890", "", "customer" },
                    { "8473dd4b-6455-4df1-ba92-23e8bfd475de", "staff@gmail.com", 2, 1, "$2a$11$ReAREjjgSjWzjTU8XA8q1OxVkgh6/vgwlTqYfncgM3lS9uYEsfhAG", "1234567890", "", "staff" }
                });
        }
    }
}
