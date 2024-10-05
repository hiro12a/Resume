using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resume.Migrations
{
    /// <inheritdoc />
    public partial class addJob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobDescription",
                table: "ResumeTemplate");

            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "ResumeTemplate",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResumeTemplate_JobId",
                table: "ResumeTemplate",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResumeTemplate_Jobs_JobId",
                table: "ResumeTemplate",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResumeTemplate_Jobs_JobId",
                table: "ResumeTemplate");

            migrationBuilder.DropIndex(
                name: "IX_ResumeTemplate_JobId",
                table: "ResumeTemplate");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "ResumeTemplate");

            migrationBuilder.AddColumn<string>(
                name: "JobDescription",
                table: "ResumeTemplate",
                type: "text",
                nullable: true);
        }
    }
}
