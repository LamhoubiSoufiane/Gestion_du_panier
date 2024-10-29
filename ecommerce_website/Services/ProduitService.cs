using ecommerce_website.Data;
using ecommerce_website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce_website.Services
{
    public class ProduitService
    {
        private readonly ecommerce_websiteContext context;

        public ProduitService(ecommerce_websiteContext _context)
        {
            context = _context;
        }

        public List<Produit> SearchProducts(string searchTerm)
        {
            return context.Produit
                .Where(p => p.nomProduit.Contains(searchTerm) || p.description.Contains(searchTerm))
                .ToList();
        }
    }
}
