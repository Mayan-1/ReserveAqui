using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveAqui.Migrations
{
    /// <inheritdoc />
    public partial class AjusteDeTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoraFim",
                table: "ReservaSala");

            migrationBuilder.DropColumn(
                name: "HoraInicio",
                table: "ReservaSala");

            migrationBuilder.DropColumn(
                name: "HoraFim",
                table: "ReservaMaterial");

            migrationBuilder.DropColumn(
                name: "HoraInicio",
                table: "ReservaMaterial");

            migrationBuilder.AddColumn<string>(
                name: "Turno",
                table: "ReservaSala",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Turno",
                table: "ReservaMaterial",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Turno",
                table: "ReservaSala");

            migrationBuilder.DropColumn(
                name: "Turno",
                table: "ReservaMaterial");

            migrationBuilder.AddColumn<DateTime>(
                name: "HoraFim",
                table: "ReservaSala",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "HoraInicio",
                table: "ReservaSala",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "HoraFim",
                table: "ReservaMaterial",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "HoraInicio",
                table: "ReservaMaterial",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
