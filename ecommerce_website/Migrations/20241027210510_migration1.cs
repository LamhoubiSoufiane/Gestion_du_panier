using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ecommerce_website.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Achat",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAchat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achat", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomCategorie = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Produit",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomProduit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    prixProduit = table.Column<double>(type: "float", nullable: false),
                    qteStock = table.Column<int>(type: "int", nullable: false),
                    dateAjout = table.Column<DateTime>(type: "datetime2", nullable: false),
                    categorieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produit", x => x.id);
                    table.ForeignKey(
                        name: "FK_Produit_Categorie_categorieId",
                        column: x => x.categorieId,
                        principalTable: "Categorie",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imagePrincipale = table.Column<bool>(type: "bit", nullable: false),
                    produitid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.id);
                    table.ForeignKey(
                        name: "FK_Image_Produit_produitid",
                        column: x => x.produitid,
                        principalTable: "Produit",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LignePanier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quantite_ligne = table.Column<int>(type: "int", nullable: false),
                    prixdevente = table.Column<double>(type: "float", nullable: false),
                    id_produit = table.Column<int>(type: "int", nullable: false),
                    produitid = table.Column<int>(type: "int", nullable: true),
                    id_achat = table.Column<int>(type: "int", nullable: false),
                    achatid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LignePanier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LignePanier_Achat_achatid",
                        column: x => x.achatid,
                        principalTable: "Achat",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LignePanier_Produit_produitid",
                        column: x => x.produitid,
                        principalTable: "Produit",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Image_produitid",
                table: "Image",
                column: "produitid");

            migrationBuilder.CreateIndex(
                name: "IX_LignePanier_achatid",
                table: "LignePanier",
                column: "achatid");

            migrationBuilder.CreateIndex(
                name: "IX_LignePanier_produitid",
                table: "LignePanier",
                column: "produitid");

            migrationBuilder.CreateIndex(
                name: "IX_Produit_categorieId",
                table: "Produit",
                column: "categorieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "LignePanier");

            migrationBuilder.DropTable(
                name: "Achat");

            migrationBuilder.DropTable(
                name: "Produit");

            migrationBuilder.DropTable(
                name: "Categorie");
        }
    }
}
