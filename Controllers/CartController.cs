using Microsoft.AspNetCore.Mvc;
using WebPetProject.Models;
using WebPetProject.Infrastructure;

namespace WebPetProject.Controllers
{

     
    public class CartController : Controller
    {
        private IProductRepository repository;

        public CartController(IProductRepository repo)
        {
            repository = repo;
        }

        // Get a Cart object, modify it, and serialize it, saving the changes in the session. And redireting to page
        public RedirectToActionResult AddToCart(int productId, string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);
            if(product != null)
            {
                Cart cart = GetCart();
                cart.AddItem(product, 1);
                SaveCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int productId,string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID==productId);
            if(product != null)
            {
                Cart cart = GetCart();
                cart.RemoveLine(product);
                SaveCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        //Attempt to deserialize a JSON object; if the object doesn't exist, create a Cart object.
        private Cart GetCart() 
        {
            Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            return cart;    
        }

        private void SaveCart(Cart cart) 
        {
            HttpContext.Session.SetJson("Cart", cart);
        }
    }
}
