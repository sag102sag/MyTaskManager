using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTaskManager.Migrations
{
    /// <inheritdoc />
    public partial class NuevasTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarea_Usuario_UsuarioId",
                table: "Tarea");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tarea",
                table: "Tarea");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Tarea",
                newName: "Tareas");

            migrationBuilder.RenameIndex(
                name: "IX_Tarea_UsuarioId",
                table: "Tareas",
                newName: "IX_Tareas_UsuarioId");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Tareas",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tareas",
                table: "Tareas",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_CategoriaId",
                table: "Tareas",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tareas_Categorias_CategoriaId",
                table: "Tareas",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tareas_Usuarios_UsuarioId",
                table: "Tareas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tareas_Categorias_CategoriaId",
                table: "Tareas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tareas_Usuarios_UsuarioId",
                table: "Tareas");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tareas",
                table: "Tareas");

            migrationBuilder.DropIndex(
                name: "IX_Tareas_CategoriaId",
                table: "Tareas");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Tareas");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "Usuario");

            migrationBuilder.RenameTable(
                name: "Tareas",
                newName: "Tarea");

            migrationBuilder.RenameIndex(
                name: "IX_Tareas_UsuarioId",
                table: "Tarea",
                newName: "IX_Tarea_UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tarea",
                table: "Tarea",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarea_Usuario_UsuarioId",
                table: "Tarea",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
