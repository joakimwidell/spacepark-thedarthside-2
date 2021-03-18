using Microsoft.EntityFrameworkCore.Migrations;

namespace SpacePark.Migrations
{
    public partial class hej : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PersonID",
                table: "Vehicles",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "VehicleID",
                table: "Vehicles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PersonID",
                table: "Person",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "ParkingHouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmoutOfSpots = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingHouses", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkingHouses");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Vehicles",
                newName: "PersonID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Vehicles",
                newName: "VehicleID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Person",
                newName: "PersonID");
        }
    }
}
