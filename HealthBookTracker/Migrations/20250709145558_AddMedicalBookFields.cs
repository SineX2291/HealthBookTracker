using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthBookTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddMedicalBookFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DaysUntilExpiration",
                table: "Employee",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "MedicalBookEndDate",
                table: "Employee",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DaysUntilExpiration",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "MedicalBookEndDate",
                table: "Employee");
        }
    }
}
