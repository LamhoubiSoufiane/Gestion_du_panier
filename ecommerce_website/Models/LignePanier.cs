using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce_website.Models
{
    public class LignePanier
    {
        public int Id { get; set; }
        public int quantite_ligne { get; set; }
        public double prixdevente { get; set; }
        public int id_produit { get; set; }
        public Produit produit { get; set; }
        public int id_achat { get; set; }
        public Achat achat { get; set; }
    }
}
