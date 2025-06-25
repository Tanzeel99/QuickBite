using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuickBite.Services.CouponAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrAndCouponSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    CouponID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CouponCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountAmount = table.Column<double>(type: "float", nullable: false),
                    MinAmount = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.CouponID);
                });

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "CouponID", "CouponCode", "CreatedBy", "CreatedDate", "DiscountAmount", "IsActive", "MinAmount", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "C120", 1, new DateTime(2025, 4, 18, 11, 25, 26, 143, DateTimeKind.Local).AddTicks(8654), 120.0, true, 240, 1, new DateTime(2025, 4, 18, 11, 25, 26, 145, DateTimeKind.Local).AddTicks(210) },
                    { 2, "C100", 1, new DateTime(2025, 4, 18, 11, 25, 26, 143, DateTimeKind.Local).AddTicks(8654), 100.0, true, 200, 1, new DateTime(2025, 4, 18, 11, 25, 26, 145, DateTimeKind.Local).AddTicks(210) },
                    { 3, "C75", 1, new DateTime(2025, 4, 18, 11, 25, 26, 143, DateTimeKind.Local).AddTicks(8654), 75.0, true, 150, 1, new DateTime(2025, 4, 18, 11, 25, 26, 145, DateTimeKind.Local).AddTicks(210) },
                    { 4, "C50", 1, new DateTime(2025, 4, 18, 11, 25, 26, 143, DateTimeKind.Local).AddTicks(8654), 50.0, true, 100, 1, new DateTime(2025, 4, 18, 11, 25, 26, 145, DateTimeKind.Local).AddTicks(210) },
                    { 5, "C25", 1, new DateTime(2025, 4, 18, 11, 25, 26, 143, DateTimeKind.Local).AddTicks(8654), 25.0, true, 50, 1, new DateTime(2025, 4, 18, 11, 25, 26, 145, DateTimeKind.Local).AddTicks(210) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coupons");
        }
    }
}
