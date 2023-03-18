using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datos.Migrations
{
    public partial class InclusionPerfil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Perfil",
                table: "Usuario",
                newName: "PerfilId");

            migrationBuilder.CreateTable(
                name: "Perfil",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Perfil",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Super Administrador" },
                    { 2, "Administrador" },
                    { 3, "Supervisor" },
                    { 4, "Fidelizador" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_PerfilId",
                table: "Usuario",
                column: "PerfilId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Perfil_PerfilId",
                table: "Usuario",
                column: "PerfilId",
                principalTable: "Perfil",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Perfil_PerfilId",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "Perfil");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_PerfilId",
                table: "Usuario");

            migrationBuilder.RenameColumn(
                name: "PerfilId",
                table: "Usuario",
                newName: "Perfil");
        }
    }
}
