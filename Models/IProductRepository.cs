using System.Collections.Generic;

namespace SportsStore.Models
{
    public interface IProductRepository
    {
         IEnumerable<Product> Products {get;}

         void SaveProduct(Product Product);

         Product DeleteProduct(int productID);
    }
}