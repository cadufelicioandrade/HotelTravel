﻿// <auto-generated />
using System;
using HotelTravelMemories.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HotelTravelMemories.Data.Migrations
{
    [DbContext(typeof(HotelContext))]
    [Migration("20220112175751_CheckoutId_null")]
    partial class CheckoutId_null
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("HotelTravelMemories.Domain.Model.Cargo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Cargos");
                });

            modelBuilder.Entity("HotelTravelMemories.Domain.Model.Checkout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DtCheckout")
                        .HasColumnType("datetime");

                    b.Property<int>("QtdDiarias")
                        .HasColumnType("int");

                    b.Property<int>("ReservaId")
                        .HasColumnType("int");

                    b.Property<double>("Total")
                        .HasColumnType("double");

                    b.Property<double>("ValorDiaria")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Checkouts");
                });

            modelBuilder.Entity("HotelTravelMemories.Domain.Model.Cidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Estado")
                        .HasColumnType("text");

                    b.Property<string>("UF")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Cidades");
                });

            modelBuilder.Entity("HotelTravelMemories.Domain.Model.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CPF")
                        .HasColumnType("text");

                    b.Property<string>("Celular")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<string>("RG")
                        .HasColumnType("text");

                    b.Property<string>("Telefone")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("HotelTravelMemories.Domain.Model.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .HasColumnType("text");

                    b.Property<string>("CEP")
                        .HasColumnType("text");

                    b.Property<int>("CidadeId")
                        .HasColumnType("int");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Complemento")
                        .HasColumnType("text");

                    b.Property<int?>("FuncionarioId")
                        .HasColumnType("int");

                    b.Property<string>("Logradouro")
                        .HasColumnType("text");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CidadeId");

                    b.HasIndex("ClienteId")
                        .IsUnique();

                    b.HasIndex("FuncionarioId")
                        .IsUnique();

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("HotelTravelMemories.Domain.Model.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("CPF")
                        .HasColumnType("text");

                    b.Property<int>("CargoId")
                        .HasColumnType("int");

                    b.Property<string>("Celular")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<string>("RG")
                        .HasColumnType("text");

                    b.Property<string>("Telefone")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CargoId");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("HotelTravelMemories.Domain.Model.Quarto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Andar")
                        .HasColumnType("int");

                    b.Property<bool>("Disponivel")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<int>("TipoQuartoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipoQuartoId");

                    b.ToTable("Quartos");
                });

            modelBuilder.Entity("HotelTravelMemories.Domain.Model.Reserva", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CheckoutId")
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DtInclusao")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DtReserva")
                        .HasColumnType("datetime");

                    b.Property<int>("FuncionarioId")
                        .HasColumnType("int");

                    b.Property<int>("QuartoId")
                        .HasColumnType("int");

                    b.Property<double>("Sinal")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("CheckoutId")
                        .IsUnique();

                    b.HasIndex("ClienteId");

                    b.HasIndex("FuncionarioId");

                    b.HasIndex("QuartoId");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("HotelTravelMemories.Domain.Model.Servico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("text");

                    b.Property<int>("ReservaId")
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .HasColumnType("text");

                    b.Property<double>("Valor")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("ReservaId");

                    b.ToTable("Servicos");
                });

            modelBuilder.Entity("HotelTravelMemories.Domain.Model.TipoQuarto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("text");

                    b.Property<double>("ValorDiaria")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("TipoQuarto");
                });

            modelBuilder.Entity("HotelTravelMemories.Domain.Model.Endereco", b =>
                {
                    b.HasOne("HotelTravelMemories.Domain.Model.Cidade", "Cidade")
                        .WithMany("Enderecos")
                        .HasForeignKey("CidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelTravelMemories.Domain.Model.Cliente", "Cliente")
                        .WithOne("Endereco")
                        .HasForeignKey("HotelTravelMemories.Domain.Model.Endereco", "ClienteId");

                    b.HasOne("HotelTravelMemories.Domain.Model.Funcionario", "Funcionario")
                        .WithOne("Endereco")
                        .HasForeignKey("HotelTravelMemories.Domain.Model.Endereco", "FuncionarioId");

                    b.Navigation("Cidade");

                    b.Navigation("Cliente");

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("HotelTravelMemories.Domain.Model.Funcionario", b =>
                {
                    b.HasOne("HotelTravelMemories.Domain.Model.Cargo", "Cargo")
                        .WithMany("Funcionario")
                        .HasForeignKey("CargoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cargo");
                });

            modelBuilder.Entity("HotelTravelMemories.Domain.Model.Quarto", b =>
                {
                    b.HasOne("HotelTravelMemories.Domain.Model.TipoQuarto", "TipoQuarto")
                        .WithMany("Quartos")
                        .HasForeignKey("TipoQuartoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoQuarto");
                });

            modelBuilder.Entity("HotelTravelMemories.Domain.Model.Reserva", b =>
                {
                    b.HasOne("HotelTravelMemories.Domain.Model.Checkout", "Checkout")
                        .WithOne("Reserva")
                        .HasForeignKey("HotelTravelMemories.Domain.Model.Reserva", "CheckoutId");

                    b.HasOne("HotelTravelMemories.Domain.Model.Cliente", "Cliente")
                        .WithMany("Reservas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelTravelMemories.Domain.Model.Funcionario", "Funcionario")
                        .WithMany("Reservas")
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelTravelMemories.Domain.Model.Quarto", "Quarto")
                        .WithMany("Reservas")
                        .HasForeignKey("QuartoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Checkout");

                    b.Navigation("Cliente");

                    b.Navigation("Funcionario");

                    b.Navigation("Quarto");
                });

            modelBuilder.Entity("HotelTravelMemories.Domain.Model.Servico", b =>
                {
                    b.HasOne("HotelTravelMemories.Domain.Model.Reserva", "Reserva")
                        .WithMany("Servicos")
                        .HasForeignKey("ReservaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reserva");
                });

            modelBuilder.Entity("HotelTravelMemories.Domain.Model.Cargo", b =>
                {
                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("HotelTravelMemories.Domain.Model.Checkout", b =>
                {
                    b.Navigation("Reserva");
                });

            modelBuilder.Entity("HotelTravelMemories.Domain.Model.Cidade", b =>
                {
                    b.Navigation("Enderecos");
                });

            modelBuilder.Entity("HotelTravelMemories.Domain.Model.Cliente", b =>
                {
                    b.Navigation("Endereco");

                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("HotelTravelMemories.Domain.Model.Funcionario", b =>
                {
                    b.Navigation("Endereco");

                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("HotelTravelMemories.Domain.Model.Quarto", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("HotelTravelMemories.Domain.Model.Reserva", b =>
                {
                    b.Navigation("Servicos");
                });

            modelBuilder.Entity("HotelTravelMemories.Domain.Model.TipoQuarto", b =>
                {
                    b.Navigation("Quartos");
                });
#pragma warning restore 612, 618
        }
    }
}
