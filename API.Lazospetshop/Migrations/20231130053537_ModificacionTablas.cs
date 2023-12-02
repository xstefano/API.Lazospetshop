using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Lazospetshop.Migrations
{
    /// <inheritdoc />
    public partial class ModificacionTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicio_TipoServicio_TipoServicioId",
                table: "Servicio");

            migrationBuilder.DropTable(
                name: "TipoServicio");

            migrationBuilder.DropIndex(
                name: "IX_Servicio_TipoServicioId",
                table: "Servicio");

            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Servicio");

            migrationBuilder.DropColumn(
                name: "TipoServicioId",
                table: "Servicio");

            migrationBuilder.RenameColumn(
                name: "NumeroContacto",
                table: "Servicio",
                newName: "NombreServicio");

            migrationBuilder.AddColumn<string>(
                name: "DescripcionServicio",
                table: "Servicio",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "PrecioServicio",
                table: "Servicio",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRegistro",
                table: "DetalleServicio",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescripcionServicio",
                table: "Servicio");

            migrationBuilder.DropColumn(
                name: "PrecioServicio",
                table: "Servicio");

            migrationBuilder.DropColumn(
                name: "FechaRegistro",
                table: "DetalleServicio");

            migrationBuilder.RenameColumn(
                name: "NombreServicio",
                table: "Servicio",
                newName: "NumeroContacto");

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Servicio",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TipoServicioId",
                table: "Servicio",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TipoServicio",
                columns: table => new
                {
                    idTipoServicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoServicio", x => x.idTipoServicio);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Servicio_TipoServicioId",
                table: "Servicio",
                column: "TipoServicioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicio_TipoServicio_TipoServicioId",
                table: "Servicio",
                column: "TipoServicioId",
                principalTable: "TipoServicio",
                principalColumn: "idTipoServicio",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
