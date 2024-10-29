using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce_website.Models
{
    public class Produit
    {
        public int id { get; set; }
        public string nomProduit { get; set; }
        public string description { get; set; }
        public double prixProduit { get; set; }
        public int qteStock { get; set; }
        [DataType(DataType.Date)]
        public DateTime dateAjout { get; set; }
        public int categorieId { get; set; }
        public Categorie categorie { get; set; }
        public ICollection<LignePanier> lignesPanier { get; set; } = new List<LignePanier>();

        public ICollection<Image> images { get; set; } = new List<Image>();
         public string imageUrl { get; set; }
    }
}
