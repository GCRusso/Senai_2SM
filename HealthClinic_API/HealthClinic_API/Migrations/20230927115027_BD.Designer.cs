﻿// <auto-generated />
using System;
using HealthClinic_API.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HealthClinic_API.Migrations
{
    [DbContext(typeof(HealthContext))]
    [Migration("20230927115027_BD")]
    partial class BD
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HealthClinic_API.Domains.Clinica", b =>
                {
                    b.Property<Guid>("IdClinica")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("VARCHAR(14)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)");

                    b.Property<DateTime?>("HorarioAbertura")
                        .IsRequired()
                        .HasColumnType("SMALLDATETIME");

                    b.Property<DateTime?>("HorarioFechamento")
                        .IsRequired()
                        .HasColumnType("SMALLDATETIME");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("IdClinica");

                    b.HasIndex("CNPJ")
                        .IsUnique();

                    b.ToTable("Clinica");
                });

            modelBuilder.Entity("HealthClinic_API.Domains.ComentariosConsulta", b =>
                {
                    b.Property<Guid>("IdComentarioConsulta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IdConsulta")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Situacao")
                        .HasColumnType("BIT");

                    b.HasKey("IdComentarioConsulta");

                    b.HasIndex("IdConsulta");

                    b.ToTable("ComentariosConsulta");
                });

            modelBuilder.Entity("HealthClinic_API.Domains.Consulta", b =>
                {
                    b.Property<Guid>("IdConsulta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DataConsulta")
                        .IsRequired()
                        .HasColumnType("DATE");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("HorarioConsulta")
                        .IsRequired()
                        .HasColumnType("SMALLDATETIME");

                    b.Property<Guid>("IdMedico")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdPaciente")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdConsulta");

                    b.HasIndex("IdMedico");

                    b.HasIndex("IdPaciente");

                    b.ToTable("Consulta");
                });

            modelBuilder.Entity("HealthClinic_API.Domains.Especialidade", b =>
                {
                    b.Property<Guid>("IdEspecialidade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NomeEspecialidade")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("IdEspecialidade");

                    b.HasIndex("NomeEspecialidade")
                        .IsUnique();

                    b.ToTable("Especialidade");
                });

            modelBuilder.Entity("HealthClinic_API.Domains.Medico", b =>
                {
                    b.Property<Guid>("IdMedico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CRM")
                        .IsRequired()
                        .HasColumnType("VARCHAR(8)");

                    b.Property<Guid>("IdClinica")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdEspecialidade")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdMedico");

                    b.HasIndex("CRM")
                        .IsUnique();

                    b.HasIndex("IdClinica");

                    b.HasIndex("IdEspecialidade");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Medico");
                });

            modelBuilder.Entity("HealthClinic_API.Domains.Paciente", b =>
                {
                    b.Property<Guid>("IdPaciente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("VARCHAR(11)");

                    b.Property<DateTime?>("DataNascimento")
                        .IsRequired()
                        .HasColumnType("DATE");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<Guid?>("IdUsuario")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("VARCHAR(13)");

                    b.HasKey("IdPaciente");

                    b.HasIndex("CPF")
                        .IsUnique();

                    b.HasIndex("IdUsuario");

                    b.ToTable("Paciente");
                });

            modelBuilder.Entity("HealthClinic_API.Domains.TiposDeUsuario", b =>
                {
                    b.Property<Guid>("IdTipoDeUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("IdTipoDeUsuario");

                    b.HasIndex("Titulo")
                        .IsUnique();

                    b.ToTable("TiposDeUsuario");
                });

            modelBuilder.Entity("HealthClinic_API.Domains.Usuario", b =>
                {
                    b.Property<Guid>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<Guid>("IdTipoDeUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("IdUsuario");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("IdTipoDeUsuario");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("HealthClinic_API.Domains.ComentariosConsulta", b =>
                {
                    b.HasOne("HealthClinic_API.Domains.Consulta", "Consulta")
                        .WithMany()
                        .HasForeignKey("IdConsulta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Consulta");
                });

            modelBuilder.Entity("HealthClinic_API.Domains.Consulta", b =>
                {
                    b.HasOne("HealthClinic_API.Domains.Medico", "Medico")
                        .WithMany()
                        .HasForeignKey("IdMedico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthClinic_API.Domains.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("IdPaciente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medico");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("HealthClinic_API.Domains.Medico", b =>
                {
                    b.HasOne("HealthClinic_API.Domains.Clinica", "Clinica")
                        .WithMany()
                        .HasForeignKey("IdClinica")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthClinic_API.Domains.Especialidade", "Especialidade")
                        .WithMany()
                        .HasForeignKey("IdEspecialidade")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthClinic_API.Domains.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clinica");

                    b.Navigation("Especialidade");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("HealthClinic_API.Domains.Paciente", b =>
                {
                    b.HasOne("HealthClinic_API.Domains.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("HealthClinic_API.Domains.Usuario", b =>
                {
                    b.HasOne("HealthClinic_API.Domains.TiposDeUsuario", "TiposDeUsuario")
                        .WithMany()
                        .HasForeignKey("IdTipoDeUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TiposDeUsuario");
                });
#pragma warning restore 612, 618
        }
    }
}
