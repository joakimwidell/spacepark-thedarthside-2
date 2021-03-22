using Microsoft.EntityFrameworkCore.Migrations;

namespace SpacePark.Migrations
{
    public partial class changeOfClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Person");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Person",
                newName: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_PersonId",
                table: "Vehicle",
                column: "PersonId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Person_PersonId",
                table: "Vehicle",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Person_PersonId",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_PersonId",
                table: "Vehicle");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Person",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Person",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
