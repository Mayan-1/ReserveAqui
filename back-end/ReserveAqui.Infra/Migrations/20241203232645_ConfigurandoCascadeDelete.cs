using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveAqui.Infra.Migrations
{
    /// <inheritdoc />
    public partial class ConfigurandoCascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professor_Materia_MateriaId",
                table: "Professor");

            migrationBuilder.AddForeignKey(
                name: "FK_Professor_Materia_MateriaId",
                table: "Professor",
                column: "MateriaId",
                principalTable: "Materia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professor_Materia_MateriaId",
                table: "Professor");

            migrationBuilder.AddForeignKey(
                name: "FK_Professor_Materia_MateriaId",
                table: "Professor",
                column: "MateriaId",
                principalTable: "Materia",
                principalColumn: "Id");
        }
    }
}
