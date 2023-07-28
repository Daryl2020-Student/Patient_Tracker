using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Patient_Tracker.Migrations
{
    /// <inheritdoc />
    public partial class New_Patient_Properties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DoctorNum",
                table: "Patients",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PPSNo",
                table: "Patients",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoctorNum",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PPSNo",
                table: "Patients");
        }
    }
}
