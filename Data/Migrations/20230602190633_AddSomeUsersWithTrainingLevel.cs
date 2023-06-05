using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTelerikProject.Data.Migrations
{
    public partial class AddSomeUsersWithTrainingLevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Users (employeeNumber, firstName, lastName, isDiscontinued, trainingLevel) VALUES (425678, 'John', 'Ryan', 0, 'Training')");
            migrationBuilder.Sql("INSERT INTO Users (employeeNumber, firstName, lastName, isDiscontinued, trainingLevel) VALUES (564738, 'Yusef', 'Burr', 0, 'Skilled')");
            migrationBuilder.Sql("INSERT INTO Users (employeeNumber, firstName, lastName, isDiscontinued, trainingLevel) VALUES (905647, 'Michael', 'Johnson', 0, 'Skilled')");
            migrationBuilder.Sql("INSERT INTO Users (employeeNumber, firstName, lastName, isDiscontinued, trainingLevel) VALUES (126784, 'Sarah', 'Williams', 0, 'Training')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
