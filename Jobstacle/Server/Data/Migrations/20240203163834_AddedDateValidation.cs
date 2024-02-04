using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jobstacle.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedDateValidation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e65839e-052e-4b54-8c91-9ab5846d416a", "AQAAAAIAAYagAAAAEDilZvtI4oID2TWImLqiWxQp+y00QNykyGtPi0Q92OR5UnCAU01h6tu+O+4ZrR4eYw==", "1c3fa851-2454-4982-ae3f-09f83bda8135" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 2, 4, 0, 38, 34, 175, DateTimeKind.Local).AddTicks(5901), new DateTime(2024, 2, 4, 0, 38, 34, 175, DateTimeKind.Local).AddTicks(5921) });

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 2, 4, 0, 38, 34, 175, DateTimeKind.Local).AddTicks(6619), new DateTime(2024, 2, 4, 0, 38, 34, 175, DateTimeKind.Local).AddTicks(6620) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ca32d39-a961-491f-8027-4079d0ada2bf", "AQAAAAIAAYagAAAAEGlWQDbH6sjOg2dGys2sKZYJIGoWZ32fAKg/iKLLjVPdQcX0zJDlMwbKajI58+wZIA==", "bde925cf-fa30-4695-8162-6c5c1d532f93" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 2, 4, 0, 10, 41, 807, DateTimeKind.Local).AddTicks(1908), new DateTime(2024, 2, 4, 0, 10, 41, 807, DateTimeKind.Local).AddTicks(1922) });

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 2, 4, 0, 10, 41, 807, DateTimeKind.Local).AddTicks(2811), new DateTime(2024, 2, 4, 0, 10, 41, 807, DateTimeKind.Local).AddTicks(2812) });
        }
    }
}
