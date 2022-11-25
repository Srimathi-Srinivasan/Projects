using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirstEg.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "100, 1"),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    doctorDocID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientID);
                    table.ForeignKey(
                        name: "FK_Patients_Doctors_doctorDocID",
                        column: x => x.doctorDocID,
                        principalTable: "Doctors",
                        principalColumn: "DocID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_doctorDocID",
                table: "Patients",
                column: "doctorDocID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
