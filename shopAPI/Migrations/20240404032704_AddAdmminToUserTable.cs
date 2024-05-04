using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shopAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddAdmminToUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 4, 10, 27, 4, 50, DateTimeKind.Local).AddTicks(5733), new DateTime(2024, 4, 4, 10, 27, 4, 50, DateTimeKind.Local).AddTicks(5746) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 4, 10, 27, 4, 50, DateTimeKind.Local).AddTicks(5750), new DateTime(2024, 4, 4, 10, 27, 4, 50, DateTimeKind.Local).AddTicks(5750) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 4, 10, 27, 4, 50, DateTimeKind.Local).AddTicks(5752), new DateTime(2024, 4, 4, 10, 27, 4, 50, DateTimeKind.Local).AddTicks(5752) });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreateAt", "LoginId", "Password", "Role", "UpdateAt" },
                values: new object[] { 1, new DateTime(2024, 4, 4, 10, 27, 4, 50, DateTimeKind.Local).AddTicks(5862), "admin", "admin", "admin", new DateTime(2024, 4, 4, 10, 27, 4, 50, DateTimeKind.Local).AddTicks(5862) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 3, 21, 47, 22, 482, DateTimeKind.Local).AddTicks(7239), new DateTime(2024, 4, 3, 21, 47, 22, 482, DateTimeKind.Local).AddTicks(7250) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 3, 21, 47, 22, 482, DateTimeKind.Local).AddTicks(7252), new DateTime(2024, 4, 3, 21, 47, 22, 482, DateTimeKind.Local).AddTicks(7253) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 3, 21, 47, 22, 482, DateTimeKind.Local).AddTicks(7254), new DateTime(2024, 4, 3, 21, 47, 22, 482, DateTimeKind.Local).AddTicks(7255) });
        }
    }
}
