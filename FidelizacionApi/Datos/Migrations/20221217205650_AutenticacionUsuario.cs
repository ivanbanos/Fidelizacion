using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datos.Migrations
{
    public partial class AutenticacionUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InformacionAdicional_Fidelizado_FidelizadoId",
                table: "InformacionAdicional");

            migrationBuilder.DropIndex(
                name: "IX_InformacionAdicional_FidelizadoId",
                table: "InformacionAdicional");

            migrationBuilder.DropColumn(
                name: "FidelizadoId",
                table: "InformacionAdicional");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaNacimiento",
                table: "InformacionAdicional",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InformacionAdicionalId",
                table: "Fidelizado",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Perfil = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fidelizado_InformacionAdicionalId",
                table: "Fidelizado",
                column: "InformacionAdicionalId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_EstadoId",
                table: "Usuario",
                column: "EstadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fidelizado_InformacionAdicional_InformacionAdicionalId",
                table: "Fidelizado",
                column: "InformacionAdicionalId",
                principalTable: "InformacionAdicional",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fidelizado_InformacionAdicional_InformacionAdicionalId",
                table: "Fidelizado");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Fidelizado_InformacionAdicionalId",
                table: "Fidelizado");

            migrationBuilder.DropColumn(
                name: "InformacionAdicionalId",
                table: "Fidelizado");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaNacimiento",
                table: "InformacionAdicional",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "FidelizadoId",
                table: "InformacionAdicional",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_InformacionAdicional_FidelizadoId",
                table: "InformacionAdicional",
                column: "FidelizadoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InformacionAdicional_Fidelizado_FidelizadoId",
                table: "InformacionAdicional",
                column: "FidelizadoId",
                principalTable: "Fidelizado",
                principalColumn: "Id");
        }
    }
}
