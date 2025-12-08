using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthRecord1.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RefactorVaccinationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BatchNumber",
                table: "Vaccinations");

            migrationBuilder.DropColumn(
                name: "DateAdministered",
                table: "Vaccinations");

            migrationBuilder.DropColumn(
                name: "DoseNumber",
                table: "Vaccinations");

            migrationBuilder.DropColumn(
                name: "NextDoseDate",
                table: "Vaccinations");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "Vaccinations",
                newName: "Description");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Vaccinations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "StandardDoseCount",
                table: "Vaccinations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Vaccinations");

            migrationBuilder.DropColumn(
                name: "StandardDoseCount",
                table: "Vaccinations");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Vaccinations",
                newName: "Notes");

            migrationBuilder.AddColumn<string>(
                name: "BatchNumber",
                table: "Vaccinations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdministered",
                table: "Vaccinations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DoseNumber",
                table: "Vaccinations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NextDoseDate",
                table: "Vaccinations",
                type: "datetime2",
                nullable: true);
        }
    }
}
