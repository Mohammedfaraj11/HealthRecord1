using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthRecord1.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FixVaccinationRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vaccinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VaccineName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DateAdministered = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoseNumber = table.Column<int>(type: "int", nullable: true),
                    BatchNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NextDoseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccinations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VaccinationCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    VaccinationId = table.Column<int>(type: "int", nullable: false),
                    AdministrationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    AdministeredBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AdministrationSite = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReactionNotes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NextDoseReminder = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    AdditionalNotes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinationCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VaccinationCards_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VaccinationCards_Vaccinations_VaccinationId",
                        column: x => x.VaccinationId,
                        principalTable: "Vaccinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationCards_PatientId",
                table: "VaccinationCards",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationCards_VaccinationId",
                table: "VaccinationCards",
                column: "VaccinationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VaccinationCards");

            migrationBuilder.DropTable(
                name: "Vaccinations");
        }
    }
}
