using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpacePark.Migrations
{
    public partial class inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Person");

            migrationBuilder.RenameColumn(
                name: "Sort",
                table: "Vehicles",
                newName: "StarShipModel");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Person",
                newName: "LastName");

            migrationBuilder.AddColumn<DateTime>(
                name: "Arrival",
                table: "Vehicles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Depature",
                table: "Vehicles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Person",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Arrival",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Depature",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Person");

            migrationBuilder.RenameColumn(
                name: "StarShipModel",
                table: "Vehicles",
                newName: "Sort");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Person",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Person",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
