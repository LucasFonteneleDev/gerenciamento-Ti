using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gerenciamento_Ti.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarFuncionarioEmEquipamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Equipamento_FuncionarioId",
                table: "Equipamento",
                column: "FuncionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamento_Funcionario_FuncionarioId",
                table: "Equipamento",
                column: "FuncionarioId",
                principalTable: "Funcionario",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipamento_Funcionario_FuncionarioId",
                table: "Equipamento");

            migrationBuilder.DropIndex(
                name: "IX_Equipamento_FuncionarioId",
                table: "Equipamento");
        }
    }
}
