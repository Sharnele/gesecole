﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using gesecole.Models;

#nullable disable

namespace gesecole.Migrations
{
    [DbContext(typeof(gesecolecontext))]
    [Migration("20221017203648_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CourEtudiant", b =>
                {
                    b.Property<int>("coursId")
                        .HasColumnType("int");

                    b.Property<int>("etudiantsId")
                        .HasColumnType("int");

                    b.HasKey("coursId", "etudiantsId");

                    b.HasIndex("etudiantsId");

                    b.ToTable("CourEtudiant");
                });

            modelBuilder.Entity("gesecole.Models.Cour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("cours");
                });

            modelBuilder.Entity("gesecole.Models.Etudiant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("etudiants");
                });

            modelBuilder.Entity("CourEtudiant", b =>
                {
                    b.HasOne("gesecole.Models.Cour", null)
                        .WithMany()
                        .HasForeignKey("coursId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("gesecole.Models.Etudiant", null)
                        .WithMany()
                        .HasForeignKey("etudiantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
