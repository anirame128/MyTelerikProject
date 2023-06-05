using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTelerikProject.Data.Migrations
{
    public partial class AddStationTableToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    assignedToStation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lineRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    employeeNUmber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.Id);
                });

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stations");

        }
    }
}
