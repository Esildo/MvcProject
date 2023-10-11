using Microsoft.AspNetCore.Mvc;
using WebPetProject.Models;
using WebPetProject.Infrastructure;
using WebPetProject.Models.ViewModels; 

namespace WebPetProject.Controllers
{

     
    public class CartController : Controller
    {
        private IProductRepository repository;
        private Cart cart;

        public CartController(IProductRepository repo,Cart cartService)
        {
            repository = repo;
            cart = cartService;
        }

        // Get a Cart object, modify it, and serialize it, saving the changes in the session. And redireting to page
        public RedirectToActionResult AddToCart(int productId, string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);
            if(product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int productId, string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        //Attempt to deserialize a JSON object; if the object doesn't exist, create a Cart object.

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }
    }
}
