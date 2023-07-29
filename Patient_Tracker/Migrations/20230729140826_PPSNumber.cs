using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Patient_Tracker.Migrations
{
    /// <inheritdoc />
    public partial class PPSNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PPS",
                table: "Patients",
                type: "TEXT",
                maxLength: 8,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PPS",
                table: "Patients");
        }
    }
}
