using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resume.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStuff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Jobs_ResumeId",
                table: "Jobs");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_ResumeId",
                table: "Jobs",
                column: "ResumeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Jobs_ResumeId",
                table: "Jobs");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_ResumeId",
                table: "Jobs",
                column: "ResumeId",
                unique: true);
        }
    }
}
