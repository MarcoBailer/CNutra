﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nutricao.Core.Dtos.Context;

#nullable disable

namespace Nutricao.Migrations
{
    [DbContext(typeof(RefeicaoContext))]
    partial class RefeicaoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Nutricao.Models.RefeicaoMatinal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<double>("Calorias")
                        .HasColumnType("float");

                    b.Property<double>("Carboidratos")
                        .HasColumnType("float");

                    b.Property<int>("Dia")
                        .HasColumnType("int");

                    b.Property<double>("Lipidios")
                        .HasColumnType("float");

                    b.Property<int>("Mes")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Proteinas")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("RefeicaoMatinal");
                });

            modelBuilder.Entity("Nutricao.Models.RefeicaoNoturna", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<double>("Calorias")
                        .HasColumnType("float");

                    b.Property<double>("Carboidratos")
                        .HasColumnType("float");

                    b.Property<int>("Dia")
                        .HasColumnType("int");

                    b.Property<double>("Lipidios")
                        .HasColumnType("float");

                    b.Property<int>("Mes")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Proteinas")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("RefeicaoNoturna");
                });

            modelBuilder.Entity("Nutricao.Models.RefeicaoVespertina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<double>("Calorias")
                        .HasColumnType("float");

                    b.Property<double>("Carboidratos")
                        .HasColumnType("float");

                    b.Property<int>("Dia")
                        .HasColumnType("int");

                    b.Property<double>("Lipidios")
                        .HasColumnType("float");

                    b.Property<int>("Mes")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Proteinas")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("RefeicaoVespertina");
                });
#pragma warning restore 612, 618
        }
    }
}
