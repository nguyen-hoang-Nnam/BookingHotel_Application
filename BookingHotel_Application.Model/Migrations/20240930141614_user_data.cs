using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingHotel_Application.Model.Migrations
{
    /// <inheritdoc />
    public partial class user_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Users_userId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Users_userId",
                table: "Staffs");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: "c5831f9c-28e2-4031-ad7b-8689efff2834");

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "Staffs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "adminId",
                keyValue: 1,
                column: "userId",
                value: "2b089b74-0941-4478-bc24-6296038bba35");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "userId", "Email", "Role", "Status", "passwordHash", "phoneNumber", "refreshToken", "userName" },
                values: new object[,]
                {
                    { "2b089b74-0941-4478-bc24-6296038bba35", "admin@gmail.com", 1, 1, "$2a$11$oIVEOHDrRJmLlclpxl2ZR.ceEWaIydpu87iHcFV5Ln.7rmoyUZoLm", "1234567890", "", "admin" },
                    { "69813064-f1d0-46f4-b8b8-9e89b1319c3b", "customer@gmail.com", 3, 1, "$2a$11$bTuCiUL3P/oj7DcRG8HIE.0wLf.CjstxmrWqIgJd6J3aH2bZ8nQ6u", "1234567890", "", "customer" },
                    { "8473dd4b-6455-4df1-ba92-23e8bfd475de", "staff@gmail.com", 2, 1, "$2a$11$ReAREjjgSjWzjTU8XA8q1OxVkgh6/vgwlTqYfncgM3lS9uYEsfhAG", "1234567890", "", "staff" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "customerId", "Address", "firstName", "lastName", "userId" },
                values: new object[] { 1, "Customer Address", "Customer", "User", "69813064-f1d0-46f4-b8b8-9e89b1319c3b" });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "staffId", "Address", "firstName", "lastName", "userId" },
                values: new object[] { 1, "Staff Address", "Staff", "User", "8473dd4b-6455-4df1-ba92-23e8bfd475de" });

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Users_userId",
                table: "Customers",
                column: "userId",
                principalTable: "Users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Users_userId",
                table: "Staffs",
                column: "userId",
                principalTable: "Users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Users_userId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Users_userId",
                table: "Staffs");

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
                keyValue: "2b089b74-0941-4478-bc24-6296038bba35");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: "69813064-f1d0-46f4-b8b8-9e89b1319c3b");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: "8473dd4b-6455-4df1-ba92-23e8bfd475de");

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "Staffs",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "adminId",
                keyValue: 1,
                column: "userId",
                value: "c5831f9c-28e2-4031-ad7b-8689efff2834");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "userId", "Email", "Role", "Status", "passwordHash", "phoneNumber", "refreshToken", "userName" },
                values: new object[] { "c5831f9c-28e2-4031-ad7b-8689efff2834", "admin@gmail.com", 1, 1, "$2a$11$qR/eR2awWH/icnjMHm6e/ux7PrFkvi7TLEnbTdYYqVVwt73IFsbYi", "1234567890", "", "admin" });

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Users_userId",
                table: "Customers",
                column: "userId",
                principalTable: "Users",
                principalColumn: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Users_userId",
                table: "Staffs",
                column: "userId",
                principalTable: "Users",
                principalColumn: "userId");
        }
    }
}
