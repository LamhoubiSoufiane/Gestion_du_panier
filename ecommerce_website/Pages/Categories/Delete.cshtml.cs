﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ecommerce_website.Data;
using ecommerce_website.Models;

namespace ecommerce_website.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ecommerce_website.Data.ecommerce_websiteContext _context;

        public DeleteModel(ecommerce_website.Data.ecommerce_websiteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Categorie Categorie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Categorie = await _context.Categories.FirstOrDefaultAsync(m => m.id == id);

            if (Categorie == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Categorie = await _context.Categories.FindAsync(id);

            if (Categorie != null)
            {
                _context.Categories.Remove(Categorie);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
