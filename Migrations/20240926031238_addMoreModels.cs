using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Resume.Migrations
{
    /// <inheritdoc />
    public partial class addMoreModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobTitle",
                table: "ResumeTemplate");

            migrationBuilder.DropColumn(
                name: "SubTitles",
                table: "ResumeTemplate");

            migrationBuilder.AddColumn<int>(
                name: "SubTitleId",
                table: "ResumeTemplate",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    JobTitle = table.Column<string>(type: "text", nullable: true),
                    JobDescription = table.Column<List<string>>(type: "text[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubTitles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubTitles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResumeTemplate_SubTitleId",
                table: "ResumeTemplate",
                column: "SubTitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResumeTemplate_SubTitles_SubTitleId",
                table: "ResumeTemplate",
                column: "SubTitleId",
                principalTable: "SubTitles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResumeTemplate_SubTitles_SubTitleId",
                table: "ResumeTemplate");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "SubTitles");

            migrationBuilder.DropIndex(
                name: "IX_ResumeTemplate_SubTitleId",
                table: "ResumeTemplate");

            migrationBuilder.DropColumn(
                name: "SubTitleId",
                table: "ResumeTemplate");

            migrationBuilder.AddColumn<string>(
                name: "JobTitle",
                table: "ResumeTemplate",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubTitles",
                table: "ResumeTemplate",
                type: "text",
                nullable: true);
        }
    }
}
