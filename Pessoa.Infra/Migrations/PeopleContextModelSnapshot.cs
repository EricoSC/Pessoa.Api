﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pessoa.Infra;

#nullable disable

namespace Pessoa.Infra.Migrations
{
    [DbContext(typeof(PeopleContext))]
    partial class PeopleContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.7");

            modelBuilder.Entity("Pessoa.Entity.Endereco.Adress", b =>
                {
                    b.Property<int>("EnderecoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Numero")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PessoaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("EnderecoId");

                    b.HasIndex("PessoaId")
                        .IsUnique();

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("Pessoa.Entity.Pessoal.People", b =>
                {
                    b.Property<int>("PessoaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("TEXT");

                    b.Property<int>("Idade")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PessoaId");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("Pessoa.Entity.Endereco.Adress", b =>
                {
                    b.HasOne("Pessoa.Entity.Pessoal.People", "Pessoa")
                        .WithOne("Endereco")
                        .HasForeignKey("Pessoa.Entity.Endereco.Adress", "PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("Pessoa.Entity.Pessoal.People", b =>
                {
                    b.Navigation("Endereco")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
