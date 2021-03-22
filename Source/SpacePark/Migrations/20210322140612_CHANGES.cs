using Microsoft.EntityFrameworkCore.Migrations;

namespace SpacePark.Migrations
{
    public partial class CHANGES : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonIdId",
                table: "Vehicle",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_PersonIdId",
                table: "Vehicle",
                column: "PersonIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Person_PersonIdId",
                table: "Vehicle",
                column: "PersonIdId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Person_PersonIdId",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_PersonIdId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "PersonIdId",
                table: "Vehicle");
        }
    }
}
