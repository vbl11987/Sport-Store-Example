using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using Microsoft.AspNetCore.Http;
using SportsStore.Infrastructure;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository repository;
        private Cart cart;

        public CartController(IProductRepository repo, Cart cartService){
            repository = repo;
            cart = cartService;
        }

        public ViewResult Index(string returnUrl){
            return View(new CartIndexViewModels {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }

        public RedirectToActionResult AddtoCart(int productId, string returnUrl){
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);

            if (product != null){
                cart.AddItem(product, 1);
            }

            return RedirectToAction("Index", new {returnUrl});
        }

        public RedirectToActionResult RemoveFromCart(int productId, string returnUrl){
            Product product = repository.Products.SingleOrDefault(p => p.ProductID == productId);

            if (product != null){
                cart.RemoveLine(product);
            }

            return RedirectToAction("Index", new {returnUrl});
        }

        private Cart GetCart(){
            Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            return cart;
        }

        private void SaveCart(Cart cart){
            HttpContext.Session.SetJson("Cart", cart);
        }
    }
}