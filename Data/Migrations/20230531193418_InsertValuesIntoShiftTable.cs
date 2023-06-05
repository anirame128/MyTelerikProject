using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTelerikProject.Data.Migrations
{
    public partial class InsertValuesIntoShiftTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "assignedToStation",
                table: "Shifts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
            migrationBuilder.Sql("INSERT INTO Shifts (assignedToStation, shiftAvailable) VALUES ('S1', '2023-06-01 08:00:00')");
            migrationBuilder.Sql("INSERT INTO Shifts (assignedToStation, shiftAvailable) VALUES ('S2', '2023-06-01 14:00:00')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "assignedToStation",
                table: "Shifts",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            
        }
    }
}
