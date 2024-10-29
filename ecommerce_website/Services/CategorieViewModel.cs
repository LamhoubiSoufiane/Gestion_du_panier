using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce_website.Services
{
    public class CategoryViewModel
    {
        public int id { get; set; }
        public string nomCategorie { get; set; }
        public List<string> imageUrls { get; set; } = new List<string>();
    }
}
