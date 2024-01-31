using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jobstacle.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "StaffPic",
                table: "Staffs",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "OrgLogo",
                table: "Organizers",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "JobSeekerPic",
                table: "JobSeekers",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b38a1e27-7f10-4f29-ab68-6d749754bad8", "AQAAAAIAAYagAAAAENZ6cEDw85+CpqN1jrGFhqpewvxFMC2G671YV73cU/Z+BDTT19Fz+9EkSielcEOXIA==", "9f77c64a-1cef-4435-8ce2-e29a9a0f52ed" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 1, 31, 17, 41, 20, 173, DateTimeKind.Local).AddTicks(2338), new DateTime(2024, 1, 31, 17, 41, 20, 173, DateTimeKind.Local).AddTicks(2353) });

            migrationBuilder.UpdateData(
                table: "JobSeekers",
                keyColumn: "Id",
                keyValue: 1,
                column: "JobSeekerPic",
                value: null);

            migrationBuilder.UpdateData(
                table: "Organizers",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrgLogo",
                value: null);

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated", "StaffPic" },
                values: new object[] { new DateTime(2024, 1, 31, 17, 41, 20, 173, DateTimeKind.Local).AddTicks(3013), new DateTime(2024, 1, 31, 17, 41, 20, 173, DateTimeKind.Local).AddTicks(3014), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StaffPic",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "OrgLogo",
                table: "Organizers");

            migrationBuilder.DropColumn(
                name: "JobSeekerPic",
                table: "JobSeekers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "544f21eb-9f2c-4239-84d7-100ece0dc1a6", "AQAAAAIAAYagAAAAEDDVgTzCOuOzY/5ChtYuARcL80f7rx7Nq5KkyxEw57K13DUSjyTFYWkTQy8a2AiQGQ==", "bac4271f-533d-449f-a61c-e8369ea0eade" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 1, 31, 16, 22, 50, 78, DateTimeKind.Local).AddTicks(1520), new DateTime(2024, 1, 31, 16, 22, 50, 78, DateTimeKind.Local).AddTicks(1531) });

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 1, 31, 16, 22, 50, 78, DateTimeKind.Local).AddTicks(2820), new DateTime(2024, 1, 31, 16, 22, 50, 78, DateTimeKind.Local).AddTicks(2821) });
        }
    }
}
