using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jobstacle.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class coursedb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Organizers_OrganizerID",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Staffs_StaffID",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "StaffID",
                table: "Courses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OrganizerID",
                table: "Courses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c1be544-e580-48d6-8c75-86835fbdd8e2", "AQAAAAIAAYagAAAAEFjScTQb1bkZapU0rzND4ZNda8T9sm04DERI8LQpGhVU4n4zP016OftcHEhkaTKwcg==", "dfa6ec6f-22cb-4462-8f0a-0d9fbf0c36bc" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 1, 16, 22, 11, 19, 644, DateTimeKind.Local).AddTicks(5860), new DateTime(2024, 1, 16, 22, 11, 19, 644, DateTimeKind.Local).AddTicks(5874) });

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 1, 16, 22, 11, 19, 644, DateTimeKind.Local).AddTicks(6914), new DateTime(2024, 1, 16, 22, 11, 19, 644, DateTimeKind.Local).AddTicks(6916) });

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Organizers_OrganizerID",
                table: "Courses",
                column: "OrganizerID",
                principalTable: "Organizers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Staffs_StaffID",
                table: "Courses",
                column: "StaffID",
                principalTable: "Staffs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Organizers_OrganizerID",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Staffs_StaffID",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "StaffID",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrganizerID",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c520a613-a9ba-45aa-aeec-810136eaa391", "AQAAAAIAAYagAAAAELMElXqj+zpUieiPggkd/edHVe94gPUjYXrZW3/K0olG/nFlMIWvXQIeHLVQpLWmHw==", "b426943f-442c-4638-825f-9710844dfcc9" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 1, 10, 16, 25, 54, 565, DateTimeKind.Local).AddTicks(9452), new DateTime(2024, 1, 10, 16, 25, 54, 565, DateTimeKind.Local).AddTicks(9466) });

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 1, 10, 16, 25, 54, 566, DateTimeKind.Local).AddTicks(344), new DateTime(2024, 1, 10, 16, 25, 54, 566, DateTimeKind.Local).AddTicks(345) });

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Organizers_OrganizerID",
                table: "Courses",
                column: "OrganizerID",
                principalTable: "Organizers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Staffs_StaffID",
                table: "Courses",
                column: "StaffID",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
