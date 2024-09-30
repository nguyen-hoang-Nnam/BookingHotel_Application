using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingHotel_Application.Model.Migrations
{
    /// <inheritdoc />
    public partial class user_data_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "adminId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "customerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "staffId",
                keyValue: 1);

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

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "userId", "Email", "Role", "Status", "passwordHash", "phoneNumber", "refreshToken", "userName" },
                values: new object[,]
                {
                    { "56cfc5fd-a40d-457c-99a9-8959e626a26c", "staff@gmail.com", 2, 1, "$2a$11$xfBg6mORLywtbYG0L15A1.3m8K64k.109MJAVoYz2SF1/DccA97pa", "1234567890", "", "staff" },
                    { "d48a0e76-84ba-4483-b573-5ed86a832490", "admin@gmail.com", 1, 1, "$2a$11$DelMv5rC9cxgosKjdMfaBeqndbJmvgS2P5MInvrUjdswDof1Q9136", "1234567890", "", "admin" },
                    { "fae4224b-1772-4820-b36e-372eb75e5a2c", "customer@gmail.com", 3, 1, "$2a$11$XcGcb.pJdH63rRKhs4BKculvMNfL4IG2e7k6rC4oSSYrB/hioPxJa", "1234567890", "", "customer" }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "adminId", "Address", "firstName", "lastName", "userId" },
                values: new object[] { -1, "Admin Address", "Admin", "User", "d48a0e76-84ba-4483-b573-5ed86a832490" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "customerId", "Address", "firstName", "lastName", "userId" },
                values: new object[] { -1, "Customer Address", "Customer", "User", "fae4224b-1772-4820-b36e-372eb75e5a2c" });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "staffId", "Address", "firstName", "lastName", "userId" },
                values: new object[] { -1, "Staff Address", "Staff", "User", "56cfc5fd-a40d-457c-99a9-8959e626a26c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "adminId",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "customerId",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "staffId",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: "56cfc5fd-a40d-457c-99a9-8959e626a26c");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: "d48a0e76-84ba-4483-b573-5ed86a832490");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: "fae4224b-1772-4820-b36e-372eb75e5a2c");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "userId", "Email", "Role", "Status", "passwordHash", "phoneNumber", "refreshToken", "userName" },
                values: new object[,]
                {
                    { "5cf37520-77f7-4169-916c-1513a0c298e9", "customer@gmail.com", 3, 1, "$2a$11$MXj.9U2n76mtkzzNQBmBEu/oGOzBzqVwBt92c5ySGDnxza81YynHi", "1234567890", "", "customer" },
                    { "b7d6463c-2886-4437-aa24-dcf9750e9042", "admin@gmail.com", 1, 1, "$2a$11$UXJAxlypIo2CmsHCCuVa0OZMhmv9HoWEij56c/SBZL41Hg.skR2H6", "1234567890", "", "admin" },
                    { "ebb8a3e0-7493-4367-9ad8-792c5722667c", "staff@gmail.com", 2, 1, "$2a$11$jWVe5TspAAAsAjZvIfjoCOenC89kdpe2oLVSPbAwEokVGrGOTWeIW", "1234567890", "", "staff" }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "adminId", "Address", "firstName", "lastName", "userId" },
                values: new object[] { 1, "Admin Address", "Admin", "User", "b7d6463c-2886-4437-aa24-dcf9750e9042" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "customerId", "Address", "firstName", "lastName", "userId" },
                values: new object[] { 1, "Customer Address", "Customer", "User", "5cf37520-77f7-4169-916c-1513a0c298e9" });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "staffId", "Address", "firstName", "lastName", "userId" },
                values: new object[] { 1, "Staff Address", "Staff", "User", "ebb8a3e0-7493-4367-9ad8-792c5722667c" });
        }
    }
}
