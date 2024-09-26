using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingHotel_Application.Model.Migrations
{
    /// <inheritdoc />
    public partial class admin_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Users_userId",
                table: "Admins");

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "Admins",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "userId", "Email", "Role", "Status", "passwordHash", "phoneNumber", "refreshToken", "userName" },
                values: new object[] { "e4907243-d882-4b44-9cb5-c7534f7d1db7", "admin@gmail.com", 1, 1, "jGl25bVBBBW96Qi9Te4V37Fnqchz/Eu4qB9vKrRIqRg=", "1234567890", "", "admin" });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "adminId", "Address", "firstName", "lastName", "userId" },
                values: new object[] { 1, "Admin Address", "Admin", "User", "e4907243-d882-4b44-9cb5-c7534f7d1db7" });

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Users_userId",
                table: "Admins",
                column: "userId",
                principalTable: "Users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Users_userId",
                table: "Admins");

            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "adminId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: "e4907243-d882-4b44-9cb5-c7534f7d1db7");

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "Admins",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Users_userId",
                table: "Admins",
                column: "userId",
                principalTable: "Users",
                principalColumn: "userId");
        }
    }
}
