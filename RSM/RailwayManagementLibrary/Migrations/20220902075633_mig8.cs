using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RailwayManagementLibrary.Migrations
{
    public partial class mig8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Reports_TrainId",
                table: "Reports",
                column: "TrainId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Trains_TrainId",
                table: "Reports",
                column: "TrainId",
                principalTable: "Trains",
                principalColumn: "TrainId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Trains_TrainId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_TrainId",
                table: "Reports");
        }
    }
}
