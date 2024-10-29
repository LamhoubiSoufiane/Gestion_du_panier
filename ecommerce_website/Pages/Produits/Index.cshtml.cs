using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ecommerce_website.Data;
using ecommerce_website.Models;
using ecommerce_website.Services;

namespace ecommerce_website.Pages.Produits
{
    public class IndexModel : PageModel
    {
        private readonly ecommerce_websiteContext _context;
        private readonly PanierService _panierService;

        public IndexModel(ecommerce_websiteContext context,PanierService panierService)
        {
            _context = context;
            _panierService = panierService;
        }

        public ICollection<Produit> produit { get;set; }
        public Produit produitPanier { get; set; }

        public async Task OnGetAsync(int idCategorie)
        {
            var categorie = await _context.Categories
                .Include(c => c.produits)
                .FirstOrDefaultAsync(c => c.id == idCategorie);

            if (categorie != null)
            {
                produit = categorie.produits;
            }
        }

        public IActionResult OnPostAddToCart(int productId,int quantitySelected,int idCategorie)
        {
            produitPanier = _context.Produit.FirstOrDefault(p => p.id == productId);
            _panierService.AddToCart(quantitySelected, produitPanier.prixProduit, produitPanier);
            return RedirectToPage(new { idCategorie });
        }
    }
}
