using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Jobstacle.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultDataAndUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ad2bcf0c-20db-474f-8407-5a6b159518ba", null, "Administrator", "ADMINISTRATOR" },
                    { "bd2bcf0c-20db-474f-8407-5a6b159518bb", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3781efa7-66dc-47f0-860f-e506d04102e4", 0, "c520a613-a9ba-45aa-aeec-810136eaa391", "admin@localhost.com", false, "Admin", "User", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAELMElXqj+zpUieiPggkd/edHVe94gPUjYXrZW3/K0olG/nFlMIWvXQIeHLVQpLWmHw==", null, false, "b426943f-442c-4638-825f-9710844dfcc9", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "ContactNumber", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Email", "Name", "UpdatedBy" },
                values: new object[] { 1, "78646468", "System", new DateTime(2024, 1, 10, 16, 25, 54, 565, DateTimeKind.Local).AddTicks(9452), new DateTime(2024, 1, 10, 16, 25, 54, 565, DateTimeKind.Local).AddTicks(9466), "The best X there is.", "companyX@gmail.com", "X", "System" });

            migrationBuilder.InsertData(
                table: "JobSeekers",
                columns: new[] { "Id", "ContactNumber", "CreatedBy", "DateCreated", "DateUpdated", "Email", "Gender", "Location", "Name", "Resume", "UpdatedBy" },
                values: new object[] { 1, "98765432", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "johntan@gmail.com", "Male", "Tampines", "John", null, null });

            migrationBuilder.InsertData(
                table: "Organizers",
                columns: new[] { "Id", "ContactNumber", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Email", "Name", "UpdatedBy" },
                values: new object[] { 1, "98765432", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OrgY@gmail.com", "OrgY", null });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "Id", "ContactNumber", "CreatedBy", "DateCreated", "DateUpdated", "Department", "Email", "Name", "Position", "UpdatedBy" },
                values: new object[] { 1, "74682746", "System", new DateTime(2024, 1, 10, 16, 25, 54, 566, DateTimeKind.Local).AddTicks(344), new DateTime(2024, 1, 10, 16, 25, 54, 566, DateTimeKind.Local).AddTicks(345), "Human Resource", "jonahliu@gmail.com", "Jonah", "Manager", "System" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd2bcf0c-20db-474f-8407-5a6b159518bb");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "JobSeekers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Organizers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad2bcf0c-20db-474f-8407-5a6b159518ba");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4");
        }
    }
}
