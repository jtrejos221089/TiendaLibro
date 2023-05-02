using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructura.Data.Migrations
{
    /// <inheritdoc />
    public partial class Actualizacion10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Libros",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Clientes",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "codigo_Cliente",
                table: "Libros",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Libros",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Clientes",
                newName: "id");

            migrationBuilder.AlterColumn<int>(
                name: "codigo_Cliente",
                table: "Libros",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
