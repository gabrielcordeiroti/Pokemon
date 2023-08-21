﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pokemon.Data;

#nullable disable

namespace Pokemon.Data.Migrations
{
    [DbContext(typeof(TrainerPokemonDbContext))]
    partial class TrainerPokemonDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Pokemon.Domain.Entities.PokeTrainer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int?>("IdPokemons")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Trainers");
                });

            modelBuilder.Entity("Pokemon.Domain.Entities.PokemonCaught", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCaught")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdPokemon")
                        .HasColumnType("int");

                    b.Property<int>("IdTrainer")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdTrainer");

                    b.ToTable("PokemonCaught");
                });

            modelBuilder.Entity("Pokemon.Domain.Entities.PokemonCaught", b =>
                {
                    b.HasOne("Pokemon.Domain.Entities.PokeTrainer", null)
                        .WithMany("PokemonCaughts")
                        .HasForeignKey("IdTrainer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pokemon.Domain.Entities.PokeTrainer", b =>
                {
                    b.Navigation("PokemonCaughts");
                });
#pragma warning restore 612, 618
        }
    }
}