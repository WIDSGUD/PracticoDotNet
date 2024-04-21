using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticoDotNet.Migrations
{
    /// <inheritdoc />
    public partial class NuevosDatosParaPaisesYConfederacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "Paises",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Confederacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Fundacion = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confederacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Deporte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deporte", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Confederacion",
                columns: new[] { "Id", "Fundacion", "Nombre" },
                values: new object[] { 1, new DateOnly(1, 1, 1), "AUF" });

            migrationBuilder.InsertData(
                table: "Deporte",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 1, "Futbol" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Confederacion");

            migrationBuilder.DropTable(
                name: "Deporte");

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "Paises",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);
        }
    }
}
