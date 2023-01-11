﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PrototypProjekta.Models;

#nullable disable

namespace PrototypProjekta.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230111103719_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PrototypProjekta.Models.CategoryModel", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Category name");

                    b.Property<int>("SneakerModelId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId");

                    b.HasIndex("SneakerModelId")
                        .IsUnique();

                    b.ToTable("Category");
                });

            modelBuilder.Entity("PrototypProjekta.Models.SneakerModel", b =>
                {
                    b.Property<int>("SneakerModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SneakerModelId"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Company name");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Model name");

                    b.Property<double>("Price")
                        .HasColumnType("float")
                        .HasColumnName("Price");

                    b.HasKey("SneakerModelId");

                    b.ToTable("Sneaker");
                });

            modelBuilder.Entity("PrototypProjekta.Models.CategoryModel", b =>
                {
                    b.HasOne("PrototypProjekta.Models.SneakerModel", "SneakerModel")
                        .WithOne("CategoryModel")
                        .HasForeignKey("PrototypProjekta.Models.CategoryModel", "SneakerModelId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("SneakerModel");
                });

            modelBuilder.Entity("PrototypProjekta.Models.SneakerModel", b =>
                {
                    b.Navigation("CategoryModel");
                });
#pragma warning restore 612, 618
        }
    }
}