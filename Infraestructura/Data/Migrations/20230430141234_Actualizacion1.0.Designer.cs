﻿// <auto-generated />
using System;
using Infraestructura.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestructura.Data.Migrations
{
    [DbContext(typeof(TiendaContext))]
    [Migration("20230430141234_Actualizacion1.0")]
    partial class Actualizacion10
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("cedula_Cliente")
                        .HasMaxLength(9)
                        .HasColumnType("int");

                    b.Property<int>("codigo_Cliente")
                        .HasMaxLength(5)
                        .HasColumnType("int");

                    b.Property<DateTime>("fn_Cliente")
                        .HasColumnType("datetime2");

                    b.Property<string>("nombre_Cliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clientes", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Libro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int?>("codigo_Cliente")
                        .HasColumnType("int");

                    b.Property<int>("codigo_Libro")
                        .HasMaxLength(2)
                        .HasColumnType("int");

                    b.Property<string>("descripcion_Libro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("estado_Libro")
                        .HasColumnType("bit");

                    b.Property<DateTime>("fechaIngreso_Libro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("fechaRetiro_Libro")
                        .HasColumnType("datetime2");

                    b.Property<string>("nombre_Empresa")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("nombre_Libro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("precio_Libro")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Libros", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Libro", b =>
                {
                    b.HasOne("Core.Entities.Cliente", "Cliente")
                        .WithMany("libros_Cliente")
                        .HasForeignKey("ClienteId");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Core.Entities.Cliente", b =>
                {
                    b.Navigation("libros_Cliente");
                });
#pragma warning restore 612, 618
        }
    }
}