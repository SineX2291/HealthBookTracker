using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthBookTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DaysUntilExpiration",
                table: "Employee");

            migrationBuilder.AlterColumn<DateTime>(
                name: "MedicalBookEndDate",
                table: "Employee",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "MedicalBookEndDate",
                table: "Employee",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DaysUntilExpiration",
                table: "Employee",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
