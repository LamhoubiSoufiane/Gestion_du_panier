using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ecommerce_website.Data;
using ecommerce_website.Models;

namespace ecommerce_website.Pages.Produits
{
    public class EditModel : PageModel
    {
        private readonly ecommerce_website.Data.ecommerce_websiteContext _context;

        public EditModel(ecommerce_website.Data.ecommerce_websiteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Produit Produit { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Produit = await _context.Produit
                .Include(p => p.categorie).FirstOrDefaultAsync(m => m.id == id);

            if (Produit == null)
            {
                return NotFound();
            }
           ViewData["categorieId"] = new SelectList(_context.Categories, "id", "id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Produit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProduitExists(Produit.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProduitExists(int id)
        {
            return _context.Produit.Any(e => e.id == id);
        }
    }
}
