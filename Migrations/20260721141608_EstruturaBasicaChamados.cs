using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace gerenciamento_Ti.Migrations
{
    /// <inheritdoc />
    public partial class EstruturaBasicaChamados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chamado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Solucao = table.Column<string>(type: "text", nullable: true),
                    Inicio = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Fim = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chamado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioChamado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChamadoId = table.Column<int>(type: "integer", nullable: false),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    Tipo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioChamado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioChamado_Chamado_ChamadoId",
                        column: x => x.ChamadoId,
                        principalTable: "Chamado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioChamado_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MensagemChamado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChamadoId = table.Column<int>(type: "integer", nullable: false),
                    UsuarioChamadoId = table.Column<int>(type: "integer", nullable: false),
                    Texto = table.Column<string>(type: "text", nullable: false),
                    Envio = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Enviado = table.Column<bool>(type: "boolean", nullable: false),
                    ConfirmaRecebido = table.Column<bool>(type: "boolean", nullable: false),
                    UsuarioId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MensagemChamado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MensagemChamado_Chamado_ChamadoId",
                        column: x => x.ChamadoId,
                        principalTable: "Chamado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MensagemChamado_UsuarioChamado_UsuarioChamadoId",
                        column: x => x.UsuarioChamadoId,
                        principalTable: "UsuarioChamado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MensagemChamado_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MensagemChamado_ChamadoId",
                table: "MensagemChamado",
                column: "ChamadoId");

            migrationBuilder.CreateIndex(
                name: "IX_MensagemChamado_UsuarioChamadoId",
                table: "MensagemChamado",
                column: "UsuarioChamadoId");

            migrationBuilder.CreateIndex(
                name: "IX_MensagemChamado_UsuarioId",
                table: "MensagemChamado",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioChamado_ChamadoId",
                table: "UsuarioChamado",
                column: "ChamadoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioChamado_UsuarioId",
                table: "UsuarioChamado",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MensagemChamado");

            migrationBuilder.DropTable(
                name: "UsuarioChamado");

            migrationBuilder.DropTable(
                name: "Chamado");
        }
    }
}
