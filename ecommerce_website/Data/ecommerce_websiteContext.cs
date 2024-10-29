using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ecommerce_website.Models;

namespace ecommerce_website.Data
{
    public class ecommerce_websiteContext : DbContext
    {
        public ecommerce_websiteContext (DbContextOptions<ecommerce_websiteContext> options)
            : base(options)
        {
        }

        public DbSet<ecommerce_website.Models.Categorie> Categories { get; set; }

        public DbSet<ecommerce_website.Models.Produit> Produit { get; set; }

        public DbSet<Achat> Achats { get; set; }
        public DbSet<LignePanier> LignesAchat { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Produit>()
                .HasOne(p => p.categorie)
                .WithMany(c => c.produits)
                .HasForeignKey(p => p.categorieId) // Clé étrangère dans Produit
                .OnDelete(DeleteBehavior.Cascade); // Comportement lors de la suppression

            // Configuration de la relation entre LigneAchat et Achat (Many-to-One)
            modelBuilder.Entity<LignePanier>()
                .HasOne(l => l.achat)
                .WithMany(a => a.lignesPanier) // Un achat peut avoir plusieurs lignes d'achat
                .HasForeignKey(l => l.id_achat) // Clé étrangère dans LigneAchat
                .OnDelete(DeleteBehavior.Cascade); // Comportement lors de la suppression

            // Configuration de la relation entre LigneAchat et Produit (Many-to-One)
            modelBuilder.Entity<LignePanier>()
                .HasOne(l => l.produit)
                .WithMany() // Un produit peut être dans plusieurs lignes d'achat
                .HasForeignKey(l => l.id_produit) // Clé étrangère dans LigneAchat
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
