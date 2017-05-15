using System.Collections.Generic;

namespace SportsStore.Models.ViewModels
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }

        public PageInfo PageInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}