using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Controllers
{
    public class AdminController : Controller
    {
        private IProductRepository repository;

        public AdminController(IProductRepository repo){
            repository = repo;
        }

        public ViewResult Index() => View(repository.Products);

        public ViewResult Edit(int productID) => 
            View(repository.Products.FirstOrDefault(p => p.ProductID == productID));

        [HttpPost]
        public IActionResult Edit(Product product){
            if(ModelState.IsValid){
                repository.SaveProduct(product);
                TempData["message"] = $"{product.Name} has been saved";
                return RedirectToAction("Index");
            }
            else {
                return View(product);
            }
        }

        public ViewResult Create() => View("Edit", new Product());

        [HttpPost]
        public IActionResult Delete(int productID){
            Product deletedProduct = repository.DeleteProduct(productID);

            if (deletedProduct != null){
                TempData["message"] = $"The {deletedProduct.Name} was deleted";
            }

            return RedirectToAction("Index");
        }
    }
}