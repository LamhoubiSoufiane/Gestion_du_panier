using ecommerce_website.Data;
using ecommerce_website.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ecommerce_website.Services
{
    public class PanierService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ecommerce_websiteContext _context;
        public List<LignePanier> lignePaniers { get; set; }

        public PanierService(IHttpContextAccessor httpContextAccessor, ecommerce_websiteContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }
        public List<LignePanier> GetCartItems()
        {
            var context = _httpContextAccessor.HttpContext;
            var cartCookie = context.Request.Cookies[GetCartCookieName()];

            if (string.IsNullOrEmpty(cartCookie))
            {
                return new List<LignePanier>();
            }

            return JsonConvert.DeserializeObject<List<LignePanier>>(cartCookie);
        }
        public void SaveCartItems(List<LignePanier> cartItems)
        {
            var context = _httpContextAccessor.HttpContext;
            var options = new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddDays(30)
            };

            var json = JsonConvert.SerializeObject(cartItems);
            context.Response.Cookies.Append(GetCartCookieName(), json, options);
        }
        public void AddToCart(int quantitySelected, double prixProduit,Produit produitPanier)
        {
            lignePaniers = GetCartItems() ?? new List<LignePanier>();

            var existingItem = lignePaniers.Find(i => i.id_produit == produitPanier.id);
            if (existingItem != null)
            {
                existingItem.quantite_ligne += quantitySelected;
            }
            else
            {
                var ligne = new LignePanier
                {
                    quantite_ligne = quantitySelected,
                    prixdevente = produitPanier.prixProduit,
                    id_produit = produitPanier.id,
                    produit = produitPanier,
                    achat = null,
                };
                lignePaniers.Add(ligne);
            }

            SaveCartItems(lignePaniers);
        }
        public double GetTotalPrice()
        {
            var cartItems = GetCartItems() ?? new List<LignePanier>();
            double totalPrice = 0;

            if(cartItems != null)
            {
                foreach (var item in cartItems)
                {
                    totalPrice += item.prixdevente * item.quantite_ligne;
                }
            }

            return totalPrice;
        }
        private string GetCartCookieName()
        {
            var userId = _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated ?
                _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value :
                "Cart_Anonymous";
            return $"Cart_{userId}";
        }
        public List<LignePanier> ClearCart()
        {
            var context = _httpContextAccessor.HttpContext;
            context.Response.Cookies.Delete(GetCartCookieName());

            lignePaniers = new List<LignePanier>();
            return lignePaniers;
        }
        public void RemoveItem(int productId)
        {
            lignePaniers = GetCartItems();
            var itemToRemove = lignePaniers.FirstOrDefault(item => item.produit.id == productId);
            if (itemToRemove != null)
            {
                lignePaniers.Remove(itemToRemove);
                SaveCartItems(lignePaniers);
            }

        }




    }
}
