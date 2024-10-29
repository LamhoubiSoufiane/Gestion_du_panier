using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce_website.Models
{
    public class Achat
    {
        public int id { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateAchat { get; set; }
        public ICollection<LignePanier> lignesPanier { get; set; } = new List<LignePanier>();
        public string Status { get; set; }
    }
}
