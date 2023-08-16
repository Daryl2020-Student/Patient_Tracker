using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Patient_Tracker.Migrations
{
    /// <inheritdoc />
    public partial class Prescription_Page2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "Prescription");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeOnly>(
                name: "Time",
                table: "Prescription",
                type: "TEXT",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));
        }
    }
}
