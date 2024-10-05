using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Resume.Migrations
{
    /// <inheritdoc />
    public partial class addBool : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42de2fa3-17e7-4191-8430-b60428d4a1e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54eff67f-c733-4a22-a325-15f363aff0bb");

            migrationBuilder.AddColumn<bool>(
                name: "IsCurrentJob",
                table: "Jobs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2dfabb5a-1963-4208-bb64-a7068a7b9203", null, "Admin", "ADMIN" },
                    { "65ef7cb6-a02f-476a-b126-fcf1d5b6b795", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2dfabb5a-1963-4208-bb64-a7068a7b9203");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65ef7cb6-a02f-476a-b126-fcf1d5b6b795");

            migrationBuilder.DropColumn(
                name: "IsCurrentJob",
                table: "Jobs");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "42de2fa3-17e7-4191-8430-b60428d4a1e1", null, "User", "USER" },
                    { "54eff67f-c733-4a22-a325-15f363aff0bb", null, "Admin", "ADMIN" }
                });
        }
    }
}
