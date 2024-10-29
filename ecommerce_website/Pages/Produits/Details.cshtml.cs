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
    public class DetailsModel : PageModel
    {
        private readonly ecommerce_websiteContext _context;
        private readonly PanierService _panierService;

        public DetailsModel(ecommerce_websiteContext context, PanierService panierService)
        {
            _context = context;
            _panierService = panierService;
        }

        public Produit produit { get; set; }
        public Produit produitPanier { get; set; }


        public async Task<IActionResult> OnGetAsync(int? productId)
        {
            if (productId == null)
            {
                return NotFound();
            }

            produit = await _context.Produit
                .Include(p => p.categorie).FirstOrDefaultAsync(m => m.id == productId);

            if (produit == null)
            {
                return NotFound();
            }
            return Page();
        }
        public IActionResult OnPostAddToCart(int productId, int Quantity)
        {
            produitPanier = _context.Produit.FirstOrDefault(p => p.id == productId);
            _panierService.AddToCart(Quantity, produitPanier.prixProduit, produitPanier);
            return RedirectToPage(new { productId });
        }
    }
}
