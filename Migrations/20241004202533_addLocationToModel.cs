using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Resume.Migrations
{
    /// <inheritdoc />
    public partial class addLocationToModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7161546e-7684-4b05-9587-809ff11439e2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8173e465-6360-4257-a09e-900233d0281a");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "ResumeTemplate");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "ResumeTemplate");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Jobs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "42de2fa3-17e7-4191-8430-b60428d4a1e1", null, "User", "USER" },
                    { "54eff67f-c733-4a22-a325-15f363aff0bb", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42de2fa3-17e7-4191-8430-b60428d4a1e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54eff67f-c733-4a22-a325-15f363aff0bb");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Jobs");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "ResumeTemplate",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "ResumeTemplate",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7161546e-7684-4b05-9587-809ff11439e2", null, "User", "USER" },
                    { "8173e465-6360-4257-a09e-900233d0281a", null, "Admin", "ADMIN" }
                });
        }
    }
}
