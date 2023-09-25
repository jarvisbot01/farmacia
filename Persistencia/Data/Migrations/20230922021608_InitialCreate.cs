using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase().Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder
                .CreateTable(
                    name: "cliente",
                    columns: table =>
                        new
                        {
                            Id = table
                                .Column<int>(type: "int", nullable: false)
                                .Annotation(
                                    "MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn
                                ),
                            cedula = table.Column<int>(type: "int", nullable: false),
                            nombre = table
                                .Column<string>(type: "longtext", nullable: false)
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            direccion = table
                                .Column<string>(type: "longtext", nullable: false)
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            telefono = table
                                .Column<string>(type: "longtext", nullable: false)
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            email = table
                                .Column<string>(type: "longtext", nullable: false)
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            estaRegistrado = table.Column<bool>(
                                type: "tinyint(1)",
                                nullable: false
                            ),
                            updatedAt = table.Column<DateTime>(
                                type: "datetime(6)",
                                nullable: false,
                                defaultValueSql: "now()"
                            ),
                            createdAt = table.Column<DateTime>(
                                type: "datetime(6)",
                                nullable: false,
                                defaultValueSql: "now()"
                            )
                        },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_cliente", x => x.Id);
                    }
                )
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder
                .CreateTable(
                    name: "medicamento",
                    columns: table =>
                        new
                        {
                            Id = table
                                .Column<int>(type: "int", nullable: false)
                                .Annotation(
                                    "MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn
                                ),
                            nombre = table
                                .Column<string>(type: "longtext", nullable: false)
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            concentracion = table
                                .Column<string>(type: "longtext", nullable: false)
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            precio = table
                                .Column<string>(type: "longtext", nullable: false)
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            stock = table
                                .Column<string>(type: "longtext", nullable: false)
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            contraindicaciones = table
                                .Column<string>(type: "longtext", nullable: false)
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            dosisRecomendada = table
                                .Column<string>(type: "longtext", nullable: false)
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            fechaExpedicion = table.Column<DateTime>(
                                type: "datetime(6)",
                                nullable: false
                            ),
                            createdAt = table.Column<DateTime>(
                                type: "datetime(6)",
                                nullable: false,
                                defaultValueSql: "now()"
                            )
                        },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_medicamento", x => x.Id);
                    }
                )
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder
                .CreateTable(
                    name: "proveedor",
                    columns: table =>
                        new
                        {
                            Id = table
                                .Column<int>(type: "int", nullable: false)
                                .Annotation(
                                    "MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn
                                ),
                            nombre = table
                                .Column<string>(type: "longtext", nullable: false)
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            direccion = table
                                .Column<string>(type: "longtext", nullable: false)
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            telefono = table
                                .Column<string>(type: "longtext", nullable: false)
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            email = table
                                .Column<string>(type: "longtext", nullable: false)
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            updated_at = table.Column<DateTime>(
                                type: "datetime(6)",
                                nullable: false,
                                defaultValueSql: "now()"
                            ),
                            created_at = table.Column<DateTime>(
                                type: "datetime(6)",
                                nullable: false,
                                defaultValueSql: "now()"
                            )
                        },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_proveedor", x => x.Id);
                    }
                )
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder
                .CreateTable(
                    name: "rol",
                    columns: table =>
                        new
                        {
                            Id = table
                                .Column<int>(type: "int", nullable: false)
                                .Annotation(
                                    "MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn
                                ),
                            nombre = table
                                .Column<string>(type: "longtext", nullable: false)
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            descripcion = table
                                .Column<string>(type: "longtext", nullable: false)
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            updated_at = table.Column<DateTime>(
                                type: "datetime(6)",
                                nullable: false,
                                defaultValueSql: "now()"
                            ),
                            created_at = table.Column<DateTime>(
                                type: "datetime(6)",
                                nullable: false,
                                defaultValueSql: "now()"
                            )
                        },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_rol", x => x.Id);
                    }
                )
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder
                .CreateTable(
                    name: "recetaMedica",
                    columns: table =>
                        new
                        {
                            Id = table
                                .Column<int>(type: "int", nullable: false)
                                .Annotation(
                                    "MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn
                                ),
                            IdClienteFk = table.Column<int>(type: "int", nullable: false),
                            token = table
                                .Column<string>(type: "longtext", nullable: false)
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            detalle = table
                                .Column<string>(type: "longtext", nullable: false)
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            fechaEmision = table.Column<DateOnly>(type: "date", nullable: false),
                            createdAt = table.Column<DateTime>(
                                type: "datetime(6)",
                                nullable: false,
                                defaultValueSql: "now()"
                            )
                        },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_recetaMedica", x => x.Id);
                        table.ForeignKey(
                            name: "FK_recetaMedica_cliente_IdClienteFk",
                            column: x => x.IdClienteFk,
                            principalTable: "cliente",
                            principalColumn: "Id",
                            onDelete: ReferentialAction.Cascade
                        );
                    }
                )
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder
                .CreateTable(
                    name: "compra",
                    columns: table =>
                        new
                        {
                            Id = table
                                .Column<int>(type: "int", nullable: false)
                                .Annotation(
                                    "MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn
                                ),
                            IdProveedorFk = table.Column<int>(type: "int", nullable: false),
                            fechaCompra = table.Column<DateTime>(
                                type: "datetime(6)",
                                nullable: false
                            ),
                            precioTotal = table.Column<int>(type: "int", nullable: false),
                            createdAt = table.Column<DateTime>(
                                type: "datetime(6)",
                                nullable: false,
                                defaultValueSql: "now()"
                            )
                        },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_compra", x => x.Id);
                        table.ForeignKey(
                            name: "FK_compra_proveedor_IdProveedorFk",
                            column: x => x.IdProveedorFk,
                            principalTable: "proveedor",
                            principalColumn: "Id",
                            onDelete: ReferentialAction.Cascade
                        );
                    }
                )
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder
                .CreateTable(
                    name: "empleado",
                    columns: table =>
                        new
                        {
                            Id = table
                                .Column<int>(type: "int", nullable: false)
                                .Annotation(
                                    "MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn
                                ),
                            RolIdFk = table.Column<int>(type: "int", nullable: false),
                            cedula = table.Column<int>(type: "int", nullable: false),
                            nombre = table
                                .Column<string>(type: "longtext", nullable: false)
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            direccion = table
                                .Column<string>(type: "longtext", nullable: false)
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            telefono = table
                                .Column<string>(type: "longtext", nullable: false)
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            email = table
                                .Column<string>(type: "longtext", nullable: false)
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            UpdatedAt = table.Column<DateTime>(
                                type: "datetime(6)",
                                nullable: false
                            ),
                            createdAt = table.Column<DateTime>(
                                type: "datetime(6)",
                                nullable: false,
                                defaultValueSql: "now()"
                            )
                        },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_empleado", x => x.Id);
                        table.ForeignKey(
                            name: "FK_empleado_rol_RolIdFk",
                            column: x => x.RolIdFk,
                            principalTable: "rol",
                            principalColumn: "Id",
                            onDelete: ReferentialAction.Cascade
                        );
                    }
                )
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder
                .CreateTable(
                    name: "lote",
                    columns: table =>
                        new
                        {
                            Id = table
                                .Column<int>(type: "int", nullable: false)
                                .Annotation(
                                    "MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn
                                ),
                            IdMedicamentoFk = table.Column<int>(type: "int", nullable: false),
                            IdCompraFk = table.Column<int>(type: "int", nullable: false),
                            fechaVencimiento = table.Column<DateTime>(
                                type: "datetime(6)",
                                nullable: false
                            ),
                            cantidad = table.Column<int>(type: "int", nullable: false),
                            precioUnitario = table.Column<int>(type: "int", nullable: false),
                            precioCompra = table.Column<int>(type: "int", nullable: false),
                            updatedAt = table.Column<DateTime>(
                                type: "datetime(6)",
                                nullable: false,
                                defaultValueSql: "now()"
                            ),
                            createdAt = table.Column<DateTime>(
                                type: "datetime(6)",
                                nullable: false,
                                defaultValueSql: "now()"
                            )
                        },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_lote", x => x.Id);
                        table.ForeignKey(
                            name: "FK_lote_compra_IdCompraFk",
                            column: x => x.IdCompraFk,
                            principalTable: "compra",
                            principalColumn: "Id",
                            onDelete: ReferentialAction.Cascade
                        );
                        table.ForeignKey(
                            name: "FK_lote_medicamento_IdMedicamentoFk",
                            column: x => x.IdMedicamentoFk,
                            principalTable: "medicamento",
                            principalColumn: "Id",
                            onDelete: ReferentialAction.Cascade
                        );
                    }
                )
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder
                .CreateTable(
                    name: "venta",
                    columns: table =>
                        new
                        {
                            Id = table
                                .Column<int>(type: "int", nullable: false)
                                .Annotation(
                                    "MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn
                                ),
                            IdClienteFk = table.Column<int>(type: "int", nullable: false),
                            IdEmpleadoFk = table.Column<int>(type: "int", nullable: false),
                            CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_venta", x => x.Id);
                        table.ForeignKey(
                            name: "FK_venta_cliente_IdClienteFk",
                            column: x => x.IdClienteFk,
                            principalTable: "cliente",
                            principalColumn: "Id",
                            onDelete: ReferentialAction.Cascade
                        );
                        table.ForeignKey(
                            name: "FK_venta_empleado_IdEmpleadoFk",
                            column: x => x.IdEmpleadoFk,
                            principalTable: "empleado",
                            principalColumn: "Id",
                            onDelete: ReferentialAction.Cascade
                        );
                    }
                )
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder
                .CreateTable(
                    name: "detalleVenta",
                    columns: table =>
                        new
                        {
                            Id = table
                                .Column<int>(type: "int", nullable: false)
                                .Annotation(
                                    "MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn
                                ),
                            IdVentaFk = table.Column<int>(type: "int", nullable: false),
                            IdMedicamentoFk = table.Column<int>(type: "int", nullable: false),
                            IdLoteFk = table.Column<int>(type: "int", nullable: false),
                            cantidad = table.Column<int>(type: "int", nullable: false),
                            precioUnitario = table.Column<int>(type: "int", nullable: false),
                            subtotal = table.Column<int>(type: "int", nullable: false),
                            updated_at = table.Column<DateTime>(
                                type: "datetime(6)",
                                nullable: false,
                                defaultValueSql: "now()"
                            ),
                            created_at = table.Column<DateTime>(
                                type: "datetime(6)",
                                nullable: false,
                                defaultValueSql: "now()"
                            )
                        },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_detalleVenta", x => x.Id);
                        table.ForeignKey(
                            name: "FK_detalleVenta_lote_IdLoteFk",
                            column: x => x.IdLoteFk,
                            principalTable: "lote",
                            principalColumn: "Id",
                            onDelete: ReferentialAction.Cascade
                        );
                        table.ForeignKey(
                            name: "FK_detalleVenta_medicamento_IdMedicamentoFk",
                            column: x => x.IdMedicamentoFk,
                            principalTable: "medicamento",
                            principalColumn: "Id",
                            onDelete: ReferentialAction.Cascade
                        );
                        table.ForeignKey(
                            name: "FK_detalleVenta_venta_IdVentaFk",
                            column: x => x.IdVentaFk,
                            principalTable: "venta",
                            principalColumn: "Id",
                            onDelete: ReferentialAction.Cascade
                        );
                    }
                )
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_compra_IdProveedorFk",
                table: "compra",
                column: "IdProveedorFk"
            );

            migrationBuilder.CreateIndex(
                name: "IX_detalleVenta_IdLoteFk",
                table: "detalleVenta",
                column: "IdLoteFk"
            );

            migrationBuilder.CreateIndex(
                name: "IX_detalleVenta_IdMedicamentoFk",
                table: "detalleVenta",
                column: "IdMedicamentoFk"
            );

            migrationBuilder.CreateIndex(
                name: "IX_detalleVenta_IdVentaFk",
                table: "detalleVenta",
                column: "IdVentaFk"
            );

            migrationBuilder.CreateIndex(
                name: "IX_empleado_RolIdFk",
                table: "empleado",
                column: "RolIdFk"
            );

            migrationBuilder.CreateIndex(
                name: "IX_lote_IdCompraFk",
                table: "lote",
                column: "IdCompraFk"
            );

            migrationBuilder.CreateIndex(
                name: "IX_lote_IdMedicamentoFk",
                table: "lote",
                column: "IdMedicamentoFk"
            );

            migrationBuilder.CreateIndex(
                name: "IX_recetaMedica_IdClienteFk",
                table: "recetaMedica",
                column: "IdClienteFk"
            );

            migrationBuilder.CreateIndex(
                name: "IX_venta_IdClienteFk",
                table: "venta",
                column: "IdClienteFk"
            );

            migrationBuilder.CreateIndex(
                name: "IX_venta_IdEmpleadoFk",
                table: "venta",
                column: "IdEmpleadoFk"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "detalleVenta");

            migrationBuilder.DropTable(name: "recetaMedica");

            migrationBuilder.DropTable(name: "lote");

            migrationBuilder.DropTable(name: "venta");

            migrationBuilder.DropTable(name: "compra");

            migrationBuilder.DropTable(name: "medicamento");

            migrationBuilder.DropTable(name: "cliente");

            migrationBuilder.DropTable(name: "empleado");

            migrationBuilder.DropTable(name: "proveedor");

            migrationBuilder.DropTable(name: "rol");
        }
    }
}
