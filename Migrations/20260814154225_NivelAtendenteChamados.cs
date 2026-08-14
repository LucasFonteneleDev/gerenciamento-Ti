using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gerenciamento_Ti.Migrations
{
    /// <inheritdoc />
    public partial class NivelAtendenteChamados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NivelAtendente",
                table: "Usuario",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NivelAtendente",
                table: "Usuario");
        }
    }
}
