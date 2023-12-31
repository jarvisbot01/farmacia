﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistencia;

#nullable disable

namespace Persistencia.Data.Migrations
{
    [DbContext(typeof(FarmaciaContext))]
    [Migration("20230922021608_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Dominio.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Cedula")
                        .HasColumnType("int")
                        .HasColumnName("cedula");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasColumnName("createdAt")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("direccion");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("email");

                    b.Property<bool>("EstaRegistrado")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("estaRegistrado");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("nombre");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("telefono");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updatedAt")
                        .HasDefaultValueSql("now()");

                    b.HasKey("Id");

                    b.ToTable("cliente", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Compra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasColumnName("createdAt")
                        .HasDefaultValueSql("now()");

                    b.Property<DateTime>("FechaCompra")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("fechaCompra");

                    b.Property<int>("IdProveedorFk")
                        .HasColumnType("int");

                    b.Property<int>("PrecioTotal")
                        .HasColumnType("int")
                        .HasColumnName("precioTotal");

                    b.HasKey("Id");

                    b.HasIndex("IdProveedorFk");

                    b.ToTable("compra", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.DetalleVenta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int")
                        .HasColumnName("cantidad");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<int>("IdLoteFk")
                        .HasColumnType("int");

                    b.Property<int>("IdMedicamentoFk")
                        .HasColumnType("int");

                    b.Property<int>("IdVentaFk")
                        .HasColumnType("int");

                    b.Property<int>("PrecioUnitario")
                        .HasColumnType("int")
                        .HasColumnName("precioUnitario");

                    b.Property<int>("Subtotal")
                        .HasColumnType("int")
                        .HasColumnName("subtotal");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("now()");

                    b.HasKey("Id");

                    b.HasIndex("IdLoteFk");

                    b.HasIndex("IdMedicamentoFk");

                    b.HasIndex("IdVentaFk");

                    b.ToTable("detalleVenta", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Empleado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Cedula")
                        .HasColumnType("int")
                        .HasColumnName("cedula");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasColumnName("createdAt")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("direccion");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("email");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("nombre");

                    b.Property<int>("RolIdFk")
                        .HasColumnType("int");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("telefono");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("RolIdFk");

                    b.ToTable("empleado", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Lote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int")
                        .HasColumnName("cantidad");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasColumnName("createdAt")
                        .HasDefaultValueSql("now()");

                    b.Property<DateTime>("FechaVencimiento")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("fechaVencimiento");

                    b.Property<int>("IdCompraFk")
                        .HasColumnType("int");

                    b.Property<int>("IdMedicamentoFk")
                        .HasColumnType("int");

                    b.Property<int>("PrecioCompra")
                        .HasColumnType("int")
                        .HasColumnName("precioCompra");

                    b.Property<int>("PrecioUnitario")
                        .HasColumnType("int")
                        .HasColumnName("precioUnitario");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updatedAt")
                        .HasDefaultValueSql("now()");

                    b.HasKey("Id");

                    b.HasIndex("IdCompraFk");

                    b.HasIndex("IdMedicamentoFk");

                    b.ToTable("lote", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Medicamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Concentracion")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("concentracion");

                    b.Property<string>("Contraindicaciones")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("contraindicaciones");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasColumnName("createdAt")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("DosisRecomendada")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("dosisRecomendada");

                    b.Property<DateTime>("FechaExpedicion")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("fechaExpedicion");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("nombre");

                    b.Property<string>("Precio")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("precio");

                    b.Property<string>("Stock")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("stock");

                    b.HasKey("Id");

                    b.ToTable("medicamento", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Proveedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("direccion");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("email");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("nombre");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("telefono");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("now()");

                    b.HasKey("Id");

                    b.ToTable("proveedor", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.RecetaMedica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasColumnName("createdAt")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Detalle")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("detalle");

                    b.Property<DateOnly>("FechaEmision")
                        .HasColumnType("date")
                        .HasColumnName("fechaEmision");

                    b.Property<int>("IdClienteFk")
                        .HasColumnType("int");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("token");

                    b.HasKey("Id");

                    b.HasIndex("IdClienteFk");

                    b.ToTable("recetaMedica", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("descripcion");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("nombre");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("now()");

                    b.HasKey("Id");

                    b.ToTable("rol", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Venta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdClienteFk")
                        .HasColumnType("int");

                    b.Property<int>("IdEmpleadoFk")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdClienteFk");

                    b.HasIndex("IdEmpleadoFk");

                    b.ToTable("venta", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Compra", b =>
                {
                    b.HasOne("Dominio.Entities.Proveedor", "Proveedor")
                        .WithMany("Compras")
                        .HasForeignKey("IdProveedorFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("Dominio.Entities.DetalleVenta", b =>
                {
                    b.HasOne("Dominio.Entities.Lote", "Lote")
                        .WithMany("DetalleVentas")
                        .HasForeignKey("IdLoteFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entities.Medicamento", "Medicamento")
                        .WithMany("DetalleVentas")
                        .HasForeignKey("IdMedicamentoFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entities.Venta", "Venta")
                        .WithMany("DetalleVentas")
                        .HasForeignKey("IdVentaFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lote");

                    b.Navigation("Medicamento");

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("Dominio.Entities.Empleado", b =>
                {
                    b.HasOne("Dominio.Entities.Rol", "Rol")
                        .WithMany("Empleados")
                        .HasForeignKey("RolIdFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("Dominio.Entities.Lote", b =>
                {
                    b.HasOne("Dominio.Entities.Compra", "Compra")
                        .WithMany("Lotes")
                        .HasForeignKey("IdCompraFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entities.Medicamento", "Medicamento")
                        .WithMany("Lotes")
                        .HasForeignKey("IdMedicamentoFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Compra");

                    b.Navigation("Medicamento");
                });

            modelBuilder.Entity("Dominio.Entities.RecetaMedica", b =>
                {
                    b.HasOne("Dominio.Entities.Cliente", "Cliente")
                        .WithMany("RecetasMedicas")
                        .HasForeignKey("IdClienteFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Dominio.Entities.Venta", b =>
                {
                    b.HasOne("Dominio.Entities.Cliente", "Cliente")
                        .WithMany("Ventas")
                        .HasForeignKey("IdClienteFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entities.Empleado", "Empleado")
                        .WithMany("Ventas")
                        .HasForeignKey("IdEmpleadoFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Empleado");
                });

            modelBuilder.Entity("Dominio.Entities.Cliente", b =>
                {
                    b.Navigation("RecetasMedicas");

                    b.Navigation("Ventas");
                });

            modelBuilder.Entity("Dominio.Entities.Compra", b =>
                {
                    b.Navigation("Lotes");
                });

            modelBuilder.Entity("Dominio.Entities.Empleado", b =>
                {
                    b.Navigation("Ventas");
                });

            modelBuilder.Entity("Dominio.Entities.Lote", b =>
                {
                    b.Navigation("DetalleVentas");
                });

            modelBuilder.Entity("Dominio.Entities.Medicamento", b =>
                {
                    b.Navigation("DetalleVentas");

                    b.Navigation("Lotes");
                });

            modelBuilder.Entity("Dominio.Entities.Proveedor", b =>
                {
                    b.Navigation("Compras");
                });

            modelBuilder.Entity("Dominio.Entities.Rol", b =>
                {
                    b.Navigation("Empleados");
                });

            modelBuilder.Entity("Dominio.Entities.Venta", b =>
                {
                    b.Navigation("DetalleVentas");
                });
#pragma warning restore 612, 618
        }
    }
}
