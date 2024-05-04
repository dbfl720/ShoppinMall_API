using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shopAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoginId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "Id", "LoginId", "Password" },
                values: new object[] { 1, "admin", "1234" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 2, 15, 55, 21, 141, DateTimeKind.Local).AddTicks(8264), new DateTime(2024, 4, 2, 15, 55, 21, 141, DateTimeKind.Local).AddTicks(8274) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 2, 15, 55, 21, 141, DateTimeKind.Local).AddTicks(8276), new DateTime(2024, 4, 2, 15, 55, 21, 141, DateTimeKind.Local).AddTicks(8276) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 2, 15, 55, 21, 141, DateTimeKind.Local).AddTicks(8278), new DateTime(2024, 4, 2, 15, 55, 21, 141, DateTimeKind.Local).AddTicks(8278) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 2, 13, 59, 40, 542, DateTimeKind.Local).AddTicks(4996), new DateTime(2024, 4, 2, 13, 59, 40, 542, DateTimeKind.Local).AddTicks(5007) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 2, 13, 59, 40, 542, DateTimeKind.Local).AddTicks(5009), new DateTime(2024, 4, 2, 13, 59, 40, 542, DateTimeKind.Local).AddTicks(5009) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 2, 13, 59, 40, 542, DateTimeKind.Local).AddTicks(5011), new DateTime(2024, 4, 2, 13, 59, 40, 542, DateTimeKind.Local).AddTicks(5011) });
        }
    }
}
