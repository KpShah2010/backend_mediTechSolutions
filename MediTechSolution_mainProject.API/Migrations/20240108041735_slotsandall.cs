using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediTechSolution_mainProject.API.Migrations
{
    /// <inheritdoc />
    public partial class slotsandall : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddHelpDesks_Doctors_DocId",
                table: "AddHelpDesks");

            migrationBuilder.DropForeignKey(
                name: "FK_SendingRequestToDoctors_Doctors_DoctorId",
                table: "SendingRequestToDoctors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddHelpDesks",
                table: "AddHelpDesks");

            migrationBuilder.RenameTable(
                name: "AddHelpDesks",
                newName: "AddHelpDesk");

            migrationBuilder.RenameColumn(
                name: "isAccepted",
                table: "SendingRequestToDoctors",
                newName: "IsAccepted");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "SendingRequestToDoctors",
                newName: "DoctorID");

            migrationBuilder.RenameIndex(
                name: "IX_SendingRequestToDoctors_DoctorId",
                table: "SendingRequestToDoctors",
                newName: "IX_SendingRequestToDoctors_DoctorID");

            migrationBuilder.RenameColumn(
                name: "Issues",
                table: "AddHelpDesk",
                newName: "issues");

            migrationBuilder.RenameColumn(
                name: "DocId",
                table: "AddHelpDesk",
                newName: "doctId");

            migrationBuilder.RenameIndex(
                name: "IX_AddHelpDesks_DocId",
                table: "AddHelpDesk",
                newName: "IX_AddHelpDesk_doctId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AddHelpDesk",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddHelpDesk",
                table: "AddHelpDesk",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ReplyToPatientsModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReplyMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timing = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReplyToPatientsModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReplyToPatientsModels_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Slots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slots", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReplyToPatientsModels_UserId",
                table: "ReplyToPatientsModels",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddHelpDesk_Doctors_doctId",
                table: "AddHelpDesk",
                column: "doctId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SendingRequestToDoctors_Doctors_DoctorID",
                table: "SendingRequestToDoctors",
                column: "DoctorID",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddHelpDesk_Doctors_doctId",
                table: "AddHelpDesk");

            migrationBuilder.DropForeignKey(
                name: "FK_SendingRequestToDoctors_Doctors_DoctorID",
                table: "SendingRequestToDoctors");

            migrationBuilder.DropTable(
                name: "ReplyToPatientsModels");

            migrationBuilder.DropTable(
                name: "Slots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddHelpDesk",
                table: "AddHelpDesk");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AddHelpDesk");

            migrationBuilder.RenameTable(
                name: "AddHelpDesk",
                newName: "AddHelpDesks");

            migrationBuilder.RenameColumn(
                name: "IsAccepted",
                table: "SendingRequestToDoctors",
                newName: "isAccepted");

            migrationBuilder.RenameColumn(
                name: "DoctorID",
                table: "SendingRequestToDoctors",
                newName: "DoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_SendingRequestToDoctors_DoctorID",
                table: "SendingRequestToDoctors",
                newName: "IX_SendingRequestToDoctors_DoctorId");

            migrationBuilder.RenameColumn(
                name: "issues",
                table: "AddHelpDesks",
                newName: "Issues");

            migrationBuilder.RenameColumn(
                name: "doctId",
                table: "AddHelpDesks",
                newName: "DocId");

            migrationBuilder.RenameIndex(
                name: "IX_AddHelpDesk_doctId",
                table: "AddHelpDesks",
                newName: "IX_AddHelpDesks_DocId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddHelpDesks",
                table: "AddHelpDesks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AddHelpDesks_Doctors_DocId",
                table: "AddHelpDesks",
                column: "DocId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SendingRequestToDoctors_Doctors_DoctorId",
                table: "SendingRequestToDoctors",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
