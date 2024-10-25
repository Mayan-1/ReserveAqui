using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveAqui.Migrations
{
    /// <inheritdoc />
    public partial class InitialSqlServer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instituicao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instituicao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sala",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sala", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Administrador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstituicaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Administrador_Instituicao_InstituicaoId",
                        column: x => x.InstituicaoId,
                        principalTable: "Instituicao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Professor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstituicaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Professor_Instituicao_InstituicaoId",
                        column: x => x.InstituicaoId,
                        principalTable: "Instituicao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProfessorMateria",
                columns: table => new
                {
                    ProfessorId = table.Column<int>(type: "int", nullable: false),
                    MateriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessorMateria", x => new { x.MateriaId, x.ProfessorId });
                    table.ForeignKey(
                        name: "FK_ProfessorMateria_Materia_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "Materia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessorMateria_Professor_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservaMaterial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateOnly>(type: "date", nullable: false),
                    Turno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialId = table.Column<int>(type: "int", nullable: true),
                    ProfessorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaMaterial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservaMaterial_Material_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Material",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReservaMaterial_Professor_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReservaSala",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateOnly>(type: "date", nullable: false),
                    Turno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalaId = table.Column<int>(type: "int", nullable: true),
                    ProfessorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaSala", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservaSala_Professor_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReservaSala_Sala_SalaId",
                        column: x => x.SalaId,
                        principalTable: "Sala",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administrador_InstituicaoId",
                table: "Administrador",
                column: "InstituicaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Professor_InstituicaoId",
                table: "Professor",
                column: "InstituicaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorMateria_ProfessorId",
                table: "ProfessorMateria",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaMaterial_MaterialId",
                table: "ReservaMaterial",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaMaterial_ProfessorId",
                table: "ReservaMaterial",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaSala_ProfessorId",
                table: "ReservaSala",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaSala_SalaId",
                table: "ReservaSala",
                column: "SalaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrador");

            migrationBuilder.DropTable(
                name: "ProfessorMateria");

            migrationBuilder.DropTable(
                name: "ReservaMaterial");

            migrationBuilder.DropTable(
                name: "ReservaSala");

            migrationBuilder.DropTable(
                name: "Materia");

            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropTable(
                name: "Professor");

            migrationBuilder.DropTable(
                name: "Sala");

            migrationBuilder.DropTable(
                name: "Instituicao");
        }
    }
}
