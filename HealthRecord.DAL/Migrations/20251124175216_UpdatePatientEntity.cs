using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthRecord1.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePatientEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SmokingStatus",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "RegistrationDate",
                table: "Patients",
                newName: "CreationDate");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber2",
                table: "Patients",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber2",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Patients",
                newName: "RegistrationDate");

            migrationBuilder.AddColumn<string>(
                name: "SmokingStatus",
                table: "Patients",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);
        }
    }
}
