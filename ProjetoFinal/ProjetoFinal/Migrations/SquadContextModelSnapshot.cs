﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoFinal.Models;

namespace ProjetoFinal.Migrations
{
    [DbContext(typeof(SquadContext))]
    partial class SquadContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjetoFinal.Models.Logs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ambiente")
                        .IsRequired()
                        .HasColumnName("ambiente");

                    b.Property<bool>("Arquivado")
                        .HasColumnName("arquivado");

                    b.Property<string>("ColetadoPor")
                        .IsRequired()
                        .HasColumnName("coletado_por")
                        .HasMaxLength(255);

                    b.Property<DateTime>("Data")
                        .HasColumnName("data");

                    b.Property<int>("Evento")
                        .HasColumnName("evento");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnName("level");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnName("detalhes")
                        .HasMaxLength(50);

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnName("titulo");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("logs");
                });

            modelBuilder.Entity("ProjetoFinal.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasMaxLength(100);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("password");

                    b.HasKey("Id");

                    b.ToTable("user");
                });

            modelBuilder.Entity("ProjetoFinal.Models.Logs", b =>
                {
                    b.HasOne("ProjetoFinal.Models.User")
                        .WithMany("Logs")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
