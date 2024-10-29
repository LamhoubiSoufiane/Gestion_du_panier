using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce_website.Models
{
    public class Categorie
    {
        public int id { get; set; }
        public string nomCategorie { get; set; }
        public ICollection<Produit> produits { get; set; } = new List<Produit>();
    }
}
