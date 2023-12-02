using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Lazospetshop.Migrations
{
    /// <inheritdoc />
    public partial class EditCarrito : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carrito_Usuario_UsuarioId",
                table: "Carrito");

            migrationBuilder.DropIndex(
                name: "IX_Carrito_UsuarioId",
                table: "Carrito");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Carrito");

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_IdUsuario",
                table: "Carrito",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Carrito_Usuario_IdUsuario",
                table: "Carrito",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "idUsuario",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carrito_Usuario_IdUsuario",
                table: "Carrito");

            migrationBuilder.DropIndex(
                name: "IX_Carrito_IdUsuario",
                table: "Carrito");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Carrito",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_UsuarioId",
                table: "Carrito",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carrito_Usuario_UsuarioId",
                table: "Carrito",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "idUsuario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
