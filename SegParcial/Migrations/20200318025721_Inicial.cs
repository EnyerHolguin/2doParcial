using Microsoft.EntityFrameworkCore.Migrations;

namespace SegParcial.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Llamadas",
                columns: table => new
                {
                    Llamadaid = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Llamadas", x => x.Llamadaid);
                });

            migrationBuilder.CreateTable(
                name: "LlamadasDetalles",
                columns: table => new
                {
                    IdDetalle = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Problema = table.Column<string>(nullable: true),
                    Solucion = table.Column<string>(nullable: true),
                    Llamadaid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LlamadasDetalles", x => x.IdDetalle);
                    table.ForeignKey(
                        name: "FK_LlamadasDetalles_Llamadas_Llamadaid",
                        column: x => x.Llamadaid,
                        principalTable: "Llamadas",
                        principalColumn: "Llamadaid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LlamadasDetalles_Llamadaid",
                table: "LlamadasDetalles",
                column: "Llamadaid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LlamadasDetalles");

            migrationBuilder.DropTable(
                name: "Llamadas");
        }
    }
}
