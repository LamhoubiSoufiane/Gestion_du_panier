using Microsoft.EntityFrameworkCore.Migrations;

namespace ecommerce_website.Migrations
{
    public partial class migration6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LignePanier_Achat_achatid",
                table: "LignePanier");

            migrationBuilder.DropForeignKey(
                name: "FK_LignePanier_Produit_produitid",
                table: "LignePanier");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LignePanier",
                table: "LignePanier");

            migrationBuilder.DropIndex(
                name: "IX_LignePanier_achatid",
                table: "LignePanier");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Achat",
                table: "Achat");

            migrationBuilder.DropColumn(
                name: "achatid",
                table: "LignePanier");

            migrationBuilder.RenameTable(
                name: "LignePanier",
                newName: "LignesAchat");

            migrationBuilder.RenameTable(
                name: "Achat",
                newName: "Achats");

            migrationBuilder.RenameColumn(
                name: "produitid",
                table: "LignesAchat",
                newName: "Produitid");

            migrationBuilder.RenameIndex(
                name: "IX_LignePanier_produitid",
                table: "LignesAchat",
                newName: "IX_LignesAchat_Produitid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LignesAchat",
                table: "LignesAchat",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Achats",
                table: "Achats",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_LignesAchat_id_achat",
                table: "LignesAchat",
                column: "id_achat");

            migrationBuilder.CreateIndex(
                name: "IX_LignesAchat_id_produit",
                table: "LignesAchat",
                column: "id_produit");

            migrationBuilder.AddForeignKey(
                name: "FK_LignesAchat_Achats_id_achat",
                table: "LignesAchat",
                column: "id_achat",
                principalTable: "Achats",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LignesAchat_Produit_id_produit",
                table: "LignesAchat",
                column: "id_produit",
                principalTable: "Produit",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LignesAchat_Produit_Produitid",
                table: "LignesAchat",
                column: "Produitid",
                principalTable: "Produit",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LignesAchat_Achats_id_achat",
                table: "LignesAchat");

            migrationBuilder.DropForeignKey(
                name: "FK_LignesAchat_Produit_id_produit",
                table: "LignesAchat");

            migrationBuilder.DropForeignKey(
                name: "FK_LignesAchat_Produit_Produitid",
                table: "LignesAchat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LignesAchat",
                table: "LignesAchat");

            migrationBuilder.DropIndex(
                name: "IX_LignesAchat_id_achat",
                table: "LignesAchat");

            migrationBuilder.DropIndex(
                name: "IX_LignesAchat_id_produit",
                table: "LignesAchat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Achats",
                table: "Achats");

            migrationBuilder.RenameTable(
                name: "LignesAchat",
                newName: "LignePanier");

            migrationBuilder.RenameTable(
                name: "Achats",
                newName: "Achat");

            migrationBuilder.RenameColumn(
                name: "Produitid",
                table: "LignePanier",
                newName: "produitid");

            migrationBuilder.RenameIndex(
                name: "IX_LignesAchat_Produitid",
                table: "LignePanier",
                newName: "IX_LignePanier_produitid");

            migrationBuilder.AddColumn<int>(
                name: "achatid",
                table: "LignePanier",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LignePanier",
                table: "LignePanier",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Achat",
                table: "Achat",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_LignePanier_achatid",
                table: "LignePanier",
                column: "achatid");

            migrationBuilder.AddForeignKey(
                name: "FK_LignePanier_Achat_achatid",
                table: "LignePanier",
                column: "achatid",
                principalTable: "Achat",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LignePanier_Produit_produitid",
                table: "LignePanier",
                column: "produitid",
                principalTable: "Produit",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
