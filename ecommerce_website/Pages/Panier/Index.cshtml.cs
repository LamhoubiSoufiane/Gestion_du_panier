using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce_website.Models;
using ecommerce_website.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ecommerce_website.Pages.Panier
{
    public class IndexModel : PageModel
    {
        private readonly PanierService _panierService;
        public List<LignePanier> lignesPanier { get; set; }
        public double TotalPrice { get; set; }
        public IndexModel(PanierService panierService)
        {
            _panierService = panierService;
        }

        public void OnGet()
        {
            lignesPanier = _panierService.GetCartItems();
            TotalPrice = _panierService.GetTotalPrice();
        }

        public IActionResult OnPostClearCart()
        {
            lignesPanier = _panierService.ClearCart();
            return Page();
        }

        public IActionResult OnPostRemoveFromCart(int ProductId)
        {
            lignesPanier = _panierService.GetCartItems();
            if (lignesPanier == null || !lignesPanier.Any(item => item.produit.id == ProductId))
            {
                ModelState.AddModelError(string.Empty, "Le produit n'existe pas dans le panier.");
                return RedirectToPage();
            }
            var itemToRemove = lignesPanier.FirstOrDefault(item => item.produit.id == ProductId);
            if (itemToRemove != null)
            {
                lignesPanier.Remove(itemToRemove);
                _panierService.SaveCartItems(lignesPanier);
            }
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSaveUpdatesAsync(Dictionary<int, int> Quantities)
        {
            lignesPanier = _panierService.GetCartItems();
            foreach (var item in lignesPanier)
            {
                if (Quantities.TryGetValue(item.id_produit, out int newQuantity))
                {
                    item.quantite_ligne = newQuantity;
                }
            }
            
            _panierService.SaveCartItems(lignesPanier);

            return RedirectToPage();
        }
    }
}
