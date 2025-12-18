using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthRecord1.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddNationalIdToPatient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Operations",
                newName: "id");

            migrationBuilder.AddColumn<string>(
                name: "NationalId",
                table: "Patients",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_NationalId",
                table: "Patients",
                column: "NationalId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Patient_NationalId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "NationalId",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Operations",
                newName: "Id");
        }
    }
}
