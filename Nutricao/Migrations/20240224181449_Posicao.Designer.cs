﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nutricao.Core.Dtos.Context;

#nullable disable

namespace Nutricao.Migrations
{
    [DbContext(typeof(RefeicaoContext))]
    [Migration("20240224181449_Posicao")]
    partial class Posicao
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Nutricao.Models.CalculoDaRefeicao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<int>("Dia")
                        .HasColumnType("int");

                    b.Property<int>("Mes")
                        .HasColumnType("int");

                    b.Property<double>("TotalCalorias")
                        .HasColumnType("float");

                    b.Property<double>("TotalCarboidratos")
                        .HasColumnType("float");

                    b.Property<double>("TotalFibras")
                        .HasColumnType("float");

                    b.Property<double>("TotalGorduras")
                        .HasColumnType("float");

                    b.Property<double>("TotalProteinas")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Refeicao");
                });

            modelBuilder.Entity("Nutricao.Models.RefeicaoMVN", b =>
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

                    b.Property<double>("Fibra")
                        .HasColumnType("float");

                    b.Property<bool>("IsMatinal")
                        .HasColumnType("bit");

                    b.Property<bool>("IsNoturna")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVespertina")
                        .HasColumnType("bit");

                    b.Property<double>("Lipidios")
                        .HasColumnType("float");

                    b.Property<int>("Mes")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Posicao")
                        .HasColumnType("int");

                    b.Property<double>("Proteinas")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("RefeicaoMVN");
                });
#pragma warning restore 612, 618
        }
    }
}
