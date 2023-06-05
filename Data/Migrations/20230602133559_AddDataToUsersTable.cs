using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTelerikProject.Data.Migrations
{
    public partial class AddDataToUsersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO Users (employeeNumber, firstName, lastName, isDiscontinued)
                VALUES (458291, 'Jasmeet', 'Shah', 0);

                INSERT INTO Users (employeeNumber, firstName, lastName, isDiscontinued)
                VALUES (736425, 'Ani', 'Ram', 0);

               
            ");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
