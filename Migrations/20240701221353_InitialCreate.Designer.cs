﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication5.Data;

#nullable disable

namespace WebApplication5.Migrations
{
    [DbContext(typeof(LibreriaConext))]
    [Migration("20240701221353_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication5.Modelos.Autor", b =>
                {
                    b.Property<Guid>("IdAutor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdAutor");

                    b.ToTable("Autores");
                });

            modelBuilder.Entity("WebApplication5.Modelos.Genero", b =>
                {
                    b.Property<Guid>("IdGenero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdGenero");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("WebApplication5.Modelos.Libro", b =>
                {
                    b.Property<Guid>("Isbn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AutorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("FechaPublicacion")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("GeneroId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Isbn");

                    b.HasIndex("AutorId");

                    b.HasIndex("GeneroId");

                    b.ToTable("Libros");
                });

            modelBuilder.Entity("WebApplication5.Modelos.Libro", b =>
                {
                    b.HasOne("WebApplication5.Modelos.Autor", "Autor")
                        .WithMany("Libros")
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebApplication5.Modelos.Genero", "Genero")
                        .WithMany("Libros")
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Autor");

                    b.Navigation("Genero");
                });

            modelBuilder.Entity("WebApplication5.Modelos.Autor", b =>
                {
                    b.Navigation("Libros");
                });

            modelBuilder.Entity("WebApplication5.Modelos.Genero", b =>
                {
                    b.Navigation("Libros");
                });
#pragma warning restore 612, 618
        }
    }
}
