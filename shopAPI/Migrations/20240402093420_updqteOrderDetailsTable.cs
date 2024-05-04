using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shopAPI.Migrations
{
    /// <inheritdoc />
    public partial class updqteOrderDetailsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "unitPrice",
                table: "OrderDetails",
                newName: "UnitPrice");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "OrderDetails",
                newName: "Quantity");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "OrderDetails",
                newName: "unitPrice");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "OrderDetails",
                newName: "quantity");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 2, 16, 32, 30, 204, DateTimeKind.Local).AddTicks(5926), new DateTime(2024, 4, 2, 16, 32, 30, 204, DateTimeKind.Local).AddTicks(5937) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 2, 16, 32, 30, 204, DateTimeKind.Local).AddTicks(5938), new DateTime(2024, 4, 2, 16, 32, 30, 204, DateTimeKind.Local).AddTicks(5939) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 2, 16, 32, 30, 204, DateTimeKind.Local).AddTicks(5940), new DateTime(2024, 4, 2, 16, 32, 30, 204, DateTimeKind.Local).AddTicks(5940) });
        }
    }
}
