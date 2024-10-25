﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReserveAqui.Config;

#nullable disable

namespace ReserveAqui.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ReserveAqui.Models.Administrador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("InstituicaoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InstituicaoId");

                    b.ToTable("Administrador");
                });

            modelBuilder.Entity("ReserveAqui.Models.Instituicao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Instituicao");
                });

            modelBuilder.Entity("ReserveAqui.Models.Materia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Materia");
                });

            modelBuilder.Entity("ReserveAqui.Models.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Material");
                });

            modelBuilder.Entity("ReserveAqui.Models.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("InstituicaoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InstituicaoId");

                    b.ToTable("Professor");
                });

            modelBuilder.Entity("ReserveAqui.Models.ProfessorMateria", b =>
                {
                    b.Property<int>("MateriaId")
                        .HasColumnType("int");

                    b.Property<int>("ProfessorId")
                        .HasColumnType("int");

                    b.HasKey("MateriaId", "ProfessorId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("ProfessorMateria");
                });

            modelBuilder.Entity("ReserveAqui.Models.ReservaMaterial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Data")
                        .HasColumnType("date");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MaterialId")
                        .HasColumnType("int");

                    b.Property<int?>("ProfessorId")
                        .HasColumnType("int");

                    b.Property<string>("Turno")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MaterialId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("ReservaMaterial");
                });

            modelBuilder.Entity("ReserveAqui.Models.ReservaSala", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Data")
                        .HasColumnType("date");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProfessorId")
                        .HasColumnType("int");

                    b.Property<int?>("SalaId")
                        .HasColumnType("int");

                    b.Property<string>("Turno")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProfessorId");

                    b.HasIndex("SalaId");

                    b.ToTable("ReservaSala");
                });

            modelBuilder.Entity("ReserveAqui.Models.Sala", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sala");
                });

            modelBuilder.Entity("ReserveAqui.Models.Administrador", b =>
                {
                    b.HasOne("ReserveAqui.Models.Instituicao", "Instituicao")
                        .WithMany("Administradores")
                        .HasForeignKey("InstituicaoId");

                    b.Navigation("Instituicao");
                });

            modelBuilder.Entity("ReserveAqui.Models.Professor", b =>
                {
                    b.HasOne("ReserveAqui.Models.Instituicao", "Instituicao")
                        .WithMany("Professores")
                        .HasForeignKey("InstituicaoId");

                    b.Navigation("Instituicao");
                });

            modelBuilder.Entity("ReserveAqui.Models.ProfessorMateria", b =>
                {
                    b.HasOne("ReserveAqui.Models.Materia", null)
                        .WithMany()
                        .HasForeignKey("MateriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReserveAqui.Models.Professor", null)
                        .WithMany()
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ReserveAqui.Models.ReservaMaterial", b =>
                {
                    b.HasOne("ReserveAqui.Models.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId");

                    b.HasOne("ReserveAqui.Models.Professor", "Professor")
                        .WithMany()
                        .HasForeignKey("ProfessorId");

                    b.Navigation("Material");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("ReserveAqui.Models.ReservaSala", b =>
                {
                    b.HasOne("ReserveAqui.Models.Professor", "Professor")
                        .WithMany()
                        .HasForeignKey("ProfessorId");

                    b.HasOne("ReserveAqui.Models.Sala", "Sala")
                        .WithMany()
                        .HasForeignKey("SalaId");

                    b.Navigation("Professor");

                    b.Navigation("Sala");
                });

            modelBuilder.Entity("ReserveAqui.Models.Instituicao", b =>
                {
                    b.Navigation("Administradores");

                    b.Navigation("Professores");
                });
#pragma warning restore 612, 618
        }
    }
}
