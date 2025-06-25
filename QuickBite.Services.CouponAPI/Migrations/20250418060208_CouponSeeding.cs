using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickBite.Services.CouponAPI.Migrations
{
    /// <inheritdoc />
    public partial class CouponSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "CouponID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "CouponID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "CouponID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "CouponID",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "CouponID",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Local) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "CouponID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 18, 11, 25, 26, 143, DateTimeKind.Local).AddTicks(8654), new DateTime(2025, 4, 18, 11, 25, 26, 145, DateTimeKind.Local).AddTicks(210) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "CouponID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 18, 11, 25, 26, 145, DateTimeKind.Local).AddTicks(885), new DateTime(2025, 4, 18, 11, 25, 26, 145, DateTimeKind.Local).AddTicks(887) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "CouponID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 18, 11, 25, 26, 145, DateTimeKind.Local).AddTicks(891), new DateTime(2025, 4, 18, 11, 25, 26, 145, DateTimeKind.Local).AddTicks(892) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "CouponID",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 18, 11, 25, 26, 145, DateTimeKind.Local).AddTicks(895), new DateTime(2025, 4, 18, 11, 25, 26, 145, DateTimeKind.Local).AddTicks(896) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "CouponID",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 18, 11, 25, 26, 145, DateTimeKind.Local).AddTicks(898), new DateTime(2025, 4, 18, 11, 25, 26, 145, DateTimeKind.Local).AddTicks(899) });
        }
    }
}
