using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediTechSolution_mainProject.API.Migrations
{
    /// <inheritdoc />
    public partial class helpdesks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddHelpDesks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ticketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Issues = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddHelpDesks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddHelpDesks_Doctors_DocId",
                        column: x => x.DocId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddHelpDesks_DocId",
                table: "AddHelpDesks",
                column: "DocId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddHelpDesks");
        }
    }
}
