﻿// <auto-generated />
using System;
using Dextra.Lanchonete.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dextra.Lanchonete.Api.Migrations
{
    [DbContext(typeof(MyAppContext))]
    [Migration("20190224191517_Correcao")]
    partial class Correcao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dextra.Lanchonete.Api.Models.Ingrediente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<double>("Valor");

                    b.HasKey("Id");

                    b.ToTable("Ingredientes");
                });

            modelBuilder.Entity("Dextra.Lanchonete.Api.Models.IngredienteAdicional", b =>
                {
                    b.Property<int>("IngredienteId");

                    b.Property<int>("PedidoLancheId");

                    b.Property<int>("Quantidade");

                    b.HasKey("IngredienteId", "PedidoLancheId");

                    b.HasIndex("PedidoLancheId");

                    b.ToTable("IngredientesAdicionais");
                });

            modelBuilder.Entity("Dextra.Lanchonete.Api.Models.Lanche", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("Lanches");
                });

            modelBuilder.Entity("Dextra.Lanchonete.Api.Models.LancheIngrediente", b =>
                {
                    b.Property<int>("IngredienteId");

                    b.Property<int>("LancheId");

                    b.HasKey("IngredienteId", "LancheId");

                    b.HasIndex("LancheId");

                    b.ToTable("LancheIngredientes");
                });

            modelBuilder.Entity("Dextra.Lanchonete.Api.Models.PedidoLanche", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdLanche");

                    b.Property<int?>("IngredienteId");

                    b.Property<int?>("LancheId");

                    b.Property<double>("ValorFinal");

                    b.HasKey("Id");

                    b.HasIndex("IngredienteId");

                    b.HasIndex("LancheId");

                    b.ToTable("PedidoLanche");
                });

            modelBuilder.Entity("Dextra.Lanchonete.Api.Models.IngredienteAdicional", b =>
                {
                    b.HasOne("Dextra.Lanchonete.Api.Models.Ingrediente", "Ingrediente")
                        .WithMany("IngredienteAdicional")
                        .HasForeignKey("IngredienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Dextra.Lanchonete.Api.Models.PedidoLanche", "PedidoLanche")
                        .WithMany("IngredientesAdicionais")
                        .HasForeignKey("PedidoLancheId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dextra.Lanchonete.Api.Models.LancheIngrediente", b =>
                {
                    b.HasOne("Dextra.Lanchonete.Api.Models.Ingrediente", "Ingrediente")
                        .WithMany()
                        .HasForeignKey("IngredienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Dextra.Lanchonete.Api.Models.Lanche", "Lanches")
                        .WithMany("LancheIngredientes")
                        .HasForeignKey("LancheId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dextra.Lanchonete.Api.Models.PedidoLanche", b =>
                {
                    b.HasOne("Dextra.Lanchonete.Api.Models.Ingrediente")
                        .WithMany("PedidoLanche")
                        .HasForeignKey("IngredienteId");

                    b.HasOne("Dextra.Lanchonete.Api.Models.Lanche", "Lanche")
                        .WithMany()
                        .HasForeignKey("LancheId");
                });
#pragma warning restore 612, 618
        }
    }
}
