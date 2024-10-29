﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ecommerce_website.Data;

namespace ecommerce_website.Migrations
{
    [DbContext(typeof(ecommerce_websiteContext))]
    [Migration("20241027214129_migration4")]
    partial class migration4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ecommerce_website.Models.Achat", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateAchat")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Achat");
                });

            modelBuilder.Entity("ecommerce_website.Models.Categorie", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nomCategorie")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Categorie");
                });

            modelBuilder.Entity("ecommerce_website.Models.Image", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Produitid")
                        .HasColumnType("int");

                    b.Property<bool>("imagePrincipale")
                        .HasColumnType("bit");

                    b.Property<string>("url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Produitid");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("ecommerce_website.Models.LignePanier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("achatid")
                        .HasColumnType("int");

                    b.Property<int>("id_achat")
                        .HasColumnType("int");

                    b.Property<int>("id_produit")
                        .HasColumnType("int");

                    b.Property<double>("prixdevente")
                        .HasColumnType("float");

                    b.Property<int?>("produitid")
                        .HasColumnType("int");

                    b.Property<int>("quantite_ligne")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("achatid");

                    b.HasIndex("produitid");

                    b.ToTable("LignePanier");
                });

            modelBuilder.Entity("ecommerce_website.Models.Produit", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("categorieId")
                        .HasColumnType("int");

                    b.Property<DateTime>("dateAjout")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nomProduit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("prixProduit")
                        .HasColumnType("float");

                    b.Property<int>("qteStock")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("categorieId");

                    b.ToTable("Produit");
                });

            modelBuilder.Entity("ecommerce_website.Models.Image", b =>
                {
                    b.HasOne("ecommerce_website.Models.Produit", null)
                        .WithMany("images")
                        .HasForeignKey("Produitid");
                });

            modelBuilder.Entity("ecommerce_website.Models.LignePanier", b =>
                {
                    b.HasOne("ecommerce_website.Models.Achat", "achat")
                        .WithMany("lignesPanier")
                        .HasForeignKey("achatid");

                    b.HasOne("ecommerce_website.Models.Produit", "produit")
                        .WithMany("lignesPanier")
                        .HasForeignKey("produitid");

                    b.Navigation("achat");

                    b.Navigation("produit");
                });

            modelBuilder.Entity("ecommerce_website.Models.Produit", b =>
                {
                    b.HasOne("ecommerce_website.Models.Categorie", "categorie")
                        .WithMany("produits")
                        .HasForeignKey("categorieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("categorie");
                });

            modelBuilder.Entity("ecommerce_website.Models.Achat", b =>
                {
                    b.Navigation("lignesPanier");
                });

            modelBuilder.Entity("ecommerce_website.Models.Categorie", b =>
                {
                    b.Navigation("produits");
                });

            modelBuilder.Entity("ecommerce_website.Models.Produit", b =>
                {
                    b.Navigation("images");

                    b.Navigation("lignesPanier");
                });
#pragma warning restore 612, 618
        }
    }
}
