using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveAqui.Migrations
{
    /// <inheritdoc />
    public partial class AjustandoTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Administrador_Instituicao_InstituicaoId",
                table: "Administrador");

            migrationBuilder.DropForeignKey(
                name: "FK_Professor_Instituicao_InstituicaoId",
                table: "Professor");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservaMaterial_Material_MaterialId",
                table: "ReservaMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservaMaterial_Professor_ProfessorId",
                table: "ReservaMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservaSala_Professor_ProfessorId",
                table: "ReservaSala");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservaSala_Sala_SalaId",
                table: "ReservaSala");

            migrationBuilder.DropColumn(
                name: "Turno",
                table: "ReservaSala");

            migrationBuilder.DropColumn(
                name: "Turno",
                table: "ReservaMaterial");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Sala",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SalaId",
                table: "ReservaSala",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProfessorId",
                table: "ReservaSala",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "ReservaSala",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TurnoId",
                table: "ReservaSala",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ProfessorId",
                table: "ReservaMaterial",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaterialId",
                table: "ReservaMaterial",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "ReservaMaterial",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TurnoId",
                table: "ReservaMaterial",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Professor",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "Professor",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Professor",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InstituicaoId",
                table: "Professor",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Professor",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Professor",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Professor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Material",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Materia",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Instituicao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Administrador",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "Administrador",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Administrador",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InstituicaoId",
                table: "Administrador",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Administrador",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Administrador",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Administrador",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Turno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turno", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Turma",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TurnoId = table.Column<int>(type: "int", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turma", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turma_Turno_TurnoId",
                        column: x => x.TurnoId,
                        principalTable: "Turno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReservaSala_TurnoId",
                table: "ReservaSala",
                column: "TurnoId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaMaterial_TurnoId",
                table: "ReservaMaterial",
                column: "TurnoId");

            migrationBuilder.CreateIndex(
                name: "IX_Turma_TurnoId",
                table: "Turma",
                column: "TurnoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Administrador_Instituicao_InstituicaoId",
                table: "Administrador",
                column: "InstituicaoId",
                principalTable: "Instituicao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Professor_Instituicao_InstituicaoId",
                table: "Professor",
                column: "InstituicaoId",
                principalTable: "Instituicao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservaMaterial_Material_MaterialId",
                table: "ReservaMaterial",
                column: "MaterialId",
                principalTable: "Material",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservaMaterial_Professor_ProfessorId",
                table: "ReservaMaterial",
                column: "ProfessorId",
                principalTable: "Professor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservaMaterial_Turno_TurnoId",
                table: "ReservaMaterial",
                column: "TurnoId",
                principalTable: "Turno",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservaSala_Professor_ProfessorId",
                table: "ReservaSala",
                column: "ProfessorId",
                principalTable: "Professor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservaSala_Sala_SalaId",
                table: "ReservaSala",
                column: "SalaId",
                principalTable: "Sala",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservaSala_Turno_TurnoId",
                table: "ReservaSala",
                column: "TurnoId",
                principalTable: "Turno",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Administrador_Instituicao_InstituicaoId",
                table: "Administrador");

            migrationBuilder.DropForeignKey(
                name: "FK_Professor_Instituicao_InstituicaoId",
                table: "Professor");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservaMaterial_Material_MaterialId",
                table: "ReservaMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservaMaterial_Professor_ProfessorId",
                table: "ReservaMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservaMaterial_Turno_TurnoId",
                table: "ReservaMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservaSala_Professor_ProfessorId",
                table: "ReservaSala");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservaSala_Sala_SalaId",
                table: "ReservaSala");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservaSala_Turno_TurnoId",
                table: "ReservaSala");

            migrationBuilder.DropTable(
                name: "Turma");

            migrationBuilder.DropTable(
                name: "Turno");

            migrationBuilder.DropIndex(
                name: "IX_ReservaSala_TurnoId",
                table: "ReservaSala");

            migrationBuilder.DropIndex(
                name: "IX_ReservaMaterial_TurnoId",
                table: "ReservaMaterial");

            migrationBuilder.DropColumn(
                name: "TurnoId",
                table: "ReservaSala");

            migrationBuilder.DropColumn(
                name: "TurnoId",
                table: "ReservaMaterial");

            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Professor");

            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Administrador");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Sala",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "SalaId",
                table: "ReservaSala",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProfessorId",
                table: "ReservaSala",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "ReservaSala",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Turno",
                table: "ReservaSala",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProfessorId",
                table: "ReservaMaterial",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MaterialId",
                table: "ReservaMaterial",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "ReservaMaterial",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Turno",
                table: "ReservaMaterial",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Professor",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "Professor",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Professor",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<int>(
                name: "InstituicaoId",
                table: "Professor",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Professor",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Professor",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Material",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Materia",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Instituicao",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Administrador",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "Administrador",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Administrador",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<int>(
                name: "InstituicaoId",
                table: "Administrador",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Administrador",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Administrador",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AddForeignKey(
                name: "FK_Administrador_Instituicao_InstituicaoId",
                table: "Administrador",
                column: "InstituicaoId",
                principalTable: "Instituicao",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Professor_Instituicao_InstituicaoId",
                table: "Professor",
                column: "InstituicaoId",
                principalTable: "Instituicao",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservaMaterial_Material_MaterialId",
                table: "ReservaMaterial",
                column: "MaterialId",
                principalTable: "Material",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservaMaterial_Professor_ProfessorId",
                table: "ReservaMaterial",
                column: "ProfessorId",
                principalTable: "Professor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservaSala_Professor_ProfessorId",
                table: "ReservaSala",
                column: "ProfessorId",
                principalTable: "Professor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservaSala_Sala_SalaId",
                table: "ReservaSala",
                column: "SalaId",
                principalTable: "Sala",
                principalColumn: "Id");
        }
    }
}
