using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructura.Data.Migrations
{
    /// <inheritdoc />
    public partial class ClientesLibros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigo_Cliente = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    nombre_Cliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cedula_Cliente = table.Column<int>(type: "int", maxLength: 9, nullable: false),
                    fn_Cliente = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigo_Libro = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    nombre_Libro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nombre_Empresa = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    descripcion_Libro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado_Libro = table.Column<bool>(type: "bit", nullable: false),
                    precio_Libro = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    codigo_Cliente = table.Column<int>(type: "int", nullable: false),
                    fechaIngreso_Libro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaRetiro_Libro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClienteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.id);
                    table.ForeignKey(
                        name: "FK_Libros_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Libros_ClienteId",
                table: "Libros",
                column: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Libros");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
