﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiTienda;

#nullable disable

namespace WebApiTienda.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230523020920_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApiTienda.Entidades.CarritoCompra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<string>("estado_pedido")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("CarritoCompras");
                });

            modelBuilder.Entity("WebApiTienda.Entidades.DetallePedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<int>("cantidad")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.HasIndex("ProductoId");

                    b.ToTable("DetallePedidos");
                });

            modelBuilder.Entity("WebApiTienda.Entidades.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<string>("estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fecha_hora")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("WebApiTienda.Entidades.Producto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("categoria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("stock")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("WebApiTienda.Entidades.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Contraseña")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("WebApiTienda.Entidades.CarritoCompra", b =>
                {
                    b.HasOne("WebApiTienda.Entidades.Usuario", "usuario")
                        .WithOne("Carrito")
                        .HasForeignKey("WebApiTienda.Entidades.CarritoCompra", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("WebApiTienda.Entidades.DetallePedido", b =>
                {
                    b.HasOne("WebApiTienda.Entidades.Pedido", "Pedido")
                        .WithMany("DetallePedidos")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApiTienda.Entidades.Producto", "Producto")
                        .WithMany("DetallePedidos")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("WebApiTienda.Entidades.Pedido", b =>
                {
                    b.HasOne("WebApiTienda.Entidades.Usuario", "Usuario")
                        .WithMany("Pedidos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("WebApiTienda.Entidades.Pedido", b =>
                {
                    b.Navigation("DetallePedidos");
                });

            modelBuilder.Entity("WebApiTienda.Entidades.Producto", b =>
                {
                    b.Navigation("DetallePedidos");
                });

            modelBuilder.Entity("WebApiTienda.Entidades.Usuario", b =>
                {
                    b.Navigation("Carrito");

                    b.Navigation("Pedidos");
                });
#pragma warning restore 612, 618
        }
    }
}
