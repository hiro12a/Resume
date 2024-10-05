using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resume.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResumeTemplate_Jobs_JobId",
                table: "ResumeTemplate");

            migrationBuilder.DropForeignKey(
                name: "FK_ResumeTemplate_SubTitles_SubTitleId",
                table: "ResumeTemplate");

            migrationBuilder.DropIndex(
                name: "IX_ResumeTemplate_JobId",
                table: "ResumeTemplate");

            migrationBuilder.DropIndex(
                name: "IX_ResumeTemplate_SubTitleId",
                table: "ResumeTemplate");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "ResumeTemplate");

            migrationBuilder.DropColumn(
                name: "SubTitleId",
                table: "ResumeTemplate");

            migrationBuilder.AddColumn<int>(
                name: "ResumeId",
                table: "SubTitles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ResumeId",
                table: "Jobs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SubTitles_ResumeId",
                table: "SubTitles",
                column: "ResumeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_ResumeId",
                table: "Jobs",
                column: "ResumeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_ResumeTemplate_ResumeId",
                table: "Jobs",
                column: "ResumeId",
                principalTable: "ResumeTemplate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubTitles_ResumeTemplate_ResumeId",
                table: "SubTitles",
                column: "ResumeId",
                principalTable: "ResumeTemplate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_ResumeTemplate_ResumeId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_SubTitles_ResumeTemplate_ResumeId",
                table: "SubTitles");

            migrationBuilder.DropIndex(
                name: "IX_SubTitles_ResumeId",
                table: "SubTitles");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_ResumeId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ResumeId",
                table: "SubTitles");

            migrationBuilder.DropColumn(
                name: "ResumeId",
                table: "Jobs");

            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "ResumeTemplate",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubTitleId",
                table: "ResumeTemplate",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResumeTemplate_JobId",
                table: "ResumeTemplate",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeTemplate_SubTitleId",
                table: "ResumeTemplate",
                column: "SubTitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResumeTemplate_Jobs_JobId",
                table: "ResumeTemplate",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ResumeTemplate_SubTitles_SubTitleId",
                table: "ResumeTemplate",
                column: "SubTitleId",
                principalTable: "SubTitles",
                principalColumn: "Id");
        }
    }
}
