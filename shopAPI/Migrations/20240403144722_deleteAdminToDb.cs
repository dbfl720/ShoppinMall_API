using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shopAPI.Migrations
{
    /// <inheritdoc />
    public partial class deleteAdminToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "OrderDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
                values: new object[] { new DateTime(2024, 4, 2, 16, 34, 20, 892, DateTimeKind.Local).AddTicks(5918), new DateTime(2024, 4, 2, 16, 34, 20, 892, DateTimeKind.Local).AddTicks(5931) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 2, 16, 34, 20, 892, DateTimeKind.Local).AddTicks(5933), new DateTime(2024, 4, 2, 16, 34, 20, 892, DateTimeKind.Local).AddTicks(5934) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 2, 16, 34, 20, 892, DateTimeKind.Local).AddTicks(5935), new DateTime(2024, 4, 2, 16, 34, 20, 892, DateTimeKind.Local).AddTicks(5936) });
        }
    }
}
