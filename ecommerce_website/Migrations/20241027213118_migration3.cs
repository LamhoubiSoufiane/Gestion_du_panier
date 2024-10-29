using Microsoft.EntityFrameworkCore.Migrations;

namespace ecommerce_website.Migrations
{
    public partial class migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Produit_produitid",
                table: "Image");

            migrationBuilder.RenameColumn(
                name: "produitid",
                table: "Image",
                newName: "Produitid");

            migrationBuilder.RenameIndex(
                name: "IX_Image_produitid",
                table: "Image",
                newName: "IX_Image_Produitid");

            migrationBuilder.AddColumn<string>(
                name: "imageUrl",
                table: "Produit",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Produit_Produitid",
                table: "Image",
                column: "Produitid",
                principalTable: "Produit",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Produit_Produitid",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "imageUrl",
                table: "Produit");

            migrationBuilder.RenameColumn(
                name: "Produitid",
                table: "Image",
                newName: "produitid");

            migrationBuilder.RenameIndex(
                name: "IX_Image_Produitid",
                table: "Image",
                newName: "IX_Image_produitid");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Produit_produitid",
                table: "Image",
                column: "produitid",
                principalTable: "Produit",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
