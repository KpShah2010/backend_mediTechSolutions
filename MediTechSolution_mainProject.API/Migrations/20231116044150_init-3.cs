using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediTechSolution_mainProject.API.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MediceneByCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MediceneName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicenePrescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MediceneRelated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SideEffect = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MediceneCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediceneByCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediceneByCategory_MediceneCategory_MediceneCategoryId",
                        column: x => x.MediceneCategoryId,
                        principalTable: "MediceneCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MediceneByCategory_MediceneCategoryId",
                table: "MediceneByCategory",
                column: "MediceneCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MediceneByCategory");
        }
    }
}
