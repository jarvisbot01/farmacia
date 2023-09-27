using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class JWT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_empleado_rol_IdRolFk",
                table: "empleado");

            migrationBuilder.DropIndex(
                name: "IX_empleado_IdRolFk",
                table: "empleado");

            migrationBuilder.DropColumn(
                name: "IdRolFk",
                table: "empleado");

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "empleado",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "empleadoRol",
                columns: table => new
                {
                    idEmpleadoFk = table.Column<int>(type: "int", nullable: false),
                    idRolFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empleadoRol", x => new { x.idEmpleadoFk, x.idRolFk });
                    table.ForeignKey(
                        name: "FK_empleadoRol_empleado_idEmpleadoFk",
                        column: x => x.idEmpleadoFk,
                        principalTable: "empleado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_empleadoRol_rol_idRolFk",
                        column: x => x.idRolFk,
                        principalTable: "rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "refreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdEmpleadoFk = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Expires = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Revoked = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_refreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_refreshToken_empleado_IdEmpleadoFk",
                        column: x => x.IdEmpleadoFk,
                        principalTable: "empleado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_empleadoRol_idRolFk",
                table: "empleadoRol",
                column: "idRolFk");

            migrationBuilder.CreateIndex(
                name: "IX_refreshToken_IdEmpleadoFk",
                table: "refreshToken",
                column: "IdEmpleadoFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "empleadoRol");

            migrationBuilder.DropTable(
                name: "refreshToken");

            migrationBuilder.DropColumn(
                name: "password",
                table: "empleado");

            migrationBuilder.AddColumn<int>(
                name: "IdRolFk",
                table: "empleado",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_empleado_IdRolFk",
                table: "empleado",
                column: "IdRolFk");

            migrationBuilder.AddForeignKey(
                name: "FK_empleado_rol_IdRolFk",
                table: "empleado",
                column: "IdRolFk",
                principalTable: "rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
