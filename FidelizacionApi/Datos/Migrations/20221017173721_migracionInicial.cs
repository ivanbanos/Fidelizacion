using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datos.Migrations
{
    public partial class migracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoVencimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoVencimiento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Compania",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VigenciaPuntos = table.Column<int>(type: "int", nullable: false),
                    TipoVencimientoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compania", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compania_TipoVencimiento_TipoVencimientoId",
                        column: x => x.TipoVencimientoId,
                        principalTable: "TipoVencimiento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compania_TipoVencimientoId",
                table: "Compania",
                column: "TipoVencimientoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compania");

            migrationBuilder.DropTable(
                name: "TipoVencimiento");
        }
    }
}
