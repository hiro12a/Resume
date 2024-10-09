using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Resume.Migrations
{
    /// <inheritdoc />
    public partial class AddVisitorCounter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SubTitles_ResumeId",
                table: "SubTitles");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2dfabb5a-1963-4208-bb64-a7068a7b9203");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65ef7cb6-a02f-476a-b126-fcf1d5b6b795");

            migrationBuilder.CreateTable(
                name: "VisitorCounter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Counter = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitorCounter", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "68936879-bc9d-4706-aa6d-ee313947d914", null, "User", "USER" },
                    { "f78a1f35-7339-4d51-b6a5-652902869f1b", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubTitles_ResumeId",
                table: "SubTitles",
                column: "ResumeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VisitorCounter");

            migrationBuilder.DropIndex(
                name: "IX_SubTitles_ResumeId",
                table: "SubTitles");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68936879-bc9d-4706-aa6d-ee313947d914");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f78a1f35-7339-4d51-b6a5-652902869f1b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2dfabb5a-1963-4208-bb64-a7068a7b9203", null, "Admin", "ADMIN" },
                    { "65ef7cb6-a02f-476a-b126-fcf1d5b6b795", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubTitles_ResumeId",
                table: "SubTitles",
                column: "ResumeId",
                unique: true);
        }
    }
}
