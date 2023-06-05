using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTelerikProject.Data.Migrations
{
    public partial class AddTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employeeNumber = table.Column<int>(type: "int", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OverTimeRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employeeNumber = table.Column<int>(type: "int", nullable: false),
                    dateRequested = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    hasBeenAssigned = table.Column<bool>(type: "bit", nullable: false),
                    assignedToStation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OverTimeRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OverTimeRequests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "employeeNumber", "firstName", "lastName" },
                values: new object[] { 1, 123456, "John", "Doe" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "employeeNumber", "firstName", "lastName" },
                values: new object[] { 2, 234567, "Jane", "Smith" });

            migrationBuilder.InsertData(
                table: "OverTimeRequests",
                columns: new[] { "Id", "UserId", "assignedToStation", "dateCreated", "dateRequested", "employeeNumber", "hasBeenAssigned" },
                values: new object[] { 1, 1, "S1", new DateTime(2023, 5, 31, 13, 59, 37, 611, DateTimeKind.Local).AddTicks(739), new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 123456, false });

            migrationBuilder.InsertData(
                table: "OverTimeRequests",
                columns: new[] { "Id", "UserId", "assignedToStation", "dateCreated", "dateRequested", "employeeNumber", "hasBeenAssigned" },
                values: new object[] { 2, 2, "S2", new DateTime(2023, 5, 31, 13, 59, 37, 611, DateTimeKind.Local).AddTicks(770), new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 234567, true });

            migrationBuilder.CreateIndex(
                name: "IX_OverTimeRequests_UserId",
                table: "OverTimeRequests",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OverTimeRequests");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
