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

namespace ecommerce_website.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ecommerce_websiteContext _context;

        public IndexModel(ecommerce_websiteContext context)
        {
            _context = context;
        }

        public IList<CategoryViewModel> categories { get;set; }

        public async Task OnGetAsync()
        {
            categories = await _context.Categories
                .Include(c => c.produits)
                .Select(c => new CategoryViewModel
                {
                    id = c.id,
                    nomCategorie = c.nomCategorie,
                    imageUrls = c.produits
                        .Select(p => p.imageUrl)
                        .Take(4)
                        .ToList()
                })
                .ToListAsync();
        }
    }
}
