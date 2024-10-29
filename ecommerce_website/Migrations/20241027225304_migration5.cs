using Microsoft.EntityFrameworkCore.Migrations;

namespace ecommerce_website.Migrations
{
    public partial class migration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produit_Categorie_categorieId",
                table: "Produit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorie",
                table: "Categorie");

            migrationBuilder.RenameTable(
                name: "Categorie",
                newName: "Categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Produit_Categories_categorieId",
                table: "Produit",
                column: "categorieId",
                principalTable: "Categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produit_Categories_categorieId",
                table: "Produit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Categorie");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorie",
                table: "Categorie",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Produit_Categorie_categorieId",
                table: "Produit",
                column: "categorieId",
                principalTable: "Categorie",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
