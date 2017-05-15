using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;

        public ProductController(IProductRepository repo){
            repository = repo;
        }

        public ViewResult List(string category, int page = 1)
             => View(new ProductsListViewModel {
                 Products = repository.Products
                 .Where(p => category == null || p.Category == category)
                 .OrderBy(p => p.ProductID)
                 .Skip((page -1) * PageSize)
                 .Take(PageSize),
                 PageInfo = new PageInfo {
                     CurrentPage = page,
                     ItemsPerPage = PageSize,
                     TotalItems = category == null ? repository.Products.Count():
                        repository.Products.Where(p => p.Category == category).Count()
                 },
                 CurrentCategory = category
             });
    }
}