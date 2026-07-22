using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gerenciamento_Ti.Migrations
{
    /// <inheritdoc />
    public partial class ChamadosRequisitanteInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Chamado",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Chamado_UsuarioId",
                table: "Chamado",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chamado_Usuario_UsuarioId",
                table: "Chamado",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chamado_Usuario_UsuarioId",
                table: "Chamado");

            migrationBuilder.DropIndex(
                name: "IX_Chamado_UsuarioId",
                table: "Chamado");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Chamado");
        }
    }
}
