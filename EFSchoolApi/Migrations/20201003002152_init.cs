using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFSchoolApi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Escuela",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Dpto = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Tipo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escuela", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estudiante",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Correo = table.Column<string>(nullable: true),
                    Foto = table.Column<string>(nullable: true),
                    Fechanac = table.Column<DateTime>(nullable: false),
                    EscuelaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiante", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estudiante_Escuela_EscuelaId",
                        column: x => x.EscuelaId,
                        principalTable: "Escuela",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profesor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Correo = table.Column<string>(nullable: true),
                    Foto = table.Column<string>(nullable: true),
                    Fechanac = table.Column<DateTime>(nullable: false),
                    EscuelaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profesor_Escuela_EscuelaId",
                        column: x => x.EscuelaId,
                        principalTable: "Escuela",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trabajo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Nota = table.Column<int>(nullable: false),
                    Fechaent = table.Column<string>(nullable: true),
                    EstudianteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trabajo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trabajo_Estudiante_EstudianteId",
                        column: x => x.EstudianteId,
                        principalTable: "Estudiante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Materia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    ProfesorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materia_Profesor_ProfesorId",
                        column: x => x.ProfesorId,
                        principalTable: "Profesor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estudiante_EscuelaId",
                table: "Estudiante",
                column: "EscuelaId");

            migrationBuilder.CreateIndex(
                name: "IX_Materia_ProfesorId",
                table: "Materia",
                column: "ProfesorId");

            migrationBuilder.CreateIndex(
                name: "IX_Profesor_EscuelaId",
                table: "Profesor",
                column: "EscuelaId");

            migrationBuilder.CreateIndex(
                name: "IX_Trabajo_EstudianteId",
                table: "Trabajo",
                column: "EstudianteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Materia");

            migrationBuilder.DropTable(
                name: "Trabajo");

            migrationBuilder.DropTable(
                name: "Profesor");

            migrationBuilder.DropTable(
                name: "Estudiante");

            migrationBuilder.DropTable(
                name: "Escuela");
        }
    }
}
