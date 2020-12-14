﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoPNT_MVC.Context;

namespace ProyectoPNT_MVC.Migrations
{
    [DbContext(typeof(ProyectoPNTDatabaseContext))]
    [Migration("20201108051333_ProyectoPNT_MVC.Context.ProyectoPNTDatabaseContext")]
    partial class ProyectoPNT_MVCContextProyectoPNTDatabaseContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProyectoPNT_MVC.Models.Articulo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imagen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("numeroArticulo")
                        .HasColumnType("int");

                    b.Property<double>("precio")
                        .HasColumnType("float");

                    b.Property<int>("stock")
                        .HasColumnType("int");

                    b.Property<string>("talle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Articulos");
                });

            modelBuilder.Entity("ProyectoPNT_MVC.Models.Carrito", b =>
                {
                    b.Property<int>("articuloId")
                        .HasColumnType("int");

                    b.Property<int>("usuarioId")
                        .HasColumnType("int");

                    b.HasKey("articuloId", "usuarioId");

                    b.HasIndex("usuarioId");

                    b.ToTable("Carrito");
                });

            modelBuilder.Entity("ProyectoPNT_MVC.Models.Compra", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("articuloId")
                        .HasColumnType("int");

                    b.Property<DateTime>("fechaCompra")
                        .HasColumnType("datetime2");

                    b.Property<int>("nroPedido")
                        .HasColumnType("int");

                    b.Property<double>("precioTotal")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("ProyectoPNT_MVC.Models.ListaArticulos", b =>
                {
                    b.Property<int>("articuloId")
                        .HasColumnType("int");

                    b.Property<int>("compraId")
                        .HasColumnType("int");

                    b.HasKey("articuloId", "compraId");

                    b.HasIndex("compraId");

                    b.ToTable("ListaArticulos");
                });

            modelBuilder.Entity("ProyectoPNT_MVC.Models.ListaCompras", b =>
                {
                    b.Property<int>("compraId")
                        .HasColumnType("int");

                    b.Property<int>("usuarioId")
                        .HasColumnType("int");

                    b.HasKey("compraId", "usuarioId");

                    b.HasIndex("usuarioId");

                    b.ToTable("ListaCompras");
                });

            modelBuilder.Entity("ProyectoPNT_MVC.Models.ListaDeseados", b =>
                {
                    b.Property<int>("articuloId")
                        .HasColumnType("int");

                    b.Property<int>("usuarioId")
                        .HasColumnType("int");

                    b.HasKey("articuloId", "usuarioId");

                    b.HasIndex("usuarioId");

                    b.ToTable("ListaDeseados");
                });

            modelBuilder.Entity("ProyectoPNT_MVC.Models.Usuario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ComprasId")
                        .HasColumnType("int");

                    b.Property<int>("carritoId")
                        .HasColumnType("int");

                    b.Property<string>("contraseña")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("deseadosId")
                        .HasColumnType("int");

                    b.Property<string>("direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombreCompleto")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("nombreUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("tipoUsuario")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ProyectoPNT_MVC.Models.Carrito", b =>
                {
                    b.HasOne("ProyectoPNT_MVC.Models.Articulo", "articulo")
                        .WithMany()
                        .HasForeignKey("articuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoPNT_MVC.Models.Usuario", "usuario")
                        .WithMany("carrito")
                        .HasForeignKey("usuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProyectoPNT_MVC.Models.ListaArticulos", b =>
                {
                    b.HasOne("ProyectoPNT_MVC.Models.Articulo", "articulo")
                        .WithMany()
                        .HasForeignKey("articuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoPNT_MVC.Models.Compra", "compra")
                        .WithMany("listaArticulos")
                        .HasForeignKey("compraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProyectoPNT_MVC.Models.ListaCompras", b =>
                {
                    b.HasOne("ProyectoPNT_MVC.Models.Compra", "compra")
                        .WithMany()
                        .HasForeignKey("compraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoPNT_MVC.Models.Usuario", "usuario")
                        .WithMany("compras")
                        .HasForeignKey("usuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProyectoPNT_MVC.Models.ListaDeseados", b =>
                {
                    b.HasOne("ProyectoPNT_MVC.Models.Articulo", "articulo")
                        .WithMany()
                        .HasForeignKey("articuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoPNT_MVC.Models.Usuario", "usuario")
                        .WithMany("deseados")
                        .HasForeignKey("usuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
