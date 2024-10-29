using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce_website.Models;
using ecommerce_website.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ecommerce_website.Pages.Produits
{
    public class SearchModel : PageModel
    {
        private readonly ProduitService productService;
        public List<Produit> produits { get; set; }

        public SearchModel(ProduitService _productService)
        {
            productService = _productService;
        }   
        public void OnGet(string nomProduit)
        {
            if (!string.IsNullOrWhiteSpace(nomProduit))
            {
                produits = productService.SearchProducts(nomProduit);
            }
            else
            {
                produits = new List<Produit>();
            }
        }
    }
}
