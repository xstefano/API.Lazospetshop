﻿// <auto-generated />
using System;
using API.Lazospetshop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Lazospetshop.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20231130053537_ModificacionTablas")]
    partial class ModificacionTablas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API.Lazospetshop.Models.TCarrito.Carrito", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idCarrito");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaPago")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("MetodoPago")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("MontoTotal")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Carrito");
                });

            modelBuilder.Entity("API.Lazospetshop.Models.TCategoria.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idCategoria");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("API.Lazospetshop.Models.TDetalleProducto.DetalleProducto", b =>
                {
                    b.Property<int>("CarritoId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int>("ProductoId")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<float>("PrecioUnitario")
                        .HasColumnType("real");

                    b.Property<float>("SubTotal")
                        .HasColumnType("real");

                    b.HasKey("CarritoId", "ProductoId");

                    b.HasIndex("ProductoId");

                    b.ToTable("DetalleProducto");
                });

            modelBuilder.Entity("API.Lazospetshop.Models.TDetalleServicio.DetalleServicio", b =>
                {
                    b.Property<int>("CarritoId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int>("ServicioId")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<int>("MascotaId")
                        .HasColumnType("int");

                    b.Property<float>("PrecioUnitario")
                        .HasColumnType("real");

                    b.Property<float>("SubTotal")
                        .HasColumnType("real");

                    b.HasKey("CarritoId", "ServicioId");

                    b.HasIndex("MascotaId");

                    b.HasIndex("ServicioId");

                    b.ToTable("DetalleServicio");
                });

            modelBuilder.Entity("API.Lazospetshop.Models.TGenero.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idGenero");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genero");
                });

            modelBuilder.Entity("API.Lazospetshop.Models.TMascota.Mascota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idMascota");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoMascotaId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipoMascotaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Mascota");
                });

            modelBuilder.Entity("API.Lazospetshop.Models.TProducto.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idProducto");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Precio")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("API.Lazospetshop.Models.TServicio.Servicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idServicio");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DescripcionServicio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreServicio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("PrecioServicio")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Servicio");
                });

            modelBuilder.Entity("API.Lazospetshop.Models.TTipoDocumento.TipoDocumento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idTipoDocumento");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoDocumento");
                });

            modelBuilder.Entity("API.Lazospetshop.Models.TTipoMascota.TipoMascota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idTipoMascota");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoMascota");
                });

            modelBuilder.Entity("API.Lazospetshop.Models.TUsuario.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idUsuario");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GeneroId")
                        .HasColumnType("int");

                    b.Property<string>("Imagen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroDocumento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoDocumentoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GeneroId");

                    b.HasIndex("TipoDocumentoId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("API.Lazospetshop.Models.TCarrito.Carrito", b =>
                {
                    b.HasOne("API.Lazospetshop.Models.TUsuario.Usuario", "Usuario")
                        .WithMany("Carritos")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("API.Lazospetshop.Models.TDetalleProducto.DetalleProducto", b =>
                {
                    b.HasOne("API.Lazospetshop.Models.TCarrito.Carrito", "Carrito")
                        .WithMany()
                        .HasForeignKey("CarritoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Lazospetshop.Models.TProducto.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carrito");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("API.Lazospetshop.Models.TDetalleServicio.DetalleServicio", b =>
                {
                    b.HasOne("API.Lazospetshop.Models.TCarrito.Carrito", "Carrito")
                        .WithMany()
                        .HasForeignKey("CarritoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Lazospetshop.Models.TMascota.Mascota", "Mascota")
                        .WithMany()
                        .HasForeignKey("MascotaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Lazospetshop.Models.TServicio.Servicio", "Servicio")
                        .WithMany()
                        .HasForeignKey("ServicioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carrito");

                    b.Navigation("Mascota");

                    b.Navigation("Servicio");
                });

            modelBuilder.Entity("API.Lazospetshop.Models.TMascota.Mascota", b =>
                {
                    b.HasOne("API.Lazospetshop.Models.TTipoMascota.TipoMascota", "TipoMascota")
                        .WithMany()
                        .HasForeignKey("TipoMascotaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Lazospetshop.Models.TUsuario.Usuario", "Usuario")
                        .WithMany("Mascotas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("TipoMascota");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("API.Lazospetshop.Models.TProducto.Producto", b =>
                {
                    b.HasOne("API.Lazospetshop.Models.TCategoria.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("API.Lazospetshop.Models.TUsuario.Usuario", b =>
                {
                    b.HasOne("API.Lazospetshop.Models.TGenero.Genero", "Genero")
                        .WithMany()
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Lazospetshop.Models.TTipoDocumento.TipoDocumento", "TipoDocumento")
                        .WithMany()
                        .HasForeignKey("TipoDocumentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genero");

                    b.Navigation("TipoDocumento");
                });

            modelBuilder.Entity("API.Lazospetshop.Models.TUsuario.Usuario", b =>
                {
                    b.Navigation("Carritos");

                    b.Navigation("Mascotas");
                });
#pragma warning restore 612, 618
        }
    }
}
