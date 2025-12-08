using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthRecord1.DAL.Migrations
{
    /// <inheritdoc />
    public partial class EditOnChronicDisease : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiagnosisDate",
                table: "ChronicDiseases");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DiagnosisDate",
                table: "ChronicDiseases",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
