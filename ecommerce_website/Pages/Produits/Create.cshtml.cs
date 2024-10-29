using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ecommerce_website.Data;
using ecommerce_website.Models;
using Microsoft.AspNetCore.Http;
using ecommerce_website.Services;

namespace ecommerce_website.Pages.Produits
{
    public class CreateModel : PageModel
    {
        private readonly ecommerce_websiteContext _context;
        private readonly ImageService _imageService;

        public List<SelectListItem> categories { get; set; }
        [BindProperty]
        public IFormFile Upload { get; set; }
        public string imageUrl { get; set; }
        [BindProperty]
        public Produit produit { get; set; }

        public CreateModel(ecommerce_websiteContext context, ImageService imageService)
        {
            _context = context;
            _imageService = imageService;
        }

        public IActionResult OnGet()
        {
            categories = _context.Categories.Select(c => new SelectListItem
            {
                Value = c.id.ToString(),
                Text = c.nomCategorie
            }).ToList();
            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                categories = _context.Categories.Select(c => new SelectListItem
                {
                    Value = c.id.ToString(),
                    Text = c.nomCategorie
                }).ToList();
                return Page();
            }
            produit.dateAjout = DateTime.Now;
            // Vérification du fichier Upload
            if (Upload == null || Upload.Length == 0)
            {
                ModelState.AddModelError(string.Empty, "Veuillez sélectionner une image à télécharger.");
                return Page();
            }
            try
            {
                var uploadResult = await _imageService.UploadImageAsync(Upload);
                if (uploadResult != null)
                {
                    produit.imageUrl = uploadResult;
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Une erreur s'est produite lors du téléchargement de l'image : " + ex.Message);
                return Page();
            }
            _context.Produit.Add(produit);
            await _context.SaveChangesAsync();

            return Page();
        
        }
    }
}
